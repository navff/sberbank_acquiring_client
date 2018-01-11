using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SbrfClient;
using SbrfClient.Requests;

namespace Tests
{
    [TestClass]
    public class OneStepTest
    {
        private SbrfSettings _settings;
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
            client.Register(CreateRegisterRequest());
        }


        private RegisterRequest CreateRegisterRequest()
        {
            return new RegisterRequest
            {
                UserName = _settings.Username,
                Password = _settings.Password,
                Amount = 123,
                PageView = "DESKTOP",
                Currency = 643,
                FailUrl = "http://33kita.ru",
                ReturnUrl = "http://33kita.ru",
                OrderNumber = Guid.NewGuid().ToString()
            };
        }
    }
}
