using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Responsibility
    {
        public Responsibility()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string PerformanceRequirement { get; set; }
        public string ResponsibilityType { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
    }
}
