﻿using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class SpatialUnitSetRegistration
    {
        public int RegistrationId { get; set; }     
        public Registration Registration { get; set; }

		public int SpatialUnitSetId { get; set; }
		public SpatialUnitSet SpatialUnitSet { get; set; }
    }
}