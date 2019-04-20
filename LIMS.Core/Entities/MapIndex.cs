using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class MapIndex
    {
        public MapIndex()
        {
            SpatialUnits = new HashSet<SpatialUnit>();
        }

        public Guid MapIndexId { get; set; }
        public string MapSheetNum { get; set; }
       

        public ICollection<SpatialUnit> SpatialUnits { get; set; }
    }
}
