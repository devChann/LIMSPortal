using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Valuation
    {
        public Valuation()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int ValuationId { get; set; }
        public string Remarks { get; set; }
        public string SerialNo { get; set; }
        public string ValuationBookNo { get; set; }
        public DateTime? ValuationDate { get; set; }
        public double? Value { get; set; }
        public string Valuer { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
