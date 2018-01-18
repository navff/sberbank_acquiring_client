using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbrfClient.Response
{
    public class GetOrderStatusExtendedResponse
    {
        public string orderNumber { get; set; }
        public int orderStatus { get; set; }
        public int actionCode { get; set; }
        public string actionCodeDescription { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public long amount { get; set; }
        public int currency { get; set; }
        public string date { get; set; }
        public string orderDescription { get; set; }
        public string ip { get; set; }

        public IEnumerable<MerchantOrderParams> merchantOrderParams { get; set; }
        public CardAuthInfo cardAuthInfo { get; set; }
        public SecureAuthInfo secureAuthInfo { get; set; }
        public BindingInfo bindingInfo { get;set; }
        public PaymentAmountInfo paymentAmountInfo { get; set; }
        public BankInfo bankInfo { get; set; }
    }

    public class MerchantOrderParams
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class CardAuthInfo
    {
        public string maskedPan { get; set; }
        public int expiration { get; set; }
        public string cardholderName { get; set; }
        public string approvalCode { get; set; }
        public bool chargeback { get; set; }
        public int paymentSystem { get; set; }
        public string product { get; set; }
        public string paymentWay { get; set; }
    }

    public class SecureAuthInfo
    {
        public int eci { get; set; }
        public string cavv { get; set; }
        public string xid { get; set; }
    }

    public class PaymentAmountInfo
    {
        public long approvedAmount { get; set; }
        public long depositedAmount { get; set; }
        public long refundedAmount { get; set; }
        public string paymentState { get; set; }
        public long feeAmount { get; set; }
    }

    public class BankInfo
    {
        public string bankName { get; set; }
        public string bankCountryCode { get; set; }
        public string bankCountryName { get; set; }
    }
}
