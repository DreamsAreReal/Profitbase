using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Profitbase.Wrapper.Exceptions;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginPageToCsrfTokenParser
    {
        private const string InputCrsfTokenNameInForm = "<input type=\"hidden\" name=\"_csrf_token\" value=\"(.*)\">";

        public string GetToken(string page)
        {


            var crsfToken = new Regex(InputCrsfTokenNameInForm).Match(page)?.Groups[1]?.Value;

            if (String.IsNullOrEmpty(crsfToken))
            {
                throw new CrsfTokenParseException(page);
            }

            return crsfToken;

        }
    }
}
