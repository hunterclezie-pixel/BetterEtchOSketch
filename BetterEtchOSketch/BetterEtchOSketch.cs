using System.IO.Ports;
namespace BetterEtchOSketch
{
    public partial class BetterEtchOSketch : Form
    {
        public BetterEtchOSketch()
        {
            InitializeComponent();
            DisplayPictureBox.MouseMove += DisplayPictureBox_MouseStuff;
            DisplayPictureBox.MouseDown += DisplayPictureBox_MouseStuff;
            MouseRadioButton.Enabled = true;

            // Event handlers for Context Menu items
            ExitStripMenuItem.Click += ExitButton_Click;
            ClearStripMenuItem.Click += ClearButton_Click;
            DrawWaveformStripMenuItem.Click += DrawWavefomButton_Click;
            SelectColorStripMenuItem.Click += SelectColorButton_Click;

            // Event handler for the Main Menu items
            ExitMainStripItem.Click += ExitButton_Click;
            ClearMainStripItem.Click += ClearButton_Click;
            DrawWaveformMainStripItem.Click += DrawWavefomButton_Click;
            SelectColorMainStripItem.Click += SelectColorButton_Click;
            AboutMainStripItem.Click += AboutStripMenuItem_Click;

            // New drawing modes
            MouseRadioButton.Checked = true;
            MouseRadioButton.CheckedChanged += DrawingModeChanged;
            ExternalRadioButton.CheckedChanged += DrawingModeChanged;

            // Tooltips
            tips.SetToolTip(DisplayPictureBox, "Hold the left mouse button to draw; middle-click to select a color.");
            tips.SetToolTip(SelectColorButton, "Choose a pen color.");
            tips.SetToolTip(DrawWaveformButton, "Draw a grid, sine, cosine, and tangent waves.");
            tips.SetToolTip(ClearButton, "Shake and clear the drawing.");
            tips.SetToolTip(ExitButton, "Close Etch-O-Sketch.");
            tips.SetToolTip(MouseRadioButton, "Draw using the mouse.");
            tips.SetToolTip(ExternalRadioButton, "Draw using two PIC potentiometers.");

            // PIC timer (automatic device identification)
            picTimer.Interval = 50;
            picTimer.Tick += PicTimer_Tick;
            picTimer.Start();

            // Close the PIC connection when the form closes
            this.FormClosing += BetterEtchOSketch_FormClosing;
        }

        //Global Variables below here --------------------------------------------------------------

        private int oldX, oldY;
        private Color penColor = Color.Black;
        private Color backColor = Color.White;
        private int penSize = 1;

        // Serial and potentiometer variables below Here --------------------------------------------------------------
        private ToolTip tips = new ToolTip();
        private SerialPort? picPort;
        private System.Windows.Forms.Timer picTimer = new System.Windows.Forms.Timer();
        private List<byte> receivedBytes = new List<byte>();
        private bool picScanning = false, picWaiting = false;
        private volatile bool picClosing = false;
        private bool picPointReady = false;
        private int adcX = -1, adcY = -1;
        private int nextChannel = 0, requestedChannel = -1;
        private DateTime picRequestTime, nextPICScan = DateTime.MinValue;
        private int adcFailures = 0;

        static readonly byte[] IdRequest = { 0x24, 0x49, 0x00 };
        static readonly byte[] IdReply = { 0x24, 0x49, 0x02, 0x33, 0x75 };
        static readonly byte[] AN0Request = { 0x24, 0x41, 0x01, 0x00 };
        static readonly byte[] AN1Request = { 0x24, 0x41, 0x01, 0x01 };

        // Serial and analog methods below here --------------------------------------------------------------

        // Search for the PIC device on available serial ports and establish a connection
        async void SearchForPIC()
        {
            if (picScanning || picClosing || !ExternalRadioButton.Checked) return;
            picScanning = true;
            SerialPort? found = null;
            try
            {
                found = await Task.Run(FindPIC);
                if (picClosing || IsDisposed || !ExternalRadioButton.Checked)
                {
                    found?.Dispose();
                    return;
                }
                if (found == null)
                {
                    this.Text = "PIC not found - check USB and firmware";
                    nextPICScan = DateTime.Now.AddSeconds(2);
                }
                else
                {
                    picPort = found;
                    picWaiting = false;
                    requestedChannel = -1;
                    nextChannel = 0;
                    receivedBytes.Clear();
                    this.Text = "PIC verified: " + found.PortName;
                }
            }
            catch (Exception ex)
            {
                found?.Dispose();
                this.Text = "PIC connection error: " + ex.Message;
                nextPICScan = DateTime.Now.AddSeconds(2);
            }
            finally { picScanning = false; }
        }

