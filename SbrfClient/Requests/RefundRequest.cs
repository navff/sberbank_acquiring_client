using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class RefundRequest : RefundParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public RefundRequest(RefundParams refundParams)
        {
            this.orderId = refundParams.orderId;
            this.amount = refundParams.amount;
        }
    }

   
}
