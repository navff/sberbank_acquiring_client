using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SbrfClient;
using SbrfClient.Http;
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
            var result = client.Register(CreateRegisterRequest());
            TestContext.WriteLine(JsonConvert.SerializeObject(result));
        }


        private RegisterRequest CreateRegisterRequest()
        {
            return new RegisterRequest
            {
                userName = _settings.Username,
                password = _settings.Password,
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
            var obj = CreateRegisterRequest();
            string result = NetworkClient.ObjectToQueryString(obj);
            Assert.IsTrue(result.Contains(obj.password));
            TestContext.WriteLine(result);
        }
    }
}
