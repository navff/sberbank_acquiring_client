using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class GetOrderStatusExtendedRequest : GetOrderStatusExtendedParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public GetOrderStatusExtendedRequest(GetOrderStatusExtendedParams getOrderStatusExtendedParams)
        {
            this.orderId = getOrderStatusExtendedParams.orderId;
            this.language = getOrderStatusExtendedParams.language;
            this.orderNumber = getOrderStatusExtendedParams.orderNumber;
        }
    }
}
