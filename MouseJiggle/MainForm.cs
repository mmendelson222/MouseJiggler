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
        int MIN_IDLE_TIME_SECONDS = 30;

        public MainForm()
        {
            this.InitializeComponent();

            IKeyboardMouseEvents events = Hook.GlobalEvents();
            events.MouseMove += mouseActivityevent;
            events.MouseUp += mouseActivityevent;
        }


        DateTime lastMovement = DateTime.Now;
        private void mouseActivityevent(object sender, MouseEventArgs e)
        {
            Log.Debug("MouseMoved");
            lastMovement = DateTime.Now;
        }

        private void jiggleTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastMovement).Seconds < MIN_IDLE_TIME_SECONDS)
                return;
            
            // jiggle
            if (this.radZen.Checked)
            {
                Log.Debug("Zening");
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
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree);
                var zen = (int)key.GetValue("ZenJiggleEnabled", 0);
                if (zen == 0)
                    this.radZen.Checked = true;
                else
                    this.radOn.Checked = true;
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            if (Program.ZenJiggling)
                this.radZen.Checked = true;
            else if (Program.StartJiggling)
                this.radOn.Checked = true;
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
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (this.radZen.Checked)
                    key.SetValue("ZenJiggleEnabled", 1);
                else
                    key.SetValue("ZenJiggleEnabled", 0);
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            this.jiggleTimer.Enabled = !this.radOff.Checked;
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
    }
}
