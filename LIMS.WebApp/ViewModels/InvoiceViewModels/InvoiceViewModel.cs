using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewModels.InvoiceViewModels
{
	public class InvoiceViewModel
	{
		[Display(Name ="Invoice Id")]
		public Guid InvoiceID { get; set; }

		[Display(Name ="Invoice Number")]
		public string InvoiceNumber { get; set; }

		[Display(Name ="Date Created")]
		public DateTime DateCreated { get; set; }

		[Display(Name ="Date Due")]
		public DateTime DateDue { get; set; }

		[Display(Name ="Amount")]
		public double InvoiceAmount { get; set; }

		[Display(Name ="Status")]
		public string Status { get; set; }

		[Display(Name ="Year")]
		public string FinancialYear { get; set; }

		[Display(Name ="Parcel Number")]
		public string ParcelNumber { get; set; }


	}
}
