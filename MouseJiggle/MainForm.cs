using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            if (zig)
            {
                Jiggler.Jiggle(4, 4);
            }
            else // zag
            {
                // I really don't know why this needs to be less to stay in the same
                // place; if I was likely to use it again, then I'd worry.
                Jiggler.Jiggle(-3, -3);
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
    }
}
