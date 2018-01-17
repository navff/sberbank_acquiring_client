using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class GetOrderStatusResponse
    {
        /// <summary>
        /// По значению этого параметра определяется состояние заказа в платежной системе. 
        /// Отсутствует, если заказ не был найден
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Описание ошибки на языке, переданном в параметре Language в запросе
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Номер (идентификатор) заказа в системе магазина
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Маскированный номер карты, которая использовалась для оплаты. Указан только после оплаты
        /// заказа
        /// </summary>
        public string Pan { get; set; }

        /// <summary>
        /// Срок истечения действия карты в формате YYYYMM. Указан только после оплаты заказа
        /// </summary>
        public int expiration { get; set; }

        /// <summary>
        /// Имя держателя карты. Указан только после оплаты заказа
        /// </summary>
        public string cardholderName { get; set; }

        /// <summary>
        /// Сумма платежа в копейках (или центах)
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Код валюты платежа ISO 4217. Если не указан, считается равным коду валюты по умолчанию.
        /// </summary>
        public int currency { get; set; }

        /// <summary>
        /// Код авторизации МПС. Поле фиксированной длины (6 символов), может содержать цифры и
        /// латинские буквы.
        /// </summary>
        public string approvalCode { get; set; }

        /// <summary>
        /// Это поле является устаревшим. Его значение всегда равно "2", независимо от состояния заказа и
        /// кода авторизации процессинговой системы.        /// </summary>
        public int authCode { get; set; }

        /// <summary>
        /// IP адрес пользователя, который оплачивал заказ
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Сумма в минимальных единицах валюты (например, в копейках), 
        /// подтверждённая для списания с карты
        /// </summary>
        public long depositedAmount { get; set; }

        /// <summary>
        /// Привязка клиента
        /// </summary>
        public BindingInfo BindingInfo { get; set; }

    }

    public class BindingInfo
    {
        /// <summary>
        /// Номер (идентификатор) клиента в системе магазина, переданный при регистрации заказа.
        /// Присутствует только если магазину разрешено создание связок
        /// </summary>
        public string clientId { get; set; }

        /// <summary>
        /// Идентификатор связки созданной при оплате заказа или использованной для оплаты. Присутствует
        /// только если магазину разрешено создание связок
        /// </summary>
        public string bindingId { get; set; }
    }

}
