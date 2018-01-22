using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class RegisterPreAuthResponse
    {
        public string orderId { get; set; }
        public string formUrl { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
    }
}
