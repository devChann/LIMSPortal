using LIMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LIMS.Core.Billing
{
	public class Invoice
	{
		public Guid InvoiceId { get; set; }
		public string InvoiceNumber { get; set; }
		public decimal InvoiceAmount { get; set; } //should be generated yearly based on land rates	

		public DateTime DateCreated { get; set; } = DateTime.Now;

		public DateTime DateDue
		{
			get => Next4Months();
			set => _ = Next4Months();
		}

		public Guid ParcelId { get; set; }
		public Parcel Parcel { get; set; }

		public ICollection<Payment> Payments { get; set; }

		[NotMapped]
		private DateTime DateGenerated => DateCreated;
		
		private DateTime Next4Months()
		{
			if (DateGenerated.Day != DateTime.DaysInMonth(DateGenerated.Year, DateGenerated.Month))
			{
				return DateGenerated.AddMonths(4);
			}				
			else
			{
				return DateGenerated.AddDays(1).AddMonths(4).AddDays(-1);
			}
				
		}

		




	}
}
