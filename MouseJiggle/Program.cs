using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArkaneSystems.MouseJiggle
{
    static class Program
    {
        public static bool startJiggling = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Check for command-line switch.
            if
                (
                    (args.Length > 0) &&
                    (
                        (args[0].ToLowerInvariant().CompareTo("--jiggle") == 0) ||
                        (args[0].ToLowerInvariant().CompareTo("-j") == 0)
                    )
                )
            {
                startJiggling = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
