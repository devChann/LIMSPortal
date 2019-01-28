using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.InvoiceViewModels
{
	public class InvoiceViewModel
	{
		public Guid InvoiceID { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateDue { get; set; }

		public double InvoiceAmount { get; set; }
		public string Status { get; set; }

		public string ParcelNumber { get; set; }


	}
}
