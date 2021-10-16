using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;

namespace Auto_Launcher
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        public Form1()
        {
            try
            {
                InitializeComponent();
                Process cmd = new Process();
                ProcessStartInfo info = new ProcessStartInfo(@ConfigurationManager.AppSettings.Get("program").ToString(), @ConfigurationManager.AppSettings.Get("address").ToString());
                cmd.StartInfo = info;
                cmd.Start();
                cmd.WaitForInputIdle();
                IntPtr p = cmd.MainWindowHandle;
                SetForegroundWindow(p);
                //cmd.WaitForInputIdle();
                int sleep = 0;
                if (@ConfigurationManager.AppSettings.Get("sleep").ToString().Length > 0)
                    sleep = System.Convert.ToInt32(@ConfigurationManager.AppSettings.Get("sleep").ToString());
                System.Threading.Thread.Sleep(sleep);
                SendKeys.Flush();
                if (@ConfigurationManager.AppSettings.Get("username").ToString().Length > 0 & @ConfigurationManager.AppSettings.Get("password").ToString().Length > 0)
                {
                    SendKeys.SendWait(@ConfigurationManager.AppSettings.Get("username").ToString());
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait(@ConfigurationManager.AppSettings.Get("password").ToString());
                    SendKeys.SendWait("{ENTER}");
                }
                if (@ConfigurationManager.AppSettings.Get("otherInput").ToString().Length > 0)
                    SendKeys.SendWait(@ConfigurationManager.AppSettings.Get("otherInput").ToString());
                SendKeys.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            this.Close();
        }

    }
}
