using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profitbase.Wrapper
{
    internal class Routes
    {
        public const string SubDomain = "pb12307";
        public const string BaseUrl = "https://"+SubDomain+".profitbase.ru/";
        

        public const string LoginPage = BaseUrl + "login";
        public const string LoginRequest = BaseUrl + "login_check";
    }
}
