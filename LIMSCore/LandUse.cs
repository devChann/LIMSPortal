using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class LandUse
    {
        public LandUse()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public int BuildingRegulationsId { get; set; }
        public DateTime? EndDate { get; set; }
        public string LandUseStatus { get; set; }
        public string LandUseType { get; set; }
        public string RegulationAgency { get; set; }
        public DateTime? StartDate { get; set; }
        public int ZoneId { get; set; }

        public BuildingRegulations BuildingRegulations { get; set; }
        public Zone Zone { get; set; }
        public ICollection<Parcel> Parcel { get; set; }
    }
}
