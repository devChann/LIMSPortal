using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class SpatialUnit
    {
        public SpatialUnit()
        {
            Buildings = new HashSet<Building>();
            Parcels = new HashSet<Parcel>();
        }

        public Guid SpatialUnitId { get; set; }
        public double? Area { get; set; }       
        public string Label { get; set; }
        public string Layer { get; set; }
        public double? Length { get; set; }       
        public int PreliminaryUnitId { get; set; }
        public string ReferencePoint { get; set; }       
        public string SpatialUnitType { get; set; }      
        public double? Volume { get; set; }

		public Guid BoundaryId { get; set; }
		public Boundary Boundary { get; set; }

		public Guid MapIndexId { get; set; }
		public MapIndex MapIndex { get; set; }

		public Guid SpatialUnitSetId { get; set; }
		public SpatialUnitSet SpatialUnitSet { get; set; }

		public Guid SurveyId { get; set; }
		public Survey Survey { get; set; }

        public ICollection<Building> Buildings { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
}
