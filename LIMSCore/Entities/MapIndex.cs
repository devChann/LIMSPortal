using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class MapIndex
    {
        public MapIndex()
        {
            SpatialUnits = new HashSet<SpatialUnit>();
        }

        public int MapIndexId { get; set; }
        public string MapSheetNum { get; set; }
       

        public ICollection<SpatialUnit> SpatialUnits { get; set; }
    }
}
