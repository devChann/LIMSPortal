using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class MapIndex
    {
        public MapIndex()
        {
            SpatialUnit = new HashSet<SpatialUnit>();
        }

        public int Id { get; set; }
        public string MapSheetNum { get; set; }
        public int ParcelId { get; set; }

        public ICollection<SpatialUnit> SpatialUnit { get; set; }
    }
}
