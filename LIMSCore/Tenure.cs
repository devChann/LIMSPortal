using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Tenure
    {
        public Tenure()
        {
            Leasehold = new HashSet<Leasehold>();
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string TenureType { get; set; }

        public Freehold Freehold { get; set; }
        public ICollection<Leasehold> Leasehold { get; set; }
        public ICollection<Parcel> Parcel { get; set; }
    }
}
