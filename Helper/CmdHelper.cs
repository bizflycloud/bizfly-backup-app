using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Test.Helper
{
    class CmdHelper
    {
        public static void Command(string fileName, string param = "", bool isAdmin = false)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.Arguments = param;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }
    }
}
