using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class BoundaryBeacon
    {
        public int BoundaryId { get; set; }
        public int BeaconId { get; set; }

        public Beacon Beacon { get; set; }
        public Boundary Boundary { get; set; }
    }
}
