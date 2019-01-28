using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSCore.Billing
{
	public class Checkout
	{
		public Guid CheckoutId { get; set; }
		public DateTime CheckoutDate { get; set; }
		public string CheckoutRequest { get; set; }

		public double AmountPaid { get; set; }

		public Guid InvoiceId { get; set; }
		public Invoice Invoice { get; set; }

	}
}
