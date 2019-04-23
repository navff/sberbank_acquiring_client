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
        /// Расшифровка кода ответа на языке, переданном в параметре language
        /// в запросе
        /// </summary>
        public string actionCodeDescription { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// Описание ошибки на языке, переданном в параметре language в
        /// запросе.
        /// </summary>
        public string errorMessage { get; set; }

        /// <summary>
        /// Сумма платежа в копейках (или центах)
        /// </summary>
        public long amount { get; set; }

        /// <summary>
        /// Код валюты платежа ISO 4217. Если не указан, считается равным 810
        /// (российские рубли).
        /// </summary>
        public int currency { get; set; }

        /// <summary>
        /// Дата регистрации заказа
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Описание заказа, переданное при его регистрации
        /// </summary>
        public string orderDescription { get; set; }

        /// <summary>
        /// IP-адрес покупателя.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        ///  Дата/время авторизации
        /// (только для запроса Extended)
        /// </summary>
        public string authDateTime { get; set; }

        /// <summary>
        /// Учётный номер авторизации платежа, который присваивается при
        /// регистрации платежа (только для запроса Extended)
        /// </summary>
        public string authRefNum { get; set; }

        /// <summary>
        ///  Id терминала
        /// </summary>
        public string terminalId { get; set; }

        /// <summary>
        /// Элемент merchantOrderParams – присутствует в ответе, если в заказе содержатся дополнительные параметры продавца. Каждый дополнительный
        /// параметр заказа представлен в отдельном элементе merchantOrderParams.
        /// </summary>
        public IEnumerable<NameValueParam> merchantOrderParams { get; set; }

        /// <summary>
        /// Какие-то дополнительные аттрибуты
        /// </summary>
        public IEnumerable<NameValueParam> attributes { get; set; }

        public CardAuthInfo cardAuthInfo { get; set; }
        public SecureAuthInfo secureAuthInfo { get; set; }
        public BindingInfo bindingInfo { get;set; }
        public PaymentAmountInfo paymentAmountInfo { get; set; }
        public BankInfo bankInfo { get; set; }
    }

    public class NameValueParam
    {
        /// <summary>
        /// Название дополнительного параметра
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Значение дополнительного параметра
        /// </summary>
        public string value { get; set; }
    }

    public class CardAuthInfo
    {
        /// <summary>
        /// Маскированный номер карты, которая использовалась для оплаты.
        /// Указан только после оплаты заказа. (Поле устарело?)
        /// </summary>
        public string maskedPan { get; set; }

        /// <summary>
        /// Срок истечения действия карты в формате YYYYMM. Указан только
        /// после оплаты заказа.
        /// </summary>
        public int expiration { get; set; }

        /// <summary>
        /// Имя держателя карты. Указан только после оплаты заказа.
        /// </summary>
        public string cardholderName { get; set; }

        /// <summary>
        /// Код авторизации платежа. Поле фиксированной длины (6 символов),
        /// может содержать цифры и латинские буквы. Указан только после
        /// оплаты заказа
        /// </summary>
        public string approvalCode { get; set; }

        /// <summary>
        /// Были ли средства принудительно возвращены покупателю банком
        /// </summary>
        public bool chargeback { get; set; }

        /// <summary>
        /// Наименование платёжной системы. Доступны следующие варианты.
        /// </summary>
        public string paymentSystem { get; set; }

        /// <summary>
        /// Дополнительные сведения о корпоративных картах. Эти сведения
        /// заполняются службой технической поддержки в консоли управления.
        /// Если такие сведения отсутствуют, возвращается пустое значение
        /// </summary>
        public string product { get; set; }

        /// <summary>
        /// Способ совершения платежа (платёж в с вводом карточных данных,
        /// оплата по связке и т. п.)
        /// </summary>
        public string paymentWay { get; set; }

        /// <summary>
        /// Маскированный номер карты, которая использовалась для оплаты.
        /// Указан только после оплаты заказа.
        /// </summary>
        public string pan { get; set; }
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
