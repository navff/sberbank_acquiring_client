using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    /// <summary>
    /// Для проверки вовлечённости карты в 3DS используется запрос verifyEnrollment.
    /// </summary>
    public class VerifyEnrollmentParams
    {
        /// <summary>
        /// Номер карты
        /// </summary>
        public string pan { get; set; }
    }
}
