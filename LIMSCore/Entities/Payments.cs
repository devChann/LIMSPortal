using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LIMSCore.Entities
{
    public partial class Payments
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string ModeOfPayment { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int RateId { get; set; }
        public string ReceiptNo { get; set; }

        public int ParcelId { get; set; }

        public Rates Rate { get; set; }

        public Parcel Parcel { get; set; }

        
    }
}
