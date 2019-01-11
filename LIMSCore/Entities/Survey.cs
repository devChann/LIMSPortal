using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Survey
    {
        public Survey()
        {
            SpatialUnits = new HashSet<SpatialUnit>();
        }

        public int SurveyId { get; set; }
        public string CompsNo { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public int ParcelId { get; set; }
        public int PdpRefNo { get; set; }
        public string PlansNo { get; set; }
        public string SurveyorsName { get; set; }
        public string TypeOfSurvey { get; set; }

        public ICollection<SpatialUnit> SpatialUnits { get; set; }
    }
}
