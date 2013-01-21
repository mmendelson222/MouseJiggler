using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace ArkaneSystems.MouseJiggle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        const int MOUSEMOVE = 8 ;

        protected bool zig = true ;

        private void jiggleTimer_Tick(object sender, EventArgs e)
        {
            // jiggle
            if (cbZenJiggle.Checked)
            {
                Jiggler.Jiggle(0, 0);
            }
            else
            {
                if (zig)
                {
                    Jiggler.Jiggle(4, 4);
                }
                else // zag
                {
                    // I really don't know why this needs to be less to stay in the same
                    // place; if I was likely to use it again, then I'd worry.
                    Jiggler.Jiggle(-4, -4);
                }
            }

            zig = !zig;
        }

        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            jiggleTimer.Enabled = cbEnabled.Checked;
        }

        private void cmdAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox a = new AboutBox())
            {
                a.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey (@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree) ;
                int zen = (int) key.GetValue("ZenJiggleEnabled", 0);

                if (zen == 0)
                    cbZenJiggle.Checked = false;
                else
                    cbZenJiggle.Checked = true;
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }

            if (Program.ZenJiggling)
            {
                cbZenJiggle.Checked = true;
            }

            if (Program.StartJiggling)
            {
                cbEnabled.Checked = true;
            }
        }

        private void cbZenJiggle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Arkane Systems\MouseJiggle", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (cbZenJiggle.Checked)
                    key.SetValue("ZenJiggleEnabled", 1);
                else
                    key.SetValue("ZenJiggleEnabled", 0);
            }
            catch (Exception)
            {
                // Ignore any problems - non-critical operation.
            }
        }

        private void cmdToTray_Click(object sender, EventArgs e)
        {
            // minimize to tray
            this.Visible = false;

            // remove from taskbar
            this.ShowInTaskbar = false;

            // show tray icon
            nifMin.Visible = true;
        }

        private void nifMin_DoubleClick(object sender, EventArgs e)
        {
            // restore the window
            this.Visible = true;

            // replace in taskbar
            this.ShowInTaskbar = true;

            // hide tray icon
            nifMin.Visible = false;
        }
    }
}
