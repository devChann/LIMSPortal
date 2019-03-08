using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class InstitutionInstitutionLeadership
    {
		//public int InstitutionInstitutionLeadershipId { get; set; }

		public int InstitutionLeadershipId { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public InsitutionLeadership InstitutionLeadership { get; set; }
    }
}
