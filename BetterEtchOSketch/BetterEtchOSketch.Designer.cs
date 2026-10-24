namespace BetterEtchOSketch
{
    partial class BetterEtchOSketch
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DisplayPictureBox = new PictureBox();
            ExitButton = new Button();
            SelectColorButton = new Button();
            DrawWaveformButton = new Button();
            ClearButton = new Button();
            DisplayContextMenuStrip = new ContextMenuStrip(components);
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            ExitStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem1 = new ToolStripMenuItem();
            SelectColorStripMenuItem = new ToolStripMenuItem();
            DrawWaveformStripMenuItem = new ToolStripMenuItem();
            ClearStripMenuItem = new ToolStripMenuItem();
            HelpStripMenuItem = new ToolStripMenuItem();
            AboutStripMenuItem = new ToolStripMenuItem();
            PenColorDialog = new ColorDialog();
            DisplayToolTip = new ToolTip(components);
            DisplayMainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            ExitMainStripItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            SelectColorMainStripItem = new ToolStripMenuItem();
            DrawWaveformMainStripItem = new ToolStripMenuItem();
            ClearMainStripItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            AboutMainStripItem = new ToolStripMenuItem();
            MouseRadioButton = new RadioButton();
            ExternalRadioButton = new RadioButton();
            PortsComboBox = new ComboBox();
            PICTimer = new System.Windows.Forms.Timer(components);
            PicStatuslabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).BeginInit();
            DisplayContextMenuStrip.SuspendLayout();
            DisplayMainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayPictureBox
            // 
            DisplayPictureBox.BackColor = Color.White;
            DisplayPictureBox.Location = new Point(12, 32);
            DisplayPictureBox.Name = "DisplayPictureBox";
            DisplayPictureBox.Size = new Size(776, 342);
            DisplayPictureBox.TabIndex = 0;
            DisplayPictureBox.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(694, 380);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(94, 58);
            ExitButton.TabIndex = 6;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // SelectColorButton
            // 
            SelectColorButton.Location = new Point(394, 380);
            SelectColorButton.Name = "SelectColorButton";
            SelectColorButton.Size = new Size(94, 58);
            SelectColorButton.TabIndex = 3;
            SelectColorButton.Text = "Select Color";
            SelectColorButton.UseVisualStyleBackColor = true;
            SelectColorButton.Click += SelectColorButton_Click;
            // 
            // DrawWaveformButton
            // 
            DrawWaveformButton.Location = new Point(494, 380);
            DrawWaveformButton.Name = "DrawWaveformButton";
            DrawWaveformButton.Size = new Size(94, 58);
            DrawWaveformButton.TabIndex = 4;
            DrawWaveformButton.Text = "Draw Waveform";
            DrawWaveformButton.UseVisualStyleBackColor = true;
            DrawWaveformButton.Click += DrawWavefomButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(594, 380);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(94, 58);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // DisplayContextMenuStrip
            // 
            DisplayContextMenuStrip.ImageScalingSize = new Size(20, 20);
            DisplayContextMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, editToolStripMenuItem1, HelpStripMenuItem });
            DisplayContextMenuStrip.Name = "DisplayContextMenuStrip";
            DisplayContextMenuStrip.Size = new Size(111, 76);
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ExitStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(110, 24);
            fileToolStripMenuItem1.Text = "File";
            // 
            // ExitStripMenuItem
            // 
            ExitStripMenuItem.Name = "ExitStripMenuItem";
            ExitStripMenuItem.Size = new Size(116, 26);
            ExitStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { SelectColorStripMenuItem, DrawWaveformStripMenuItem, ClearStripMenuItem });
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            editToolStripMenuItem1.Size = new Size(110, 24);
            editToolStripMenuItem1.Text = "Edit";
            // 
            // SelectColorStripMenuItem
            // 
            SelectColorStripMenuItem.Name = "SelectColorStripMenuItem";
            SelectColorStripMenuItem.Size = new Size(199, 26);
            SelectColorStripMenuItem.Text = "Select Color";
            // 
            // DrawWaveformStripMenuItem
            // 
            DrawWaveformStripMenuItem.Name = "DrawWaveformStripMenuItem";
            DrawWaveformStripMenuItem.Size = new Size(199, 26);
            DrawWaveformStripMenuItem.Text = "Draw Waveform";
            // 
            // ClearStripMenuItem
            // 
            ClearStripMenuItem.Name = "ClearStripMenuItem";
            ClearStripMenuItem.Size = new Size(199, 26);
            ClearStripMenuItem.Text = "Clear";
            // 
            // HelpStripMenuItem
            // 
            HelpStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutStripMenuItem });
            HelpStripMenuItem.Name = "HelpStripMenuItem";
            HelpStripMenuItem.Size = new Size(110, 24);
            HelpStripMenuItem.Text = "Help";
            // 
            // AboutStripMenuItem
            // 
            AboutStripMenuItem.Name = "AboutStripMenuItem";
            AboutStripMenuItem.Size = new Size(133, 26);
            AboutStripMenuItem.Text = "About";
            // 
            // DisplayMainMenuStrip
            // 
            DisplayMainMenuStrip.ImageScalingSize = new Size(20, 20);
            DisplayMainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            DisplayMainMenuStrip.Location = new Point(0, 0);
            DisplayMainMenuStrip.Name = "DisplayMainMenuStrip";
            DisplayMainMenuStrip.Size = new Size(800, 28);
            DisplayMainMenuStrip.TabIndex = 7;
            DisplayMainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExitMainStripItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // ExitMainStripItem
            // 
            ExitMainStripItem.Name = "ExitMainStripItem";
            ExitMainStripItem.Size = new Size(116, 26);
            ExitMainStripItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SelectColorMainStripItem, DrawWaveformMainStripItem, ClearMainStripItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // SelectColorMainStripItem
            // 
            SelectColorMainStripItem.Name = "SelectColorMainStripItem";
            SelectColorMainStripItem.Size = new Size(199, 26);
            SelectColorMainStripItem.Text = "Select Color";
            // 
            // DrawWaveformMainStripItem
            // 
            DrawWaveformMainStripItem.Name = "DrawWaveformMainStripItem";
            DrawWaveformMainStripItem.Size = new Size(199, 26);
            DrawWaveformMainStripItem.Text = "Draw Waveform";
            // 
            // ClearMainStripItem
            // 
            ClearMainStripItem.Name = "ClearMainStripItem";
            ClearMainStripItem.Size = new Size(199, 26);
            ClearMainStripItem.Text = "Clear";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutMainStripItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // AboutMainStripItem
            // 
            AboutMainStripItem.Name = "AboutMainStripItem";
            AboutMainStripItem.Size = new Size(133, 26);
            AboutMainStripItem.Text = "About";
            AboutMainStripItem.Click += AboutMainStripItem_Click;
            // 
            // MouseRadioButton
            // 
            MouseRadioButton.AutoSize = true;
            MouseRadioButton.Location = new Point(234, 414);
            MouseRadioButton.Name = "MouseRadioButton";
            MouseRadioButton.Size = new Size(118, 24);
            MouseRadioButton.TabIndex = 1;
            MouseRadioButton.TabStop = true;
            MouseRadioButton.Text = "Mouse Select";
            MouseRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExternalRadioButton
            // 
            ExternalRadioButton.AutoSize = true;
            ExternalRadioButton.Location = new Point(234, 384);
            ExternalRadioButton.Name = "ExternalRadioButton";
            ExternalRadioButton.Size = new Size(127, 24);
            ExternalRadioButton.TabIndex = 2;
            ExternalRadioButton.TabStop = true;
            ExternalRadioButton.Text = "External Select";
            ExternalRadioButton.UseVisualStyleBackColor = true;
            // 
            // PortsComboBox
            // 
            PortsComboBox.FormattingEnabled = true;
            PortsComboBox.Location = new Point(12, 380);
            PortsComboBox.Name = "PortsComboBox";
            PortsComboBox.Size = new Size(190, 28);
            PortsComboBox.TabIndex = 10;
            // 
            // PICTimer
            // 
            PICTimer.Interval = 50;
            // 
            // PicStatuslabel
            // 
            PicStatuslabel.AutoSize = true;
            PicStatuslabel.Location = new Point(12, 416);
            PicStatuslabel.Name = "PicStatuslabel";
            PicStatuslabel.Size = new Size(74, 20);
            PicStatuslabel.TabIndex = 11;
            PicStatuslabel.Text = "PIC Status";
            // 
            // BetterEtchOSketch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PicStatuslabel);
            Controls.Add(PortsComboBox);
            Controls.Add(ExternalRadioButton);
            Controls.Add(MouseRadioButton);
            Controls.Add(DisplayMainMenuStrip);
            Controls.Add(ClearButton);
            Controls.Add(DrawWaveformButton);
            Controls.Add(SelectColorButton);
            Controls.Add(ExitButton);
            Controls.Add(DisplayPictureBox);
            MainMenuStrip = DisplayMainMenuStrip;
            Name = "BetterEtchOSketch";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).EndInit();
            DisplayContextMenuStrip.ResumeLayout(false);
            DisplayMainMenuStrip.ResumeLayout(false);
            DisplayMainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AboutMainStripItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox DisplayPictureBox;
        private Button ExitButton;
        private Button SelectColorButton;
        private Button DrawWaveformButton;
        private Button ClearButton;
        private ContextMenuStrip DisplayContextMenuStrip;
        private ColorDialog PenColorDialog;
        private ToolTip DisplayToolTip;
        private MenuStrip DisplayMainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem ExitMainStripItem;
        private ToolStripMenuItem SelectColorMainStripItem;
        private ToolStripMenuItem DrawWaveformMainStripItem;
        private ToolStripMenuItem ClearMainStripItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem AboutMainStripItem;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem ExitStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem1;
        private ToolStripMenuItem SelectColorStripMenuItem;
        private ToolStripMenuItem DrawWaveformStripMenuItem;
        private ToolStripMenuItem ClearStripMenuItem;
        private ToolStripMenuItem HelpStripMenuItem;
        private ToolStripMenuItem AboutStripMenuItem;
        private RadioButton MouseRadioButton;
        private RadioButton ExternalRadioButton;
        private ComboBox PortsComboBox;
        private System.Windows.Forms.Timer PICTimer;
        private Label PicStatuslabel;
    }
}
