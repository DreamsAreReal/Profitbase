using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Requests;

namespace Profitbase.Wrapper
{
    public class Api : IDisposable
    {
        private readonly IClient _client;

        /// <summary>
        /// Create new API client.
        /// </summary>
        /// <param name="proxy">Need IPV4 Https proxy.</param>
        public Api(IWebProxy proxy = null)
        {
            _client = new Client();
        }


        public async Task GetAllAsync(string login, string password)
        {
            AuthorizationRequest authorization = new AuthorizationRequest(_client);
            var data = await authorization.Execute(login,password);
            return;
            
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}