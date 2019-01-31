using LIMSCore.Billing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.PropertiesViewModels
{
    public class PropertiesViewModel
    {
        [DisplayName("Parcel Number")]
        public string ParcelNum { get; set; }

        [DisplayName("Tenure Type")]
        public string TenureType { get; set; }

        [DisplayName("Land Rate/Rent")]
        public decimal? Rate { get; set; }

		public IEnumerable<Invoice> Invoices { get; set; }
	}
}
