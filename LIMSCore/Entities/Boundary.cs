﻿using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Boundary
    {
        public Boundary()
        {
            BoundaryBeacons = new HashSet<BoundaryBeacon>();
        }

        public int BoundaryId { get; set; }
        public string BoundaryType { get; set; }

        public SpatialUnit SpatialUnit { get; set; }
        public ICollection<BoundaryBeacon> BoundaryBeacons { get; set; }
    }
}
