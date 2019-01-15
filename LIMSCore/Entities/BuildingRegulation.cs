using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
	public partial class BuildingRegulation
    {
        public BuildingRegulation()
        {
            LandUses = new HashSet<LandUse>();
        }

        public int BuildingRegulationId { get; set; }
        public double GCR { get; set; }
        public double PCR { get; set; }
        public double PlotFrontage { get; set; }

        public ICollection<LandUse> LandUses { get; set; }
    }
}
