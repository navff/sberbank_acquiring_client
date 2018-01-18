using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    /// <summary>
    ///  В запросе должен присутствовать либо orderId, либо orderNumber. Если в запросе присутствуют оба параметра, то приоритетным
    /// считается orderId.
    /// </summary>
    public class GetOrderStatusExtendedParams
    {
        /// <summary>
        /// Номер заказа в платежной системе. Уникален в пределах системы.
        /// Обязательный параметр.
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Номер (идентификатор) заказа в системе магазина.
        /// Обязательный параметр.
        /// </summary>
        public string orderNumber { get; set; }

        /// <summary>
        /// Язык в кодировке ISO 639-1. Если не указан, считается, что язык – русский. Сообщение ошибке будет
        /// возвращено именно на этом языке
        /// </summary>
        public string language { get; set; }
    }
}
