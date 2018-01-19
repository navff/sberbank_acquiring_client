using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class VerifyEnrollmentResponse
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        public string errorMessage { get; set; }

        /// <summary>
        /// Признак вовлечённости карты в 3DS. Возможные значения: Y, N, U
        /// </summary>
        public string enrolled { get; set; }

        /// <summary>
        /// Наименование банка-эмитента
        /// </summary>
        public string emitterName { get; set; }

        /// <summary>
        /// Код страны банка-эмитента.
        /// </summary>
        public string emitterCountryCode { get; set; }
    }
}
