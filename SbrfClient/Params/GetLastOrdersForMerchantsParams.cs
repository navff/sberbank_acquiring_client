using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Params
{
    public class GetLastOrdersForMerchantsParams
    {
        /// <summary>
        /// Язык в кодировке ISO 639-1. Если не указан, считается, что язык – русский. Сообщение ошибке
        /// будет возвращено именно на этом языке.
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// При обработке запроса будет сформирован список, разбитый на страницы (с количеством записей s
        /// ize на одной странице). В ответе возвращается страница под номером, указанным в параметре pag
        /// e. Нумерация страниц начинается с 0.
        /// Если параметр не указан, будет возвращена страница под номером 0
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// *Количество элементов на странице (максимальное значение = 200)
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// *Дата и время начала периода для выборки заказов в формате YYYYMMDDHHmmss.
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// *Дата и время окончания периода для выборки заказов в формате YYYYMMDDHHmmss
        /// </summary>
        public string to { get; set; }

        /// <summary>
        /// *В этом блоке необходимо перечислить требуемые состояния заказов. Только заказы, находящиеся в
        /// одном из указанных состояний, попадут в отчёт.
        /// Несколько значений указываются через запятую. Возможные значения: CREATED, APPROVED,
        /// DEPOSITED, DECLINED, REVERSED, REFUNDED.
        /// </summary>
        public string transactionStates { get; set; }

        /// <summary>
        /// *Список Логинов мерчантов, чьи транзакции должны попасть в отчёт. Несколько значений
        /// указываются через запятую.
        /// Оставьте это поле пустым, чтобы получить список отчётов по всем доступным мерчантам (дочерним
        /// мерчантам и мерчантам, указанным в настройках пользователя).
        /// </summary>
        public string merchants { get; set; }

        /// <summary>
        /// Возможные значения:
        /// true – поиск заказов, дата создания которых попадает в заданный период.
        /// false – поиск заказов, дата оплаты которых попадает в заданный период (таким образом, в
        /// отчёте не могут присутствовать заказы в статусе CREATED и DECLINED).
        /// Значение по умолчанию – false.
        /// </summary>
        public bool searchByCreatedDate { get; set; }
    }
}
