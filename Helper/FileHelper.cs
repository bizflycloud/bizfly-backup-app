using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helper
{
    class FileHelper
    {
        public static List<string> GetAllFileInFoler(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.exe");
            List<string> nameFile = new List<string>();

            foreach (FileInfo file in Files)
            {
                nameFile.Add(file.FullName);
            }

            return nameFile;
        }

        public static List<string> ReadFileToList(string path)
        {
            List<string> allLinesText = new List<string>();
            if (File.Exists(path))
            {
                allLinesText = File.ReadAllLines(path).ToList();
            }

            return allLinesText;
        }

        public static void WriteFile(string path, string data)
        {
            File.WriteAllText(path, data + Environment.NewLine);
        }
    }
}
