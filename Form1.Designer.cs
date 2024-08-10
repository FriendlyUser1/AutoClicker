namespace AutoClicker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trayIcon = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            trayOpen = new ToolStripMenuItem();
            trayExit = new ToolStripMenuItem();
            startButton = new Button();
            stopButton = new Button();
            speedControl = new NumericUpDown();
            textKeybind = new TextBox();
            reset = new Button();
            pictureBox1 = new PictureBox();
            KeybindLabel = new Label();
            MainExit = new Button();
            SpeedLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            changeKeybind = new Button();
            JitterLabel = new Label();
            jitterControl = new NumericUpDown();
            trayContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)speedControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jitterControl).BeginInit();
            SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = trayContextMenu;
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "AutoClicker";
            trayIcon.Visible = true;
            trayIcon.MouseClick += TrayIcon_MouseClick;
            // 
            // trayContextMenu
            // 
            trayContextMenu.Items.AddRange(new ToolStripItem[] { trayOpen, trayExit });
            trayContextMenu.Name = "trayContextMenu";
            trayContextMenu.Size = new Size(104, 48);
            // 
            // trayOpen
            // 
            trayOpen.Name = "trayOpen";
            trayOpen.Size = new Size(103, 22);
            trayOpen.Text = "Open";
            trayOpen.Click += TrayOpen_Click;
            // 
            // trayExit
            // 
            trayExit.Name = "trayExit";
            trayExit.Size = new Size(103, 22);
            trayExit.Text = "Exit";
            trayExit.Click += Exit_Handler;
            // 
            // startButton
            // 
            startButton.Location = new Point(12, 269);
            startButton.Name = "startButton";
            startButton.Size = new Size(180, 80);
            startButton.TabIndex = 0;
            startButton.Text = "Start (F6)";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButton_Click;
            // 
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(192, 269);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(180, 80);
            stopButton.TabIndex = 1;
            stopButton.Text = "Stop (F6)";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton_Click;
            // 
            // speedControl
            // 
            speedControl.Anchor = AnchorStyles.None;
            speedControl.Location = new Point(111, 175);
            speedControl.Margin = new Padding(0);
            speedControl.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            speedControl.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            speedControl.Name = "speedControl";
            speedControl.Size = new Size(165, 21);
            speedControl.TabIndex = 4;
            speedControl.Value = new decimal(new int[] { 100, 0, 0, 0 });
            speedControl.ValueChanged += SpeedControl_ValueChanged;
            speedControl.KeyDown += SpeedControl_KeyDown;
            // 
            // textKeybind
            // 
            textKeybind.Anchor = AnchorStyles.None;
            textKeybind.Enabled = false;
            textKeybind.Font = new Font("Hack", 9F);
            textKeybind.Location = new Point(111, 134);
            textKeybind.Margin = new Padding(0);
            textKeybind.Name = "textKeybind";
            textKeybind.ReadOnly = true;
            textKeybind.ShortcutsEnabled = false;
            textKeybind.Size = new Size(165, 21);
            textKeybind.TabIndex = 2;
            textKeybind.Text = "F6";
            textKeybind.TextChanged += TextKeybind_TextChanged;
            textKeybind.KeyDown += textKeybind_KeyDown;
            textKeybind.PreviewKeyDown += TextKeybind_PreviewKeyDown;
            // 
            // reset
            // 
            reset.Anchor = AnchorStyles.Top;
            tableLayoutPanel2.SetColumnSpan(reset, 2);
            reset.Location = new Point(129, 65);
            reset.Name = "reset";
            reset.Size = new Size(200, 55);
            reset.TabIndex = 1;
            reset.Text = "Reset Settings";
            reset.UseVisualStyleBackColor = true;
            reset.Click += Reset_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.cursor;
            pictureBox1.Location = new Point(5, 4);
            pictureBox1.Name = "pictureBox1";
            tableLayoutPanel2.SetRowSpan(pictureBox1, 2);
            pictureBox1.Size = new Size(88, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // KeybindLabel
            // 
            KeybindLabel.Anchor = AnchorStyles.Left;
            KeybindLabel.AutoSize = true;
            KeybindLabel.Font = new Font("Hack", 9F);
            KeybindLabel.Location = new Point(3, 137);
            KeybindLabel.Name = "KeybindLabel";
            KeybindLabel.Size = new Size(63, 14);
            KeybindLabel.TabIndex = 2;
            KeybindLabel.Text = "Keybind:";
            // 
            // MainExit
            // 
            MainExit.Anchor = AnchorStyles.Bottom;
            tableLayoutPanel2.SetColumnSpan(MainExit, 2);
            MainExit.Location = new Point(129, 4);
            MainExit.Name = "MainExit";
            MainExit.Size = new Size(200, 55);
            MainExit.TabIndex = 0;
            MainExit.Text = "Exit";
            MainExit.UseVisualStyleBackColor = true;
            MainExit.Click += Exit_Handler;
            // 
            // SpeedLabel
            // 
            SpeedLabel.Anchor = AnchorStyles.Left;
            SpeedLabel.AutoSize = true;
            SpeedLabel.Location = new Point(3, 178);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new Size(84, 14);
            SpeedLabel.TabIndex = 4;
            SpeedLabel.Text = "Speed (ms):";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.375F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.625F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel2.Controls.Add(textKeybind, 1, 2);
            tableLayoutPanel2.Controls.Add(KeybindLabel, 0, 2);
            tableLayoutPanel2.Controls.Add(MainExit, 1, 0);
            tableLayoutPanel2.Controls.Add(reset, 1, 1);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Controls.Add(speedControl, 1, 3);
            tableLayoutPanel2.Controls.Add(SpeedLabel, 0, 3);
            tableLayoutPanel2.Controls.Add(changeKeybind, 2, 2);
            tableLayoutPanel2.Controls.Add(JitterLabel, 0, 4);
            tableLayoutPanel2.Controls.Add(jitterControl, 1, 4);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0000019F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25.0000019F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel2.Size = new Size(360, 251);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // changeKeybind
            // 
            changeKeybind.Anchor = AnchorStyles.None;
            changeKeybind.Location = new Point(291, 133);
            changeKeybind.Name = "changeKeybind";
            changeKeybind.Size = new Size(66, 23);
            changeKeybind.TabIndex = 3;
            changeKeybind.Text = "Change";
            changeKeybind.UseVisualStyleBackColor = true;
            changeKeybind.Click += ChangeKeybind_Click;
            // 
            // JitterLabel
            // 
            JitterLabel.Anchor = AnchorStyles.Left;
            JitterLabel.AutoSize = true;
            JitterLabel.Location = new Point(3, 221);
            JitterLabel.Name = "JitterLabel";
            JitterLabel.Size = new Size(91, 14);
            JitterLabel.TabIndex = 5;
            JitterLabel.Text = "Jitter (ms):";
            // 
            // jitterControl
            // 
            jitterControl.Anchor = AnchorStyles.None;
            jitterControl.Location = new Point(111, 218);
            jitterControl.Margin = new Padding(0);
            jitterControl.Name = "jitterControl";
            jitterControl.Size = new Size(165, 21);
            jitterControl.TabIndex = 5;
            jitterControl.Value = new decimal(new int[] { 10, 0, 0, 0 });
            jitterControl.ValueChanged += JitterControl_ValueChanged;
            jitterControl.KeyDown += JitterControl_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Font = new Font("Hack", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AutoClicker";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            trayContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)speedControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jitterControl).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem trayOpen;
        private ToolStripMenuItem trayExit;
        private Button startButton;
        private Button stopButton;
        private NumericUpDown speedControl;
        private TextBox textKeybind;
        private Button reset;
        private PictureBox pictureBox1;
        private Label KeybindLabel;
        private Button MainExit;
        private Label SpeedLabel;
        private TableLayoutPanel tableLayoutPanel2;
        private Button changeKeybind;
        private Label JitterLabel;
        private NumericUpDown jitterControl;
    }
}
