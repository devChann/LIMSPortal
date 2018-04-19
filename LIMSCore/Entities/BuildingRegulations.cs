using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class BuildingRegulations
    {
        public BuildingRegulations()
        {
            LandUse = new HashSet<LandUse>();
        }

        public int Id { get; set; }
        public double Gcr { get; set; }
        public double Pcr { get; set; }
        public double PlotFrontage { get; set; }

        public ICollection<LandUse> LandUse { get; set; }
    }
}