        // Check exact device ID before sending ADC requests
        SerialPort? FindPIC()
        {
            string[] ports;
            try { ports = SerialPort.GetPortNames(); }
            catch (Exception) { return null; }

            foreach (string name in ports)
            {
                if (picClosing) return null;
                SerialPort candidate = new SerialPort(name, 9600, Parity.None, 8, StopBits.One);
                bool accepted = false;
                try
                {
                    candidate.ReadTimeout = 50;
                    candidate.WriteTimeout = 500;
                    candidate.Open();
                    System.Threading.Thread.Sleep(100);
                    for (int attempt = 0; attempt < 2 && !accepted && !picClosing; attempt++)
                    {
                        candidate.DiscardInBuffer();
                        candidate.Write(IdRequest, 0, IdRequest.Length);
                        List<byte> reply = new List<byte>();
                        DateTime stop = DateTime.UtcNow.AddMilliseconds(500);
                        while (DateTime.UtcNow < stop && reply.Count < 5 && !picClosing)
                        {
                            try { reply.Add((byte)candidate.ReadByte()); }
                            catch (TimeoutException) { }
                        }
                        if (reply.Count == 5)
                        {
                            System.Threading.Thread.Sleep(50);
                            while (candidate.BytesToRead > 0 && reply.Count < 11)
                                reply.Add((byte)candidate.ReadByte());
                        }
                        accepted = reply.Count == IdReply.Length &&
                            reply.ToArray().AsSpan().SequenceEqual(IdReply);
                    }
                    if (accepted && !picClosing) return candidate;
                }
                catch (Exception) { }
                candidate.Dispose();
            }
            return null;
        }

        // Packet format: 24 command payloadLength payload...
        void ReceiveByte(byte value)
        {
            if (receivedBytes.Count == 0 && value != 0x24) return;
            receivedBytes.Add(value);
            if (receivedBytes.Count == 3 && receivedBytes[2] > 8)
            {
                receivedBytes.Clear();
                return;
            }
            if (receivedBytes.Count < 3 || receivedBytes.Count < receivedBytes[2] + 3) return;

            byte[] reply = receivedBytes.ToArray();
            receivedBytes.Clear();

            if (reply[1] == 0x45)
            {
                ClosePIC();
                this.Text = "PIC reported UART error";
                nextPICScan = DateTime.Now.AddSeconds(2);
                return;
            }
            if (!picWaiting || reply[1] != 0x41 || reply[2] != 3 ||
                reply[3] != requestedChannel) return;

            int adc = reply[4] * 256 + reply[5];
            if (adc > 1023) return;

            if (requestedChannel == 0) adcX = adc;
            else adcY = adc;
            picWaiting = false;
            adcFailures = 0;
            nextChannel = 1 - requestedChannel;
            if (requestedChannel == 1) DrawFromPIC();
        }

        // Request the next ADC value from the PIC, alternating between AN0 and AN1 channels
        void RequestADC()
        {
            if (picPort == null || !picPort.IsOpen || picWaiting) return;
            byte[] request = nextChannel == 0 ? AN0Request : AN1Request;
            requestedChannel = nextChannel;
            picPort.Write(request, 0, request.Length);
            picWaiting = true;
            picRequestTime = DateTime.Now;
        }

        // Close the serial port and reset variables when the PIC is disconnected or an error occurs
        void ClosePIC()
        {
            try { picPort?.Close(); picPort?.Dispose(); } catch (Exception) { }
            picPort = null;
            picWaiting = false;
            picPointReady = false;
            adcX = -1;
            adcY = -1;
            requestedChannel = -1;
            nextChannel = 0;
            receivedBytes.Clear();
        }

        // Close the serial port when the application exits
        private void BetterEtchOSketch_FormClosing(object? sender, FormClosingEventArgs e)
        {
            picClosing = true;
            picTimer.Stop();
            ClosePIC();
        }

        // Drawing methods below here --------------------------------------------------------------

