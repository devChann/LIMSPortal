﻿using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Survey
    {
        public Survey()
        {
            SpatialUnits = new HashSet<SpatialUnit>();
        }

        public Guid SurveyId { get; set; }
        public string CompsNo { get; set; }
        public DateTime? DateOfEntry { get; set; }
       
        public int PdpRefNo { get; set; }
        public string PlansNo { get; set; }
        public string SurveyorsName { get; set; }
        public string TypeOfSurvey { get; set; }

		public string ParcelNumber { get; set; }

		public ICollection<SpatialUnit> SpatialUnits { get; set; }
    }
}
