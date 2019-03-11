using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Building
    {
        public Guid BuildingId { get; set; }
		public string StreetAddress { get; set; }

		public Guid ApartmentId { get; set; }
        public Guid SpatialUnitId { get; set; }       

        public Apartment Apartment { get; set; }
        public SpatialUnit SpatialUnit { get; set; }
    }
}