        // Draws a line segment from the last position to the new position
        void DrawLineSegment(int newX, int newY)
        {
            //create a graphics object named g that draws on the picture box
            Graphics g = DisplayPictureBox.CreateGraphics();
            //create a pen to draw with
            Pen thePen = new Pen(this.penColor);
            thePen.Width = penSize;
            //draw the line here
            g.DrawLine(thePen, oldX, oldY, newX, newY);

            //free up resorces
            g.Dispose();
            thePen.Dispose();
        }

        // Draws a sine wave on the picture box
        void DrawSineWave()
        {
            //create a graphics object named g that draws on the picture box
            Graphics g = DisplayPictureBox.CreateGraphics();
            //create a pen to draw with
            Pen thePen = new Pen(Color.Lime);
            int lastX = 0, lastY = 0, currentY = 0;
            float scaleX = DisplayPictureBox.Width / 360f;
            float scaleY = (DisplayPictureBox.Height / 200f) * -1;

            g.TranslateTransform(0, DisplayPictureBox.Height / 2);

            g.ScaleTransform(scaleX, scaleY);

            for (int currentX = 0; currentX < 360; currentX++)
            {
                currentY = (int)(Math.Round(100 * Math.Sin((Math.PI / 180) * currentX)));
                g.DrawLine(thePen, lastX, lastY, currentX, currentY);
                lastX = currentX;
                lastY = currentY;
            }

            //free up resorces
            g.Dispose();
            thePen.Dispose();
        }

        // Draws a cosine wave on the picture box
        void DrawCosineWave()
        {
            //create a graphics object named g that draws on the picture box
            Graphics g = DisplayPictureBox.CreateGraphics();
            //create a pen to draw with
            Pen thePen = new Pen(Color.Red);
            int lastX = 0, lastY = 0, currentY = 0;
            float scaleX = DisplayPictureBox.Width / 360f;
            float scaleY = (DisplayPictureBox.Height / 200f) * -1;
            g.TranslateTransform(0, DisplayPictureBox.Height / 2);
            g.ScaleTransform(scaleX, scaleY);
            for (int currentX = 0; currentX < 360; currentX++)
            {
                currentY = (int)(Math.Round(100 * Math.Cos((Math.PI / 180) * currentX)));
                g.DrawLine(thePen, lastX, lastY, currentX, currentY);
                lastX = currentX;
                lastY = currentY;
            }
            //free up resorces
            g.Dispose();
            thePen.Dispose();
        }

        // Draws a tangent wave on the picture box
        void DrawTangentWave()
        {
            //create a graphics object named g that draws on the picture box
            Graphics g = DisplayPictureBox.CreateGraphics();
            //create a pen to draw with
            Pen thePen = new Pen(Color.Blue);
            int lastX = 0, lastY = 0, currentY = 0;
            float scaleX = DisplayPictureBox.Width / 360f;
            float scaleY = (DisplayPictureBox.Height / 200f) * -1;
            g.TranslateTransform(0, DisplayPictureBox.Height / 2);
            g.ScaleTransform(scaleX, scaleY);
            for (int currentX = 0; currentX < 360; currentX++)
            {
                currentY = (int)(Math.Round(100 * Math.Tan((Math.PI / 180) * currentX)));
                if (Math.Abs(currentY) < DisplayPictureBox.Height / 2)
                {
                    g.DrawLine(thePen, lastX, lastY, currentX, currentY);
                }
                lastX = currentX;
                lastY = currentY;
            }
            //free up resorces
            g.Dispose();
            thePen.Dispose();
        }

        // Draws a grid on the picture box
        void DrawGrid()
        {
            int xDiv = DisplayPictureBox.Width / 10;
            int yDiv = DisplayPictureBox.Height / 10;

            this.oldX = 0;
            this.oldY = 0;
            for (int x = 0; x < DisplayPictureBox.Width; x += xDiv)
            {
                oldX = x;
                DrawLineSegment(x, DisplayPictureBox.Height);
            }

            this.oldX = 0;
            this.oldY = 0;
            for (int y = 0; y < DisplayPictureBox.Height; y += yDiv)
            {
                oldY = y;
                DrawLineSegment(DisplayPictureBox.Width, y);
            }
        }

        // Shakes the form to create a visual effect when clearing the screen
        private void ShakeEtchOSketch()
        {
            Random random = new Random();
            int shakeAmount = 15; // Adjust this value to increase/decrease the shake intensity
            int originalX = this.Location.X;
            int originalY = this.Location.Y;

            for (int i = 0; i < 10; i++)
            {
                int offsetX = random.Next(-shakeAmount, shakeAmount + 1);
                int offsetY = random.Next(-shakeAmount, shakeAmount + 1);
                System.Threading.Thread.Sleep(50);
                this.Location = new Point(originalX + offsetX, originalY + offsetY);
            }
            this.Location = new Point(originalX, originalY); // Return to original position after shaking
        }

