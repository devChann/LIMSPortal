using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.ViewModels.MpesaModels
{
    public class PaymentsListViewModel
    {       
        
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Amount")]
        public string Amount { get; set; }

        [Display(Name = "Checkout ID")]
        public string CheckOutID { get; set; }

        [Display(Name = "Receipt Number")]
        public string ReceiptNumber { get; set; }
    }
}
