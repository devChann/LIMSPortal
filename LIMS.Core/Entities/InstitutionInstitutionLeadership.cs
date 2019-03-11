using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class InstitutionInstitutionLeadership
    {

		public Guid InstitutionLeadershipId { get; set; }
        public Guid InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public InsitutionLeadership InstitutionLeadership { get; set; }
    }
}
