using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Linux
    {
        public string _386 { get; set; }
        public string amd64 { get; set; }
        public string arm64 { get; set; }
        public string armv6 { get; set; }
    }

    public class Macos
    {
        public string amd64 { get; set; }
    }

    public class Windows
    {
        public string _386 { get; set; }
        public string amd64 { get; set; }
    }

    public class TypeSystemModel
    {
        public string lastest_version { get; set; }
        public Linux linux { get; set; }
        public Macos macos { get; set; }
        public Windows windows { get; set; }
    }
}
