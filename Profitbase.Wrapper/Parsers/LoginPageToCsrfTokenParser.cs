using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Profitbase.Wrapper.Exceptions;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginPageToCsrfTokenParser
    {
        private const string InputCrsfTokenName = "input[name='_csrf_token']";
        private const string AttributeName = "value";

        /// <summary>
        /// Parse csrf token from login page
        /// https://pb12307.profitbase.ru/login
        /// </summary>
        /// <param name="page">The html from login page. https://pb12307.profitbase.ru/login.</param>
        /// <returns>Csrf token</returns>
        public async Task<string> GetToken(string page)
        {

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(page);
            var csrfNode = document?.QuerySelector(InputCrsfTokenName);
            if (csrfNode==null)
            {
                throw new CrsfTokenParseException(page);
            }

            return csrfNode.GetAttribute(AttributeName);

        }
    }
}
