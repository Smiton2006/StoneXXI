using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoneXXI.Clients
{
    public class CbrHttpClient
    {
        private readonly HttpClient _client;

        public CbrHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://www.cbr.ru");
            _client = client;
        }
    }
}
