using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class PaymentOrderBindingRequest : PaymentOrderBindingParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public PaymentOrderBindingRequest(PaymentOrderBindingParams paymentOrderBindingParams)
        {
            this.bindingId = paymentOrderBindingParams.bindingId;
            this.cvc = paymentOrderBindingParams.cvc;
            this.email = paymentOrderBindingParams.email;
            this.ip = paymentOrderBindingParams.ip;
            this.language = paymentOrderBindingParams.language;
            this.mdOrder = paymentOrderBindingParams.mdOrder;
        }
    }
}
