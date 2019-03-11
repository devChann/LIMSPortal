using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class SpatialUnitSetRegistration
    {
        public Guid RegistrationId { get; set; }     
        public Registration Registration { get; set; }

		public Guid SpatialUnitSetId { get; set; }
		public SpatialUnitSet SpatialUnitSet { get; set; }
    }
}
