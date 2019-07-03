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
            this.cmdToTray = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.radOn = new System.Windows.Forms.RadioButton();
            this.radZen = new System.Windows.Forms.RadioButton();
            this.radOff = new System.Windows.Forms.RadioButton();
            this.ctxMenuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // jiggleTimer
            // 
            this.jiggleTimer.Interval = 1000;
            this.jiggleTimer.Tick += new System.EventHandler(this.jiggleTimer_Tick);
            // 
            // cmdToTray
            // 
            this.cmdToTray.Image = ((System.Drawing.Image)(resources.GetObject("cmdToTray.Image")));
            this.cmdToTray.Location = new System.Drawing.Point(111, 32);
            this.cmdToTray.Name = "cmdToTray";
            this.cmdToTray.Size = new System.Drawing.Size(33, 23);
            this.cmdToTray.TabIndex = 3;
            this.cmdToTray.UseVisualStyleBackColor = true;
            this.cmdToTray.Click += new System.EventHandler(this.cmdToTray_Click);
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
            // radOn
            // 
            this.radOn.AutoSize = true;
            this.radOn.Location = new System.Drawing.Point(3, 1);
            this.radOn.Name = "radOn";
            this.radOn.Size = new System.Drawing.Size(39, 17);
            this.radOn.TabIndex = 4;
            this.radOn.TabStop = true;
            this.radOn.Text = "On";
            this.radOn.UseVisualStyleBackColor = true;
            this.radOn.CheckedChanged += new System.EventHandler(this.checkedChanged);
            // 
            // radZen
            // 
            this.radZen.AutoSize = true;
            this.radZen.Location = new System.Drawing.Point(3, 21);
            this.radZen.Name = "radZen";
            this.radZen.Size = new System.Drawing.Size(44, 17);
            this.radZen.TabIndex = 5;
            this.radZen.TabStop = true;
            this.radZen.Text = "Zen";
            this.radZen.UseVisualStyleBackColor = true;
            this.radZen.CheckedChanged += new System.EventHandler(this.checkedChanged);
            // 
            // radOff
            // 
            this.radOff.AutoSize = true;
            this.radOff.Location = new System.Drawing.Point(3, 40);
            this.radOff.Name = "radOff";
            this.radOff.Size = new System.Drawing.Size(39, 17);
            this.radOff.TabIndex = 6;
            this.radOff.TabStop = true;
            this.radOff.Text = "Off";
            this.radOff.UseVisualStyleBackColor = true;
            this.radOff.CheckedChanged += new System.EventHandler(this.checkedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 59);
            this.Controls.Add(this.radOff);
            this.Controls.Add(this.radZen);
            this.Controls.Add(this.radOn);
            this.Controls.Add(this.cmdToTray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(172, 98);
            this.MinimumSize = new System.Drawing.Size(172, 98);
            this.Name = "MainForm";
            this.Text = "MouseJiggle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctxMenuTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer jiggleTimer;
        private System.Windows.Forms.Button cmdToTray;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.RadioButton radOn;
        private System.Windows.Forms.RadioButton radZen;
        private System.Windows.Forms.RadioButton radOff;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTray;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
    }
}

