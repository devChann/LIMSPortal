using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Beacon
    {
        public Beacon()
        {
            BoundaryBeacons = new HashSet<BoundaryBeacon>();
        }

        public int BeaconId { get; set; }
        public string BeaconNum { get; set; }
        public string BeaconType { get; set; }
        public DateTime DateSet { get; set; }
        public double Hcoordinate { get; set; }
        public string HorizontalDatum { get; set; }
        public string VerticalDatum { get; set; }
        public double Xcoordinate { get; set; }
        public double Ycoordinate { get; set; }

        public ICollection<BoundaryBeacon> BoundaryBeacons { get; set; }
    }
}
