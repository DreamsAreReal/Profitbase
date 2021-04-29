using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profitbase.Wrapper.Models;
using Profitbase.Wrapper.Parsers;

namespace Profitbase.Wrapper.Requests
{
    class BlocksRequest
    {
        private readonly IClient _client;
        public BlocksRequest(IClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Get block information
        /// </summary>
        /// <param name="apiData">Api data for user</param>
        /// <returns>List block models</returns>
        public async Task<List<BlockModel>> Execute(ApiDataModel apiData, string id)
        {
            var data = new Dictionary<string, string>
            {
                {"pb_api_key", apiData.ApiKey},
                {"pb_subdomain", Routes.SubDomain},
                {"pb_user_api_key", apiData.UserApiKey},
                {"pb_username", apiData.Username}
            };

            var answer = await _client.ExecutePostRequest(Routes.BlocksRequest + id, data);
            return new BlocksRequestParser().GetBlocks(answer);

        }
    }
}
