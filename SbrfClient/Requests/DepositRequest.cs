using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class DepositRequest : DepositParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public DepositRequest(DepositParams depositParams)
        {
            this.amount = depositParams.amount;
            this.orderId = depositParams.orderId;
        }
    }
}
