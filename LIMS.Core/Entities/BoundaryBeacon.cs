using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class BoundaryBeacon
    {
        
        public int BeaconId { get; set; }
        public Beacon Beacon { get; set; }

		public int BoundaryId { get; set; }
		public Boundary Boundary { get; set; }
    }
}
