using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Operation
    {
        public Operation()
        {
            Services = new HashSet<Service>();
        }

        public Guid OperationId { get; set; }
		public string OperationName { get; set; }

        public Guid ParcelId { get; set; }
        public Parcel Parcel { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
