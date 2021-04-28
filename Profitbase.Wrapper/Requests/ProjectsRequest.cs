using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Models;

namespace Profitbase.Wrapper.Requests
{
    class ProjectsRequest
    {
        private readonly IClient _client;
        public ProjectsRequest(IClient client)
        {
            _client = client;
        }


        public async Task Execute(ApiDataModel apiData)
        {
            var data = new Dictionary<string, string>
            {
                {"pb_api_key", apiData.ApiKey},
                {"pb_subdomain", Routes.SubDomain},
                {"pb_user_api_key", apiData.UserApiKey},
                {"pb_username", apiData.Username}
            };

            var answer = await _client.ExecutePostRequest(Routes.ProjectsRequest, data);
            return;
            
        }
    }
}
