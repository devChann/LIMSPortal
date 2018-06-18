using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Rates
    {
        public Rates()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public decimal? Amount { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
    }
}
