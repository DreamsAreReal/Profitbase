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
            var data 
        }
    }
}
