using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.ViewModels.LIMSViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int Rateid { get; set; }
        public string ReceiptNo { get; set; }
    }
}
