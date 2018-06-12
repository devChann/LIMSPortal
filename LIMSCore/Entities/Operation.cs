using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Operation
    {
        public Operation()
        {
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parcelid { get; set; }

        public Parcel Parcel { get; set; }
        public ICollection<Service> Service { get; set; }
    }
}
