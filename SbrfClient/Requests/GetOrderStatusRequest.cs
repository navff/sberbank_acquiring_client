using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class GetOrderStatusRequest : GetOrderStatusParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public GetOrderStatusRequest(GetOrderStatusParams getOrderStatusParams)
        {
            this.orderId = getOrderStatusParams.orderId;
            this.language = getOrderStatusParams.language;
        }
    }
}
