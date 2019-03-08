using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Institution
    {
        public Institution()
        {
            InstitutionInstitutionLeadership = new HashSet<InstitutionInstitutionLeadership>();
        }

        public int InstitutionId { get; set; }
        public string InstitutionType { get; set; }

        public ICollection<InstitutionInstitutionLeadership> InstitutionInstitutionLeadership { get; set; }
    }
}
