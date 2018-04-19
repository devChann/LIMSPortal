using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Rates
    {
        public Rates()
        {
            Payments = new HashSet<Payments>();
        }

        public decimal? Amount { get; set; }
        public int Id { get; set; }

        public Parcel Parcel { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
