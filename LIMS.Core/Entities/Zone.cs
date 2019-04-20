using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Zone
    {
        public Zone()
        {
            LandUses = new HashSet<LandUse>();
        }

        public Guid ZoneId { get; set; }        
        public string ZoneType { get; set; }		

		public ICollection<LandUse> LandUses { get; set; }
    }
}
