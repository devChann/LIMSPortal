using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Zone
    {
        public Zone()
        {
            LandUse = new HashSet<LandUse>();
        }

        public int Id { get; set; }
        public int RegulationId { get; set; }
        public string ZoneType { get; set; }

        public ICollection<LandUse> LandUse { get; set; }
    }
}
