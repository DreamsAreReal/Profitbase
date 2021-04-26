using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Profitbase.Wrapper
{
    public class Api
    {
        private Client _client;

        public Api(IWebProxy proxy = null)
        {
            _client = new Client();
        }


        public void GetAll(string login, string password)
        {
            return;
        }
    }
}
