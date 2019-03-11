using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class BoundaryBeacon
    {	

		public Guid BeaconId { get; set; }
        public Beacon Beacon { get; set; }

		public Guid BoundaryId { get; set; }
		public Boundary Boundary { get; set; }
    }
}
