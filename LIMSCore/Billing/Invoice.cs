using LIMSCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LIMSCore.Billing
{
	public class Invoice
	{
		public Guid InvoiceId { get; set; }
		public string InvoiceNumber { get; set; }
		public double InvoiceAmount { get; set; } //should be generated yearly based on land rates		

		public ICollection<Checkout> Checkouts { get; set; }

		//[NotMapped]
		//public string Status { get { return InvoiceStatus; } }

		public DateTime DateCreated { get; set; } = DateTime.Now;

		public DateTime DateDue
		{
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

		//private double GetAmountPaid()
		//{
		//	if (Checkouts != null)
		//	{
		//		return Checkouts.Sum(x => x.AmountPaid);
		//	}
		//	else
		//	{
		//		return 0.0;
		//	}

		//}

		//[NotMapped]
		//private string InvoiceStatus => GetAmountPaid() < InvoiceAmount ? "Paid" : "Not Paid";

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
