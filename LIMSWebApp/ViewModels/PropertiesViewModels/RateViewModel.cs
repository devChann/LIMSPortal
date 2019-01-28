using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.PropertiesViewModels
{
    public class RateViewModel
    {
        [DisplayName("Parcel Number")]
        public string ParcelNumber { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Parcel Owner")]
        public string OwnerName { get; set; }

        [DisplayName("Owner Id")]
        public string OwnerId { get; set; }

        [DisplayName("Owner PIN")]
        public string OwnerPIN { get; set; }

        [DisplayName("Financial Year")]
        public string FinancialYear { get; set; }

        [DisplayName("Pending Amount")]
        public string PendingRate { get; set; }

		[DisplayName("Invoice ID")]
		public Guid InvoiceID { get; set; }

		[DisplayName("Invoice Number")]
		public string InvoiceNumber { get; set; }

	}
}
