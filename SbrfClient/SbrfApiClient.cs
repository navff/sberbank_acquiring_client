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


        /// <summary>
        /// Иницциирование одностадийной оплаты заказа
        /// </summary>
        public RegisterPreAuthResponse RegisterPreAuth(RegisterPreAuthParams registerParams)
        {

            var url = _settings.BaseUrl + "/registerPreAuth.do";
            RegisterPreAuthRequest request = new RegisterPreAuthRequest(registerParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };
            var result = _networkClient.PostObjectViaUrlParams<RegisterPreAuthResponse>(url, request);
            return result;
        }

        /// <summary>
        /// Иницциирование одностадийной оплаты заказа
        /// </summary>
        public RegisterResponse Register(RegisterParams registerParams)
        {

            var url = _settings.BaseUrl + "/register.do";
            RegisterRequest request = new RegisterRequest(registerParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };
            var result = _networkClient.PostObjectViaUrlParams<RegisterResponse>(url, request);
            return result;
        }


        /// <summary>
        /// Для запроса отмены оплаты заказа используется запрос reverse.do. Функция отмены доступна в течение ограниченного времени
        /// после оплаты, точные сроки необходимо уточнять в Банке.
        /// Операция отмены оплаты может быть совершена только один раз. Если она закончится ошибкой, то повторная операция отмены
        /// платежа не пройдет. Данная функция доступна магазинам по согласованию с Банком. Для выполнения операции отмены пользователь должен обладать
        /// соответствующими правами.
        /// </summary>
        public ReverseResponse Reverse(ReverseParams reverseParams)
        {
            var url = _settings.BaseUrl + "/reverse.do";
            var request = new ReverseRequest(reverseParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<ReverseResponse>(url, request);
            return result;
        }


        /// <summary>
        /// По этому запросу средства по указанному заказу будут возвращены плательщику. Запрос закончится ошибкой в случае, если средства
        /// по этому заказу не были списаны. Система позволяет возвращать средства более одного раза, но в общей сложности не более
        /// первоначальной суммы списания.
        /// Для выполнения операции возврата необходимо наличие соответствующих права в системе
        /// </summary>
        public RefundResponse Refund(RefundParams refundParams)
        {
            var url = _settings.BaseUrl + "/refund.do";
            var request = new RefundRequest(refundParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<RefundResponse>(url, request);
            return result;
        }

        /// <summary>
        /// Получает текущее состояние заказа
        /// </summary>
        public GetOrderStatusResponse GetOrderStatus(GetOrderStatusParams getOrderStatusParams)
        {
            var url = _settings.BaseUrl + "/getOrderStatus.do";
            var request = new GetOrderStatusRequest(getOrderStatusParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<GetOrderStatusResponse>(url, request, "GET");
            return result;
        }

        /// <summary>
        /// Получает подробное текущее состояние заказа
        /// </summary>
        public GetOrderStatusExtendedResponse GetOrderStatusExtended(GetOrderStatusExtendedParams getOrderStatusParams)
        {
            var url = _settings.BaseUrl + "/getOrderStatusExtended.do";
            var request = new GetOrderStatusExtendedRequest(getOrderStatusParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<GetOrderStatusExtendedResponse>(url, request, "GET");
            return result;
        }

        /// <summary>
        /// Для проверки вовлечённости карты в 3DS
        /// </summary>
        public VerifyEnrollmentResponse VerifyEnrollment(VerifyEnrollmentParams verifyEnrollmentParams)
        {
            var url = _settings.BaseUrl + "/verifyEnrollment.do";
            var request = new VerifyEnrollmentRequest(verifyEnrollmentParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<VerifyEnrollmentResponse>(url, request, "GET");
            return result;
        }

        /// <summary>
        /// Запрос статистики по платежам за период
        /// </summary>
        public GetLastOrdersForMerchantsResponse GetLastOrdersForMerchants(GetLastOrdersForMerchantsParams getLastOrdersForMerchantsParams)
        {
            var url = _settings.BaseUrl + "/getLastOrdersForMerchants.do";
            var request = new GetLastOrdersForMerchantsRequest(getLastOrdersForMerchantsParams)
            {
                userName = _settings.Username,
                password = _settings.Password
            };

            var result = _networkClient.PostObjectViaUrlParams<GetLastOrdersForMerchantsResponse>(url, request, "GET");
            return result;
        }
    }
}
