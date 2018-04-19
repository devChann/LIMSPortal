using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Boundary
    {
        public Boundary()
        {
            BoundaryBeacon = new HashSet<BoundaryBeacon>();
        }

        public int Id { get; set; }
        public string BoundaryType { get; set; }

        public SpatialUnit SpatialUnit { get; set; }
        public ICollection<BoundaryBeacon> BoundaryBeacon { get; set; }
    }
}
