using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BccMembers.Api.Client.Tests
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly HttpClient _client;

        public HttpClientFactory(HttpClient client = null)
        {
            this._client = client;
        }
        public HttpClient CreateClient(string name)
        {
            if (name == "oauth")
            {
                return new HttpClient();
            }
            return _client ?? new HttpClient();
        }
    }
}
