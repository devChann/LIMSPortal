using System;
using System.Collections.Generic;
using System.Text;

namespace LIMS.Core.Billing
{
	public class Checkout
	{
		public Guid CheckoutId { get; set; }
		public DateTime CheckoutDate { get; set; }
		public string CheckoutRequestId { get; set; }
		public double AmountPaid { get; set; }

		public Guid PaymentId { get; set; }
		public Payment Payment { get; set; }

	}
}
