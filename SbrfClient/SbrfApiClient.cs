using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SbrfClient.Http;
using SbrfClient.Requests;
using SbrfClient.Response;

namespace SbrfClient
{
    public class SbrfApiClient
    {
        private readonly SbrfSettings _settings;
        private NetworkClient _networkClient;
        public SbrfApiClient(SbrfSettings settings)
        {
            _settings = settings;
            _networkClient = new NetworkClient();
        }

        public RegisterResponse Register(RegisterRequest request)
        {

            var url = _settings.BaseUrl + "/register.do";
            var result = _networkClient.PostObject<RegisterResponse>(url, request);
            return result;
        }


    }
}
