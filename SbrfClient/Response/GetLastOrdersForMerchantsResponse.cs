using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class GetLastOrdersForMerchantsResponse
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int  errorCode { get; set; }

        /// <summary>
        /// Описание ошибки. Присутствует только при наличии ошибки (errorCode не равно 0).
        /// </summary>
        public string errorMessage { get; set; }

        /// <summary>
        /// Блок, содержащий информацию о заказах, попавших в отчёт
        /// </summary>
        public IEnumerable<GetOrderStatusExtendedResponse> orderStatuses { get; set; }

        /// <summary>
        /// Общее количество элементов во отчёте (на всех страницах).
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// Номер текущей страницы (равный номеру страницы, переданному в запросе).
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Максимальное количество записей на странице (равно размеру страницы, переданному в запросе).
        /// </summary>
        public int pageSize { get; set; }
    }

    public class OrderStatusResponse
    {
        /// <summary>
        /// Номер (идентификатор) заказа в системе магазина.
        /// </summary>
        public string orderNumber { get; set; }

        /// <summary>
        /// Состояние заказа в платежной системе. Возможные значения представлены ниже в таблице "Поле
        /// orderStatus:"
        /// </summary>
        public int orderStatus { get; set; }

        /// <summary>
        /// Код ответа
        /// </summary>
        public int actionCode { get; set; }

        /// <summary>
        /// Расшифровка кода ответа
        /// </summary>
        public string actionCodeDescription { get; set; }

        /// <summary>
        /// Сумма платежа в минимальных единицах валюты.
        /// </summary>
        public long amount { get; set; }

        /// <summary>
        /// Код валюты платежа ISO 4217. Если не указан, считается равным валюте по умолчанию.
        /// </summary>
        public int currency { get; set; }

        /// <summary>
        /// Дата регистрации заказа.
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Описание заказа, переданное при его регистрации
        /// </summary>
        public string orderDescription { get; set; }

        /// <summary>
        /// IP адрес покупателя. Указан только после оплаты
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// Тэг с атрибутами, в которых передаются дополнительные параметры мерчанта
        /// </summary>
        public IEnumerable<NameValueParam> merchantOrderParams { get; set; }

        /// <summary>
        /// Атрибуты заказа в платёжной системе (номер заказа)
        /// </summary>
        public IEnumerable<NameValueParam> attributes { get; set; }

        /// <summary>
        /// Тэг с атрибутами платежа
        /// </summary>
        public CardAuthInfo cardAuthInfo { get; set; }

        /// <summary>
        /// Тэг с информацией о связке, с помощью которой осуществлена оплата
        /// </summary>
        public BindingInfo bindingInfo { get; set; }

        /// <summary>
        /// Дата/время авторизации
        /// </summary>
        public string authDateTime { get; set; }

        /// <summary>
        /// Id терминала
        /// </summary>
        public string terminalId { get; set; }

        /// <summary>
        /// Учётный номер авторизации, который присваивается при регистрации платежа.
        /// </summary>
        public string authRefNum { get; set; }

        /// <summary>
        /// Тэг с информацией о суммах подтверждения, списания, возврата. 
        /// </summary>
        public PaymentAmountInfo paymentAmountInfo { get; set; }

        /// <summary>
        /// Тэг с информацией о Банке-эмитенте
        /// </summary>
        public BankInfo bankInfo { get; set; }
    }

}
