using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArkaneSystems.MouseJiggle
{
    static class Program
    {
        public static bool StartJiggling = false;
        public static bool ZenJiggling = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Check for command-line switches.
            foreach (string arg in args)
            {
                if ((System.String.Compare(arg.ToUpperInvariant(), "--JIGGLE", System.StringComparison.Ordinal) == 0) ||
                    (System.String.Compare(arg.ToUpperInvariant(), "-J", System.StringComparison.Ordinal) == 0))
                    StartJiggling = true;

                if ((System.String.Compare(arg.ToUpperInvariant(), "--ZEN", System.StringComparison.Ordinal) == 0) ||
                    (System.String.Compare(arg.ToUpperInvariant(), "-Z", System.StringComparison.Ordinal) == 0))
                    ZenJiggling = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
