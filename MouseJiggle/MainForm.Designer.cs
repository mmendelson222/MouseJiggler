namespace ArkaneSystems.MouseJiggle
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.jiggleTimer = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timeoutMinutes = new System.Windows.Forms.NumericUpDown();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkZen = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTimeoutMinutes = new System.Windows.Forms.Label();
            this.ctxMenuTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 1000;
            this.jiggleTimer.Tick += new System.EventHandler(this.jiggleTimer_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.ctxMenuTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Mouse Jiggler";
            this.trayIcon.DoubleClick += new System.EventHandler(this.nifMin_DoubleClick);
            // 
            // ctxMenuTray
            // 
            this.ctxMenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemExit});
            this.ctxMenuTray.Name = "ctxMenuTray";
            this.ctxMenuTray.Size = new System.Drawing.Size(93, 26);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(92, 22);
            this.itemExit.Text = "E&xit";
            this.itemExit.Click += new System.EventHandler(this.item_Click);
            // 
            // timeoutMinutes
            // 
            this.timeoutMinutes.Location = new System.Drawing.Point(21, 53);
            this.timeoutMinutes.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.timeoutMinutes.Name = "timeoutMinutes";
            this.timeoutMinutes.Size = new System.Drawing.Size(45, 20);
            this.timeoutMinutes.TabIndex = 7;
            this.timeoutMinutes.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(21, 6);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 8;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.enabledCheckedChanged);
            // 
            // chkZen
            // 
            this.chkZen.AutoSize = true;
            this.chkZen.Location = new System.Drawing.Point(21, 30);
            this.chkZen.Name = "chkZen";
            this.chkZen.Size = new System.Drawing.Size(45, 17);
            this.chkZen.TabIndex = 9;
            this.chkZen.Text = "Zen";
            this.chkZen.UseVisualStyleBackColor = true;
            this.chkZen.CheckedChanged += new System.EventHandler(this.zenCheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "taskbar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmdToTray_Click);
            // 
            // lblTimeoutMinutes
            // 
            this.lblTimeoutMinutes.AutoSize = true;
            this.lblTimeoutMinutes.Location = new System.Drawing.Point(72, 55);
            this.lblTimeoutMinutes.Name = "lblTimeoutMinutes";
            this.lblTimeoutMinutes.Size = new System.Drawing.Size(64, 13);
            this.lblTimeoutMinutes.TabIndex = 11;
            this.lblTimeoutMinutes.Text = "Timout (min)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 134);
            this.Controls.Add(this.lblTimeoutMinutes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkZen);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.timeoutMinutes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(172, 173);
            this.MinimumSize = new System.Drawing.Size(172, 173);
            this.Name = "MainForm";
            this.Text = "MouseJiggle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctxMenuTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTray;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.NumericUpDown timeoutMinutes;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkZen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTimeoutMinutes;
    }
}

