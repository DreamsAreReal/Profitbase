using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using Profitbase.Wrapper.ErrorsFormSite;

namespace Profitbase.Wrapper.Parsers
{
    internal class LoginRequestParseExceptions
    {
        private const string ErrorMessageCssSelector = "div.help-block.help-block_error";
        public async Task<bool> CheckFailedAttempt(string page)
        {
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(page);
            var errorMessageNode = document.QuerySelector(ErrorMessageCssSelector);
            if (errorMessageNode == null)
                return true;

            if (errorMessageNode.InnerHtml.Trim() == En.CookiesHasDisabled)
                return false;
            if (errorMessageNode.InnerHtml.Trim() == Ru.LoginIncorrect)
                return false; 

            return true;

        }
    }
}
