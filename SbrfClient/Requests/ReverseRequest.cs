﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class ReverseRequest : ReverseParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public ReverseRequest(ReverseParams reverseParams)
        {
            this.orderId = reverseParams.orderId;
            this.language = reverseParams.language;
        }
    }
}
