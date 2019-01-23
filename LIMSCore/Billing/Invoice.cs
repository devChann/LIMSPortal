using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LIMSCore.Billing
{
	public class Invoice
	{
		public Guid InvoiceId { get; set; }
		public string InvoiceNumber { get; set; }
		public double InvoiceAmount { get; set; } //should be generated yearly based on land rates

		[NotMapped]
		public string Status { get { return InvoiceStatus; } }

		public DateTime DateCreated { get; set; } = DateTime.Now;

		public DateTime DateDue {
			get {
				return Next4Months();
			}
			set {
				var date = Next4Months();
				date = value;
			}
		}

		public int ParcelId { get; set; }
		public Parcel Parcel { get; set; }

		public ICollection<Payment> Payments { get; set; }

		[NotMapped]
		private string InvoiceStatus => InvoiceAmount <= 0 ? "Paid" : "Not Paid";

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
