using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Profitbase.Wrapper.Exceptions;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginPageToCsrfTokenParser
    {
        private const string InputCrsfTokenNameInForm = "input[name=\"_csrf_token\"]";
        private const string AttributeValueName = "value";

        public string GetToken(string page)
        {
            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(page);


            var crsfTokenAttribute = htmlSnippet.DocumentNode.SelectSingleNode(InputCrsfTokenNameInForm).Attributes[AttributeValueName];

            if (crsfTokenAttribute == null)
            {
                throw new CrsfTokenParseException(page);
            }

            return crsfTokenAttribute.Value;

        }
    }
}
