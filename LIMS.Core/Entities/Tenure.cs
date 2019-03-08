using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Tenure
    {
        public Tenure()
        {
			Freeholds = new HashSet<Freehold>();
			Leaseholds = new HashSet<Leasehold>();
            Parcels = new HashSet<Parcel>();
        }

        public int TenureId { get; set; }
        public string TenureType { get; set; }

        public ICollection<Freehold> Freeholds { get; set; }
        public ICollection<Leasehold> Leaseholds { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
}
