using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class LandUse
    {
        public LandUse()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int LandUseId { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
        public string LandUseStatus { get; set; }
        public string LandUseType { get; set; }
        public string RegulationAgency { get; set; }              

		public int BuildingRegulationId { get; set; }
		public BuildingRegulation BuildingRegulation { get; set; }

		public int ZoneId { get; set; }
		public Zone Zone { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
