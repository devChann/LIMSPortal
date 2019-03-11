﻿using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
	public partial class BuildingRegulation
    {
        public BuildingRegulation()
        {
            LandUses = new HashSet<LandUse>();
        }

        public Guid BuildingRegulationId { get; set; }
        public double GCR { get; set; }
        public double PCR { get; set; }
        public double PlotFrontage { get; set; }

        public ICollection<LandUse> LandUses { get; set; }
    }
}
