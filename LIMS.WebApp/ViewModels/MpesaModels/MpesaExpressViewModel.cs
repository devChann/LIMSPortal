using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewModels.MpesaModels
{
    public class MpesaExpressViewModel
    {
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Amount")]
        public string Amount { get; set; }
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
    }
}
