using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SbrfClient.Http;
using SbrfClient.Params;
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

        public RegisterResponse Register(RegisterParams registerParams)
        {

            var url = _settings.BaseUrl + "/register.do";
            RegisterRequest request = new RegisterRequest(registerParams); 
            request.userName = _settings.Username;
            request.password = _settings.Password;
            var result = _networkClient.PostObjectViaUrlParams<RegisterResponse>(url, request);
            return result;
        }

        public ReverseResponse Reverse(ReverseParams reverseParams)
        {
            var url = _settings.BaseUrl + "/reverse.do";
            var request = new ReverseRequest(reverseParams);
            request.userName = _settings.Username;
            request.password = _settings.Password;

            var result = _networkClient.PostObjectViaUrlParams<ReverseResponse>(url, request);
            return result;
        }


    }
}
