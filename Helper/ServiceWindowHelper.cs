using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Helper
{
    static class ServiceWindowHelper
    {
        private static readonly RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static void Start(string nameApp)
        {
            if (String.IsNullOrEmpty(CheckReady(nameApp)))
            {
                rkApp.SetValue(nameApp, Application.ExecutablePath);
            }    
        }

        public static void Delete(string nameApp)
        {
            if(!String.IsNullOrEmpty(CheckReady(nameApp)))
            {
                rkApp.DeleteValue(nameApp, false);
            }
        }

        public static string CheckReady(string nameApp)
        {
            return rkApp.GetValue(nameApp)?.ToString();
        }
    }
}
