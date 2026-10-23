namespace BetterEtchOSketch
{
    public partial class BetterEtchOSketch : Form
    {
        public BetterEtchOSketch()
        {
            InitializeComponent();
            DisplayPictureBox.MouseMove += DisplayPictureBox_MouseStuff;
            DisplayPictureBox.MouseDown += DisplayPictureBox_MouseStuff;

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
        }

        //Global Variables below here --------------------------------------------------------------

        private int oldX, oldY;
        private Color penColor = Color.Black;
        private Color backColor = Color.White;
        private int penSize = 1;

        //Custom Methids below here --------------------------------------------------------------

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

        // Handles mouse movement and clicks on the picture box for drawing and showing the context menu
        private void DisplayPictureBox_MouseStuff(object? sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    DrawLineSegment(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    DisplayContextMenuStrip.Show(DisplayPictureBox, e.Location);
                    break;
                case MouseButtons.Middle:
                    UpdateBackgroundColor();
                    break;
                default:
                    break;
            }

            //Update last position on every move
            this.oldX = e.X;
            this.oldY = e.Y;
            this.Text = $"{e.X},{e.Y}";
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

        //Event Handlers below here --------------------------------------------------------------

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