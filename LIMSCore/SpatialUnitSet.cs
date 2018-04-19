using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class SpatialUnitSet
    {
        public SpatialUnitSet()
        {
            SpatialUnit = new HashSet<SpatialUnit>();
            SpatialUnitSetRegistration = new HashSet<SpatialUnitSetRegistration>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public ICollection<SpatialUnit> SpatialUnit { get; set; }
        public ICollection<SpatialUnitSetRegistration> SpatialUnitSetRegistration { get; set; }
    }
}
