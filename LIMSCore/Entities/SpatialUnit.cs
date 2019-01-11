using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class SpatialUnit
    {
        public SpatialUnit()
        {
            Buildings = new HashSet<Building>();
            Parcels = new HashSet<Parcel>();
        }

        public int SpatialUnitId { get; set; }
        public double? Area { get; set; }       
        public string Label { get; set; }
        public string Layer { get; set; }
        public double? Length { get; set; }       
        public int PreliminaryUnitId { get; set; }
        public string ReferencePoint { get; set; }       
        public string SpatialUnitType { get; set; }      
        public double? Volume { get; set; }

		public int BoundaryId { get; set; }
		public Boundary Boundary { get; set; }

		public int MapIndexId { get; set; }
		public MapIndex MapIndex { get; set; }

		public int SpatialUnitSetId { get; set; }
		public SpatialUnitSet SpatialUnitSet { get; set; }

		public int SurveyId { get; set; }
		public Survey Survey { get; set; }

        public ICollection<Building> Buildings { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
}
