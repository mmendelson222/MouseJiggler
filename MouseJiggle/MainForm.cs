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
        int MIN_IDLE_TIME_SECONDS = 15;
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
            //Log.Debug("MouseMoved");
            lastMovement = DateTime.Now;
        }

        private void jiggleTimer_Tick(object sender, EventArgs e)
        {
            //don't jiggle if the mouse has moved lately. 
            if ((DateTime.Now - lastMovement).TotalSeconds < MIN_IDLE_TIME_SECONDS)
            {
                Log.Debug("mouse movement wait period");
                return;
            }

            Log.Debug((DateTime.Now - lastMovement).TotalMinutes.ToString() + " " + TimeoutMinutes.ToString());
            //don't jiggle if we're over the timeout limit.   0 means we're not using timeout
            if (TimeoutMinutes > 0)
            {
                if ((DateTime.Now - lastMovement).TotalMinutes >= TimeoutMinutes)
                {
                    Log.Debug("time limit exceeded");
                    return;
                }
            }

            try
            {
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
            catch (Exception)
            {
                //authorization exception might occur;  unusre why. 
                //Log.Debug(ex.Message);
                //Log.Debug(ex.StackTrace);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                reg = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree);
                this.chkZen.Checked = (int)reg.GetValue(ZEN_KEY, 0) == 1;
                this.chkEnabled.Checked = (int)reg.GetValue(ENABLED_KEY, 0) == 1;
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
            this.ShowInTaskbar = false;
            this.trayIcon.Visible = true;
            Hide();
        }

        private void desktopIcon_click(object sender, MouseEventArgs e)
        {
            show();
        }
        private void desktopicon_doubleclick(object sender, EventArgs e)
        {
            show();
        }
        private void show()
        {
            // restore the window
            this.ShowInTaskbar = true;
            this.trayIcon.Visible = false;
            Show();
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

        private void zenCheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue(ZEN_KEY, chkZen.Checked ? 1 : 0);
        }

        private void enabledCheckedChanged(object sender, EventArgs e)
        {
            reg.SetValue(ENABLED_KEY, chkEnabled.Checked ? 1 : 0);
            this.jiggleTimer.Enabled = this.chkEnabled.Checked;
        }

    }
}
