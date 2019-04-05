using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class PaymentOrderBindingParams
    {
        /// <summary>
        /// *Номер заказа в платежной системе. Уникален в пределах системы.
        /// </summary>
        public string MdOrder { get; set; }

        /// <summary>
        /// *Идентификатор связки созданной при оплате заказа или использованной для оплаты. Присутствует только
        /// если магазину разрешено создание связок.
        /// </summary>
        public string BindingId { get; set; }

        /// <summary>
        /// Язык в кодировке ISO 639-1. Если не указан, будет использован язык, указанный в настройках магазина как
        /// язык по умолчанию.
        /// </summary>
        public int Language { get; set; }

        /// <summary>
        /// *ip-адрес плательщика.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// CVC код.Этот параметр обязателен, если для мерчанта не выбрано разрешение "Может проводить оплату без
        /// подтверждения CVC".
        /// </summary>
        public int Cvc { get; set; }

        /// <summary>
        /// Адрес электронной почты плательщика.
        /// </summary>
        public string Email { get; set; }
    }

}
