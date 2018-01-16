using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    /// <summary>
    /// 8.2.1. Запрос регистрации заказа
    /// Для регистрации заказа используется запрос register.do 
    /// </summary>
    public class RegisterRequest : RegisterParams
    {
        /// <summary>
        /// Логин магазина, полученный при подключении
        /// </summary>
        public string userName { get; set; }


        /// <summary>
        /// Пароль магазина, полученный при подключении
        /// </summary>
        public string password { get; set; }


        public RegisterRequest(RegisterParams registerParams)
        {
            this.orderNumber = registerParams.orderNumber;
            this.amount = registerParams.amount;
            this.currency = registerParams.currency;
            this.returnUrl = registerParams.returnUrl;
            this.failUrl = registerParams.failUrl;
            this.description = registerParams.description;
            this.language = registerParams.language;
            this.pageView = registerParams.pageView;
            this.clientId = registerParams.clientId;
            this.merchantLogin = registerParams.merchantLogin;
            this.jsonParams = registerParams.jsonParams;
            this.sessionTimeoutSecs = registerParams.sessionTimeoutSecs;
            this.expirationDate = registerParams.expirationDate;
            this.bindingId = registerParams.bindingId;
            this.features = registerParams.features;
        }
    }
}
