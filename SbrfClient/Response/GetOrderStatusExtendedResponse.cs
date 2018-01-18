using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class GetOrderStatusExtendedResponse
    {
        /// <summary>
        /// Номер (идентификатор) заказа в системе магазина.
        /// </summary>
        public string orderNumber { get; set; }

        /// <summary>
        /// По значению этого параметра определяется состояние заказа в
        /// платёжной системе. Отсутствует, если заказ не был найден
        /// </summary>
        public int orderStatus { get; set; }

        /// <summary>
        /// Код ответа
        /// </summary>
        public int actionCode { get; set; }

        /// <summary>
        /// Расшифровка кода ответа на языке, переданном в параметре Language
        /// в запросе
        /// </summary>
        public string actionCodeDescription { get; set; }

        /// <summary>
        /// Код ошибки. Возможны следующие варианты
        /// </summary>
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public long amount { get; set; }
        public int currency { get; set; }
        public string date { get; set; }
        public string orderDescription { get; set; }
        public string ip { get; set; }

        public IEnumerable<MerchantOrderParams> merchantOrderParams { get; set; }
        public CardAuthInfo cardAuthInfo { get; set; }
        public SecureAuthInfo secureAuthInfo { get; set; }
        public BindingInfo bindingInfo { get;set; }
        public PaymentAmountInfo paymentAmountInfo { get; set; }
        public BankInfo bankInfo { get; set; }
    }

    public class MerchantOrderParams
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class CardAuthInfo
    {
        public string maskedPan { get; set; }
        public int expiration { get; set; }
        public string cardholderName { get; set; }
        public string approvalCode { get; set; }
        public bool chargeback { get; set; }
        public int paymentSystem { get; set; }
        public string product { get; set; }
        public string paymentWay { get; set; }
    }

    public class SecureAuthInfo
    {
        public int eci { get; set; }
        public string cavv { get; set; }
        public string xid { get; set; }
    }

    public class PaymentAmountInfo
    {
        public long approvedAmount { get; set; }
        public long depositedAmount { get; set; }
        public long refundedAmount { get; set; }
        public string paymentState { get; set; }
        public long feeAmount { get; set; }
    }

    public class BankInfo
    {
        public string bankName { get; set; }
        public string bankCountryCode { get; set; }
        public string bankCountryName { get; set; }
    }

    public enum OrderStatus
    {
        /// <summary>
        /// Заказ зарегистрирован, но не оплачен;
        /// </summary>
        Registered = 0,

        /// <summary>
        /// Предавторизованная сумма захолдирована (для двухстадийных
        /// платежей);
        /// </summary>
        Holded = 1,

        /// <summary>
        /// Проведена полная авторизация суммы заказа;
        /// </summary>
        FullAuthorized = 2,

        /// <summary>
        /// Авторизация отменена;
        /// </summary>
        AuthorizationCancelled = 3,

        /// <summary>
        /// По транзакции была проведена операция возврата;
        /// </summary>
        Refunded = 4,

        /// <summary>
        ///  Инициирована авторизация через ACS банка-эмитента;
        /// </summary>
        InClientACSProgress = 5,

        /// <summary>
        /// Авторизация отклонена.
        /// </summary>
        AuthorizationDeclined = 6
    }
}
