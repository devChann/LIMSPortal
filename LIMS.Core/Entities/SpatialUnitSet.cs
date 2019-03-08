using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class SpatialUnitSet
    {
        public SpatialUnitSet()
        {
            SpatialUnits = new HashSet<SpatialUnit>();
            SpatialUnitSetRegistrations = new HashSet<SpatialUnitSetRegistration>();
        }

        public int SpatialUnitSetId { get; set; }
        public string Label { get; set; }

        public ICollection<SpatialUnit> SpatialUnits { get; set; }
        public ICollection<SpatialUnitSetRegistration> SpatialUnitSetRegistrations { get; set; }
    }
}
