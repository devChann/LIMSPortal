﻿using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class LandUse
    {
        public LandUse()
        {
            Parcels = new HashSet<Parcel>();
        }

        public Guid LandUseId { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
        public string LandUseStatus { get; set; }
        public string LandUseType { get; set; }
        public string RegulationAgency { get; set; }              

		public Guid BuildingRegulationId { get; set; }
		public BuildingRegulation BuildingRegulation { get; set; }

		public Guid ZoneId { get; set; }
		public Zone Zone { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
