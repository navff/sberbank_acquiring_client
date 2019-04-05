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

            var bindingPaymentResult = client.PaymentOrderBinding(new PaymentOrderBindingParams
            {
                MdOrder = "34803399-74c2-71fa-9fe3-4da2000be085", //orderWithBinding.merchantOrderParams.First(p => p.name == "mdOrder").value,
                BindingId = orderWithBinding.bindingInfo.bindingId,
                Ip = "192.168.0.1"
            });
            Assert.IsTrue(bindingPaymentResult.errorCode == 0);


        }
    }
}
