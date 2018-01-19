using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbrfClient.Params;

namespace SbrfClient.Requests
{
    internal class GetLastOrdersForMerchantsRequest : GetLastOrdersForMerchantsParams
    {
        public string userName { get; set; }
        public string password { get; set; }

        public GetLastOrdersForMerchantsRequest(GetLastOrdersForMerchantsParams getLastOrdersForMerchantsParams)
        {
            this.language = getLastOrdersForMerchantsParams.language;
            this.from = getLastOrdersForMerchantsParams.from;
            this.merchants = getLastOrdersForMerchantsParams.merchants;
            this.page = getLastOrdersForMerchantsParams.page;
            this.searchByCreatedDate = getLastOrdersForMerchantsParams.searchByCreatedDate;
            this.size = getLastOrdersForMerchantsParams.size;
            this.to = getLastOrdersForMerchantsParams.to;
            this.transactionStates = getLastOrdersForMerchantsParams.transactionStates;
        }
    }
}
