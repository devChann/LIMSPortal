using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Beacon
    {
        public Beacon()
        {
            BoundaryBeacon = new HashSet<BoundaryBeacon>();
        }

        public int Id { get; set; }
        public string BeaconNum { get; set; }
        public string BeaconType { get; set; }
        public DateTime DateSet { get; set; }
        public double Hcoordinate { get; set; }
        public string HorizontalDatum { get; set; }
        public string VerticalDatum { get; set; }
        public double Xcoordinate { get; set; }
        public double Ycoordinate { get; set; }

        public ICollection<BoundaryBeacon> BoundaryBeacon { get; set; }
    }
}
