using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helper
{
    class HttpClientHelper
    {
        private static HttpClient _client = new HttpClient();

        public async Task<string> Get(string url)
        {
            return await _client.GetStringAsync(url);
        }
    }
}
