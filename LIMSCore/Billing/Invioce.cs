using System;
using System.Collections.Generic;
using System.Text;

namespace LIMSCore.Billing
{
	public class Invoice
	{
		public Guid InvoiceId { get; set; }
		public string Type { get; set; }
		
		public DateTime Created { get; set; }
		public DateTime Expires { get; set; }

		public Guid ProductId { get; set; }

		public Product Product { get; set; }

		public ICollection<Payment> Payments { get; set; }
	}
}
