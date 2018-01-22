using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class RegisterPreAuthRequest : RegisterPreAuthParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public RegisterPreAuthRequest(RegisterPreAuthParams registerPreAuthParams)
        {
            this.amount = registerPreAuthParams.amount;
            this.bindingId = registerPreAuthParams.bindingId;
            this.clientId = registerPreAuthParams.clientId;
            this.currency = registerPreAuthParams.currency;
            this.description = registerPreAuthParams.description;
            this.expirationDate = registerPreAuthParams.expirationDate;
            this.failUrl = registerPreAuthParams.failUrl;
            this.returnUrl = registerPreAuthParams.returnUrl;
            this.features = registerPreAuthParams.features;
            this.jsonParams = registerPreAuthParams.jsonParams;
            this.language = registerPreAuthParams.language;
            this.orderNumber = registerPreAuthParams.orderNumber;
            this.pageView = registerPreAuthParams.pageView;
            this.merchantLogin = registerPreAuthParams.merchantLogin;
            this.sessionTimeoutSecs = registerPreAuthParams.sessionTimeoutSecs;
        }
    }
}
