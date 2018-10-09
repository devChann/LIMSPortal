using System;

namespace LIMSCore.Billing
{
	public class Payment
	{
		public Guid PaymentId { get; set; }
		public double Amount { get; set; }
		public DateTime DatePaid { get; set; }
		public string Type { get; set; }
		public Guid InvoiceId { get; set; }
		public Invoice Invoice { get; set; }
		public MpesaTransaction MpesaTransaction { get; set; }
	}
}
