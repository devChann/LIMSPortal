using System;
using System.Collections.Generic;
using System.Text;

namespace LIMS.Core.Billing
{
    public class MpesaTransaction
    {
        public Guid MpesaTransactionId { get; set; }
        public string Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CheckoutRequestID { get; set; }
        public string MerchantRequestId { get; set; }
        public string ReceiptNumber { get; set; }
        public string PhoneNumber { get; set; }		
    }
}
