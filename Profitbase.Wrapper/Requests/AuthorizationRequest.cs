using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Parsers;

namespace Profitbase.Wrapper.Requests
{
    internal class AuthorizationRequest
    {
        private readonly IClient _client;
        public AuthorizationRequest(IClient client)
        {
            _client = client;
        }

        public async Task Execute(string login, string password)
        {
            var csrfToken = await GetCsrfToken();
        }

        private async Task<string> GetCsrfToken()
        {
            var content = await _client.ExecuteGetRequest(Routes.LoginPage);
            return new LoginPageToCsrfTokenParser().GetToken(content);
        }

    }
}
