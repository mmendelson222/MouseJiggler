using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkaneSystems.MouseJiggle
{
    internal static class Log
    {
        static internal void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0:HH:mm:ss} {1}", DateTime.Now, message));
        }
    }
}
