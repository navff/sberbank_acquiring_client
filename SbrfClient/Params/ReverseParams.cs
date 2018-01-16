using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class ReverseParams
    {
        /// <summary>
        /// Номер заказа в платежной системе. Уникален в пределах системы.
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Язык в кодировке ISO 639-1. Описание ошибки возвращается на этом языке. Если параметр отсутствует,
        /// используется язык по умолчанию, указанный в настройках мерчанта.
        /// </summary>
        public string language { get; set; }
    }
}
