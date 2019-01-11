using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Responsibility
    {
        public Responsibility()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int ResponsibilityId { get; set; }
        public string PerformanceRequirement { get; set; }
        public string ResponsibilityType { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
