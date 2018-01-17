using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class GetOrderStatusParams
    {
        /// <summary>
        /// Номер заказа в платежной системе. Уникален в пределах системы.
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Язык в кодировке ISO 639-1. Если не указан, считается, что язык – русский. Сообщение ошибке будет
        /// возвращено именно на этом языке.
        /// </summary>
        public string language { get; set; }
    }
}
