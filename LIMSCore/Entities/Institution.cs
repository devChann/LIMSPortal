using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Institution
    {
        public Institution()
        {
            InstitutionInstitutionLeadership = new HashSet<InstitutionInstitutionLeadership>();
        }

        public int Id { get; set; }
        public string InstitutionType { get; set; }

        public ICollection<InstitutionInstitutionLeadership> InstitutionInstitutionLeadership { get; set; }
    }
}
