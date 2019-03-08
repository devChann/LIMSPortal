using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Rate
    {
        public Rate()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int RateId { get; set; }
        public decimal? Amount { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
