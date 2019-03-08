using System;
using System.Collections.Generic;

namespace LIMS.Core.Billing
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public decimal? Amount { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReceiptNo { get; set; }

		public Guid InvoiceId { get; set; }
		public Invoice Invoice { get; set; }
	}
}
