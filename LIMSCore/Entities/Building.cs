using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Building
    {
        public int BuildingId { get; set; }
		public string StreetAddress { get; set; }

		public int ApartmentId { get; set; }
        public int SpatialUnitId { get; set; }       

        public Apartment Apartment { get; set; }
        public SpatialUnit SpatialUnit { get; set; }
    }
}