        // Draws a line segment based on the ADC values received from the PIC
        void DrawFromPIC()
        {
            if (!ExternalRadioButton.Checked || adcX < 0 || adcY < 0)
                return;

            int newX = adcX * (DisplayPictureBox.Width - 1) / 1023;
            int newY = adcY * (DisplayPictureBox.Height - 1) / 1023;

            if (picPointReady)
            {
                DrawLineSegment(newX, newY);
            }

            oldX = newX;
            oldY = newY;
            picPointReady = true;
        }

        // Handles mouse movement on the picture box for drawing
        private void DisplayPictureBox_MouseStuff(object? sender, MouseEventArgs e)
        {
            if (!MouseRadioButton.Checked) return;

            if (e.Button == MouseButtons.Left)
            {
                DrawLineSegment(e.X, e.Y);
            }

            oldX = e.X;
            oldY = e.Y;
            this.Text = $"{e.X},{e.Y}";
        }

        // Handles mouse clicks for the context menu, pen color, and starting position
        private void DisplayPictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisplayContextMenuStrip.Show(DisplayPictureBox, e.Location);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                UpdatePenColor();
            }
            else if (e.Button == MouseButtons.Left && MouseRadioButton.Checked)
            {
                oldX = e.X;
                oldY = e.Y;
            }
        }

        // Opens the color dialog to select a new pen color
        private void UpdatePenColor()
        {
            PenColorDialog.ShowDialog();
            this.penColor = PenColorDialog.Color;
        }

        // Opens the color dialog to select a new background color
        void UpdateBackgroundColor()
        {
            PenColorDialog.ShowDialog();
            this.backColor = PenColorDialog.Color;
            DisplayPictureBox.BackColor = this.backColor;
        }

        // New drawing mode selection
        private void DrawingModeChanged(object? sender, EventArgs e)
        {
            picPointReady = false;
            adcX = -1;
            adcY = -1;

            if (ExternalRadioButton.Checked)
            {
                this.Text = "Etch-O-Sketch - Searching for PIC";
                nextPICScan = DateTime.MinValue;
                SearchForPIC();
            }
            else if (MouseRadioButton.Checked)
            {
                ClosePIC();
                this.Text = "Etch-O-Sketch - Mouse";
            }
        }

        //Event Handlers below here --------------------------------------------------------------

        private void PicTimer_Tick(object? sender, EventArgs e)
        // Timer receives partial packets and alternates AN0 and AN1 requests
        {
            if (!ExternalRadioButton.Checked || picClosing) return;
            if (picPort == null || !picPort.IsOpen)
            {
                if (!picScanning && DateTime.Now >= nextPICScan) SearchForPIC();
                return;
            }
            try
            {
                while (picPort.BytesToRead > 0)
                    ReceiveByte((byte)picPort.ReadByte());

                if (picWaiting && (DateTime.Now - picRequestTime).TotalMilliseconds > 500)
                {
                    adcFailures++;
                    ClosePIC();
                    this.Text = "PIC ADC timeout - check AN1 firmware support";
                    nextPICScan = DateTime.Now.AddSeconds(2);
                    return;
                }
                if (!picWaiting) RequestADC();
            }
            catch (Exception)
            {
                ClosePIC();
                this.Text = "PIC disconnected - reconnecting";
                nextPICScan = DateTime.Now.AddSeconds(2);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayPictureBox.Refresh();
            DisplayPictureBox.BackColor = Color.White;
            ShakeEtchOSketch();
        }

        private void DrawWavefomButton_Click(object sender, EventArgs e)
        {
            DisplayPictureBox.Refresh();
            DrawSineWave();
            DrawCosineWave();
            DrawTangentWave();
            DrawGrid();
        }

        private void SelectColorButton_Click(object sender, EventArgs e)
        {
            UpdatePenColor();
        }

        private void AboutStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is an EtchOSketch application, with basic drawing functionalities. \n" +
                "You can draw lines, select colors, and clear the screen. \n" +
                "This also allows a Sine, Cosine, and Tangent waves are drawn in different colors.");
        }
    }
}