#region header

// MouseJiggle - MainForm.cs
// 
// Alistair J. R. Young
// Arkane Systems
// 
// Copyright Arkane Systems 2012-2013.
// 
// Created: 2013-08-24 12:41 PM

#endregion

using System;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using Microsoft.Win32;

namespace ArkaneSystems.MouseJiggle
{

    public partial class MainForm : Form
    {
        //don't move mouse if we've been using it in the last MIN_IDLE_TIME_SECONDS
        int MIN_IDLE_TIME_SECONDS = 5;
        //only jiggle for this long.  Then stop jiggling.  0 is "no timeout"
        const int JIGGLE_TIMEOUT_DEFAULT_MINUTES = 0;

        RegistryKey reg;
        const string ZEN_KEY = "Zen";
        const string TIMEOUT_KEY = "Timeout";
        const string ENABLED_KEY = "Enabled";

        public MainForm()
        {
            this.InitializeComponent();

            IKeyboardMouseEvents events = Hook.GlobalEvents();
            events.MouseMove += mouseActivityevent;
            events.MouseUp += mouseActivityevent;
        }

        private RegistryKey GetKey(string name)
        {
            string keyName = @"Software\Arkane Systems\" + name;
            return Registry.CurrentUser.CreateSubKey(keyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
        }

        DateTime lastMovement = DateTime.Now;
        private void mouseActivityevent(object sender, MouseEventArgs e)
        {
            Log.Debug("MouseMoved");
            lastMovement = DateTime.Now;
        }

        private void jiggleTimer_Tick(object sender, EventArgs e)
        {
            //don't jiggle if the mouse has moved lately. 
            if ((DateTime.Now - lastMovement).Seconds < MIN_IDLE_TIME_SECONDS)
                return;
            Log.Debug((DateTime.Now - lastMovement).Minutes.ToString() + " " + TimeoutMinutes.ToString());
            //don't jiggle if we're over the timeout limit. 
            if ((DateTime.Now - lastMovement).Minutes >= TimeoutMinutes)
                return;
                
            // jiggle
            if (this.chkZen.Checked)
            {
                Log.Debug("Zen");
                Jiggler.Jiggle(0, 0);
            }
            else
            {
                Log.Debug("Jiggling");
                Jiggler.Jiggle(4, 4);
                System.Threading.Thread.Sleep(10);
                Jiggler.Jiggle(-4, -4);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                reg = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree);
                this.chkZen.Checked = (int)reg.GetValue(ZEN_KEY, 0) == 0;
                this.chkEnabled.Checked = (int)reg.GetValue(ENABLED_KEY, 0) == 0;
                this.timeoutMinutes.Value = (int)reg.GetValue(TIMEOUT_KEY, JIGGLE_TIMEOUT_DEFAULT_MINUTES);
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            if (Program.ZenJiggling)
                this.chkZen.Checked = true;
            else if (Program.StartJiggling)
                this.chkEnabled.Checked = true;
            else if (Program.StartMinimized)
                this.cmdToTray_Click(this, null);
        }


        private void cmdToTray_Click(object sender, EventArgs e)
        {
            // minimize to tray
            this.Visible = false;
            // remove from taskbar
            this.ShowInTaskbar = false;
            // show tray icon
            this.trayIcon.Visible = true;
        }

        private void nifMin_DoubleClick(object sender, EventArgs e)
        {
            // restore the window
            this.Visible = true;
            // replace in taskbar
            this.ShowInTaskbar = true;
            // hide tray icon
            this.trayIcon.Visible = false;
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            try
            {
                reg.SetValue(ZEN_KEY, chkZen.Checked ? 1 : 0);
                reg.SetValue(ENABLED_KEY, chkEnabled.Checked ? 1 : 0);
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            this.jiggleTimer.Enabled = this.chkEnabled.Checked;
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem)) return;
            ToolStripMenuItem senderItem = (ToolStripMenuItem)sender;

            if (senderItem == this.itemExit)
            {
                Application.Exit();
            }
        }

        private int TimeoutMinutes
        {
            get
            {
                return (int)this.timeoutMinutes.Value;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            reg.SetValue(TIMEOUT_KEY, TimeoutMinutes);
        }
    }
}
