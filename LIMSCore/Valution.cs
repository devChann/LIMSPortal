using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Valution
    {
        public Valution()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string Remarks { get; set; }
        public string SerialNo { get; set; }
        public string ValuationBookNo { get; set; }
        public DateTime? ValuationDate { get; set; }
        public double? Value { get; set; }
        public string Valuer { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
    }
}
