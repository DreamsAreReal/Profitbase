using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Models;
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


        /// <summary>
        /// Get all sections and blocks from user
        /// </summary>
        /// <param name="login">Username</param>
        /// <param name="password">Password</param>
        /// <returns>All sections and blocks from user</returns>
        public async Task<List<SectionModel>> GetAllAsync(string login, string password)
        {
            AuthorizationRequest authorization = new AuthorizationRequest(_client);
            var apiData = await authorization.Execute(login,password);
            ProjectsRequest projectsRequest = new ProjectsRequest(_client);
            var houses = await projectsRequest.Execute(apiData);
            for (int i = 0; i < houses.Count; i++)
            {
                houses[i].Blocks = await new BlocksRequest(_client).Execute(apiData, houses[i].Id);
            }
            return houses;
            
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}