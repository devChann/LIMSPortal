using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Operation
    {
        public Operation()
        {
            Services = new HashSet<Service>();
        }

        public int OperationId { get; set; }
		public string OperationName { get; set; }

        public int? ParcelId { get; set; }
        public Parcel Parcel { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
