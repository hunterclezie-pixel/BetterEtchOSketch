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
            PenColorDialog = new ColorDialog();
            DisplayToolTip = new ToolTip(components);
            DisplayMainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            ExitMainStripItem = new ToolStripMenuItem();
            SelectColorMainStripItem = new ToolStripMenuItem();
            DrawWaveformMainStripItem = new ToolStripMenuItem();
            ClearMainStripItem = new ToolStripMenuItem();
            AboutMainStripItem = new ToolStripMenuItem();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            editToolStripMenuItem1 = new ToolStripMenuItem();
            HelpStripMenuItem = new ToolStripMenuItem();
            ExitStripMenuItem = new ToolStripMenuItem();
            SelectColorStripMenuItem = new ToolStripMenuItem();
            DrawWaveformStripMenuItem = new ToolStripMenuItem();
            ClearStripMenuItem = new ToolStripMenuItem();
            AboutStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)DisplayPictureBox).BeginInit();
            DisplayContextMenuStrip.SuspendLayout();
            DisplayMainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // DisplayPictureBox
            // 
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
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            // 
            // SelectColorButton
            // 
            SelectColorButton.Location = new Point(394, 380);
            SelectColorButton.Name = "SelectColorButton";
            SelectColorButton.Size = new Size(94, 58);
            SelectColorButton.TabIndex = 2;
            SelectColorButton.Text = "Select Color";
            SelectColorButton.UseVisualStyleBackColor = true;
            // 
            // DrawWaveformButton
            // 
            DrawWaveformButton.Location = new Point(494, 380);
            DrawWaveformButton.Name = "DrawWaveformButton";
            DrawWaveformButton.Size = new Size(94, 58);
            DrawWaveformButton.TabIndex = 3;
            DrawWaveformButton.Text = "Draw Waveform";
            DrawWaveformButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(594, 380);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(94, 58);
            ClearButton.TabIndex = 4;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            // 
            // DisplayContextMenuStrip
            // 
            DisplayContextMenuStrip.ImageScalingSize = new Size(20, 20);
            DisplayContextMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, editToolStripMenuItem1, HelpStripMenuItem });
            DisplayContextMenuStrip.Name = "DisplayContextMenuStrip";
            DisplayContextMenuStrip.Size = new Size(211, 104);
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
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SelectColorMainStripItem, DrawWaveformMainStripItem, ClearMainStripItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutMainStripItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "Help";
            // 
            // ExitMainStripItem
            // 
            ExitMainStripItem.Name = "ExitMainStripItem";
            ExitMainStripItem.Size = new Size(224, 26);
            ExitMainStripItem.Text = "Exit";
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
            // AboutMainStripItem
            // 
            AboutMainStripItem.Name = "AboutMainStripItem";
            AboutMainStripItem.Size = new Size(224, 26);
            AboutMainStripItem.Text = "About";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ExitStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(210, 24);
            fileToolStripMenuItem1.Text = "File";
            // 
            // editToolStripMenuItem1
            // 
            editToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { SelectColorStripMenuItem, DrawWaveformStripMenuItem, ClearStripMenuItem });
            editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            editToolStripMenuItem1.Size = new Size(210, 24);
            editToolStripMenuItem1.Text = "Edit";
            // 
            // HelpStripMenuItem
            // 
            HelpStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutStripMenuItem });
            HelpStripMenuItem.Name = "HelpStripMenuItem";
            HelpStripMenuItem.Size = new Size(210, 24);
            HelpStripMenuItem.Text = "Help";
            // 
            // ExitStripMenuItem
            // 
            ExitStripMenuItem.Name = "ExitStripMenuItem";
            ExitStripMenuItem.Size = new Size(224, 26);
            ExitStripMenuItem.Text = "Exit";
            // 
            // SelectColorStripMenuItem
            // 
            SelectColorStripMenuItem.Name = "SelectColorStripMenuItem";
            SelectColorStripMenuItem.Size = new Size(224, 26);
            SelectColorStripMenuItem.Text = "Select Color";
            // 
            // DrawWaveformStripMenuItem
            // 
            DrawWaveformStripMenuItem.Name = "DrawWaveformStripMenuItem";
            DrawWaveformStripMenuItem.Size = new Size(224, 26);
            DrawWaveformStripMenuItem.Text = "Draw Waveform";
            // 
            // ClearStripMenuItem
            // 
            ClearStripMenuItem.Name = "ClearStripMenuItem";
            ClearStripMenuItem.Size = new Size(224, 26);
            ClearStripMenuItem.Text = "Clear";
            // 
            // AboutStripMenuItem
            // 
            AboutStripMenuItem.Name = "AboutStripMenuItem";
            AboutStripMenuItem.Size = new Size(224, 26);
            AboutStripMenuItem.Text = "About";
            // 
            // BetterEtchOSketch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
