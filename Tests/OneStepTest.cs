using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SbrfClient;
using SbrfClient.Http;
using SbrfClient.Params;
using SbrfClient.Requests;

namespace Tests
{
    [TestClass]
    public class OneStepTest
    {
        private SbrfSettings _settings;
        public TestContext TestContext { get; set; }

        public OneStepTest()
        {

            _settings = new SbrfSettings
            {
                BaseUrl = System.Configuration.ConfigurationManager.AppSettings["BaseSbrfUrl_Test"],
                Username = System.Configuration.ConfigurationManager.AppSettings["SbrfUsername_Test"],
                Password = System.Configuration.ConfigurationManager.AppSettings["SbrfPassword_Test"]
            };
        }

        [TestMethod]
        public void Register_Ok_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.Register(CreateRegisterParams());
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
        }

        [TestMethod]
        public void Reverse_Ok_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.Reverse(new ReverseParams
            {
                orderId = "613e5f12-c4bb-701c-613e-5f12000be085",
                language = "ru"
            });
            TestContext.WriteLine(JsonConvert.SerializeObject(result.ErrorCode==6));
        }

        [TestMethod]
        public void Reverse_WrongOrderId_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.Reverse(new ReverseParams
            {
                orderId = "123",
                language = "ru"
            });
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
            Assert.AreEqual(6, result.ErrorCode);
        }


        private RegisterParams CreateRegisterParams()
        {
            return new RegisterParams
            {
                amount = 123,
                pageView = "DESKTOP",
                currency = 643,
                failUrl = "http://33kita.ru",
                returnUrl = "http://33kita.ru",
                orderNumber = Guid.NewGuid().ToString().Replace("-", "")
            };
        }

        [TestMethod]
        public void ObjectToQueryString_Ok_Test()
        {
            var obj = CreateRegisterParams();
            string result = NetworkClient.ObjectToQueryString(obj);
            Assert.IsTrue(result.Contains(obj.orderNumber));
            TestContext.WriteLine(result);
        }

        [TestMethod]
        public void Refund_WrongOrderId_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.Refund(new RefundParams
            {
                orderId = "123",
                amount = 10
            });
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
            Assert.AreEqual(6, result.ErrorCode);
        }

        [TestMethod]
        public void Refund_Ok_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.Refund(new RefundParams
            {
                orderId = "1a080048-9243-7176-1a08-0048000be085",
                amount = 10
            });
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
            //Assert.AreEqual(6, result.ErrorCode);
        }

        [TestMethod]
        public void GetOrderStatus_Ok_Test()
        {
            var client = new SbrfApiClient(_settings);
            var result = client.GetOrderStatus(new GetOrderStatusParams
            {
                orderId = "1a080048-9243-7176-1a08-0048000be085"
            });
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
            //Assert.AreEqual(6, result.ErrorCode);
        }
    }
}
