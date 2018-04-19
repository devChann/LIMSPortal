using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class SpatialUnitSetRegistration
    {
        public int RegistrationId { get; set; }
        public int SpatialUnitSetId { get; set; }

        public Registration Registration { get; set; }
        public SpatialUnitSet SpatialUnitSet { get; set; }
    }
}
