using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class SpatialUnit
    {
        public SpatialUnit()
        {
            Building = new HashSet<Building>();
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public double? Area { get; set; }
        public int BoundaryId { get; set; }
        public string Label { get; set; }
        public string Layer { get; set; }
        public double? Length { get; set; }
        public int MapIndexId { get; set; }
        public int PreliminaryUnitId { get; set; }
        public string ReferencePoint { get; set; }
        public int SpatialUnitSetId { get; set; }
        public string SpatialUnitType { get; set; }
        public int SurveyClassId { get; set; }
        public double? Volume { get; set; }

        public Boundary Boundary { get; set; }
        public MapIndex MapIndex { get; set; }
        public SpatialUnitSet SpatialUnitSet { get; set; }
        public Survey SurveyClass { get; set; }
        public ICollection<Building> Building { get; set; }
        public ICollection<Parcel> Parcel { get; set; }
    }
}
