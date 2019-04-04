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
            this.BindingId = paymentOrderBindingParams.BindingId;
            this.Cvc = paymentOrderBindingParams.Cvc;
            this.Email = paymentOrderBindingParams.Email;
            this.Ip = paymentOrderBindingParams.Ip;
            this.Language = paymentOrderBindingParams.Language;
            this.MdOrder = paymentOrderBindingParams.MdOrder;
        }
    }
}
