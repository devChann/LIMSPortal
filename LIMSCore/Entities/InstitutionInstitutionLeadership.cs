using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class InstitutionInstitutionLeadership
    {
        public int InstitutionLeadershipId { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public InsitutionLeadership InstitutionLeadership { get; set; }
    }
}
