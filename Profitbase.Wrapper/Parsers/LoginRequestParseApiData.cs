using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Profitbase.Wrapper.Exceptions;
using Profitbase.Wrapper.Models;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginRequestParseApiData
    {
        private const string IframeDataPattern = "src=\"\\/\\/widget\\.profitbase\\.ru\\?(.*)\"";

        /// <summary>
        /// Parse api data from iframe
        /// </summary>
        /// <param name="page">Main page, after login page</param>
        /// <returns>Api data includes api keys</returns>
        public ApiDataModel GetData(string page)
        {
            var data = new Regex(IframeDataPattern).Match(page)?.Groups[1]?.Value;

            if (string.IsNullOrEmpty(data))
                throw new ApiDataParseException(page);

            var dataArr = data.Split(';');

            if (dataArr.Length != 8)
                throw new ApiDataParseException(page);

            var apiKey = dataArr[0].Split('=')[1].Split('&')[0];
            var username = dataArr[3].Split('=')[1].Split('&')[0];
            var userApiKey = dataArr[7].Split('=')[1].Split('&')[0];

            if(string.IsNullOrEmpty(apiKey)
            || string.IsNullOrEmpty(userApiKey)
            || string.IsNullOrEmpty(username))
            {
                throw new ApiDataParseException(page);
            }

            return new ApiDataModel()
            {
                ApiKey = apiKey,
                UserApiKey = userApiKey,
                Username = username
            };
        }
    }
}
