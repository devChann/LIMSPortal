using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Survey
    {
        public Survey()
        {
            SpatialUnit = new HashSet<SpatialUnit>();
        }

        public int Id { get; set; }
        public string CompsNo { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int ParcelId { get; set; }
        public int PdprefNo { get; set; }
        public string PlansNo { get; set; }
        public string SurveyorsName { get; set; }
        public string TypeOfSurvey { get; set; }

        public ICollection<SpatialUnit> SpatialUnit { get; set; }
    }
}
