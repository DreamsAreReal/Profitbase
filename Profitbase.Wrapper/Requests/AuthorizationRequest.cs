﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Profitbase.Wrapper.Requests
{
    internal class AuthorizationRequest
    {
        private Client _client;
        public AuthorizationRequest(Client client)
        {
            _client = client;
        }

    }
}
