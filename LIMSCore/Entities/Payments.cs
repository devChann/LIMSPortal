using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Payments
    {
        public int PaymentsId { get; set; }
        public decimal? Amount { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReceiptNo { get; set; }

        public int? ParcelId { get; set; }
        public Parcel Parcel { get; set; }
    }
}
