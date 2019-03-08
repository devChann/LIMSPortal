using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Service
    {
        public int ServiceId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsComplete { get; set; }        
        public int? Progress { get; set; }

		public int OperationId { get; set; }
		public Operation Operation { get; set; }
    }
}
