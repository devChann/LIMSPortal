using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class InsitutionLeadership
    {
        public InsitutionLeadership()
        {
            InstitutionInstitutionLeadership = new HashSet<InstitutionInstitutionLeadership>();
			PersonInstitutionLeaderships = new HashSet<PersonInstitutionLeadership>();
        }

        public int Id { get; set; }
        public DateTime MemberSince { get; set; }
        public DateTime MemberUntil { get; set; }
        public string MembershipRole { get; set; }
        public string MembershipStatus { get; set; }

        public ICollection<InstitutionInstitutionLeadership> InstitutionInstitutionLeadership { get; set; }
        public ICollection<PersonInstitutionLeadership> PersonInstitutionLeaderships { get; set; }
    }
}
