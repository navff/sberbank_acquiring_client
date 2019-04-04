using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class PaymentOrderBindingParams
    {
        public string MdOrder { get; set; }

        public string BindingId { get; set; }

        public int Language { get; set; }

        public string Ip { get; set; }

        public int Cvc { get; set; }

        public string Email { get; set; }
    }

}
