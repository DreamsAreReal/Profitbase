using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginRequestParseApiData
    {
        private const string IframeDataPattern = "src=\"\\/\\/widget\\.profitbase\\.ru\\?(.*)\"";
        public string GetData(string page)
        {
            var data = new Regex(IframeDataPattern).Match(page)?.Groups[1]?.Value;

            if (string.IsNullOrEmpty(data))
                return "";

            var dataArr = data.Split(';');

            if (dataArr.Length != 8)
                return "";

            var apiKey = dataArr[0].Split('=')[1].Split('&')[0];
            var username = dataArr[3].Split('=')[1].Split('&')[0];
            var userApiKey = dataArr[7].Split('=')[1].Split('&')[0];



        }
    }
}
