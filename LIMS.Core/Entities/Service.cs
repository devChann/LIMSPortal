using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Service
    {
        public Guid ServiceId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsComplete { get; set; }        
        public Guid Progress { get; set; }

		public Guid OperationId { get; set; }
		public Operation Operation { get; set; }
    }
}
