using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SbrfClient;
using SbrfClient.Params;

namespace Tests
{
    [TestClass]
    public class BindingsTests
    {
        private SbrfSettings _settings;

        public BindingsTests()
        {
            _settings = new SbrfSettings
            {
                BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseSbrfUrl_Test"],
                Username = System.Configuration.ConfigurationManager.AppSettings["SbrfUsername_Test"],
                Password = System.Configuration.ConfigurationManager.AppSettings["SbrfPassword_Test"]
            };
        }

        [TestMethod]
        public void PaymentOrderBinding_Ok_Test()
        {
            var client = new SbrfApiClient(_settings);
            var orders = client.GetLastOrdersForMerchants(new GetLastOrdersForMerchantsParams
            {
                from = "20180101010101",
                transactionStates = "DEPOSITED",
                to = "20191231010101",
                size = 100,
                merchants = "orientirum",


            });
            var orderWithBinding = orders.orderStatuses.FirstOrDefault(o => o.bindingInfo != null);
            Assert.IsNotNull(orderWithBinding);


            // создаём новый заказ с заданным bindingId. Типа заказ предполагает,
            // что его будут оплачивать по связкам
            var registerParams = new RegisterParams
            {
                amount = 123,
                pageView = "DESKTOP",
                currency = 643,
                failUrl = "http://33kita.ru",
                returnUrl = "http://33kita.ru",
                orderNumber = Guid.NewGuid().ToString().Replace("-", ""),
                bindingId = orderWithBinding.bindingInfo.bindingId
            };

            // регистрируем новый заказ
            var registerResult = client.Register(registerParams);

            // проводим только что созданны заказ с bindingId одного из предыдущих заказов
            var bindingPaymentResult = client.PaymentOrderBinding(new PaymentOrderBindingParams
            {
                mdOrder = registerResult.OrderId, //orderWithBinding.merchantOrderParams.First(p => p.name == "mdOrder").value,
                bindingId = orderWithBinding.bindingInfo.bindingId,
                ip = "192.168.0.1"
            });
            Assert.IsTrue(bindingPaymentResult.errorCode == 0);


        }
    }
}
