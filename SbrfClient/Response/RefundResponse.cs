using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class RefundResponse
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Описание ошибки на человеческом языке
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
