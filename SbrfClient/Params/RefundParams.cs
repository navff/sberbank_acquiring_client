using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class RefundParams
    {
        /// <summary>
        /// Номер заказа в платежной системе. Уникален в пределах системы
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Сумма платежа в копейках (или центах)
        /// </summary>
        public long amount { get; set; }
    }
}
