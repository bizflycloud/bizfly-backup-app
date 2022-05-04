using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helper
{
    class JsonHelper
    {
        public static T ConvertToObject<T>(string json)
        {
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
    }
}
