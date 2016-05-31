using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZIPer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Calling functions
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Compressor());
        }
    }
}
