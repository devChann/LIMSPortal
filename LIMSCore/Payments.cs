using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Payments
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int Rateid { get; set; }
        public string ReceiptNo { get; set; }

        public Rates Rate { get; set; }
    }
}
