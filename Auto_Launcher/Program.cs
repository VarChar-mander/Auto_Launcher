using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Auto_Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Form1();
            //Application.Run(new Form1());
        }
    }
}
