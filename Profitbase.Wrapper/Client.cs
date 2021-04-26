using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Profitbase.Wrapper
{
    internal class Client
    {
        private readonly HttpClient _client;

        private const string UserAgent =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";

        /// <summary>
        /// Create new HttpClient.
        /// </summary>
        /// <param name="proxy">Need IPV4 Https proxy.</param>
        public Client(IWebProxy proxy = null)
        {
            var cookie = new CookieContainer();
            var handler = new HttpClientHandler { UseCookies = true };

            if (proxy != null)
            {
                handler.UseProxy = true;
                handler.Proxy = proxy;
            }

            var userAgentHeaderName = "user-agent";
            _client = new HttpClient(handler);
            _client.DefaultRequestHeaders.Add(userAgentHeaderName, UserAgent);
        }



    }
}