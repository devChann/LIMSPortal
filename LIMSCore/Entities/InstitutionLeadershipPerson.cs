using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class InstitutionLeadershipPerson
    {
        public int InstitutionLeadershipId { get; set; }
        public int PersonId { get; set; }

        public InsitutionLeadership InstitutionLeadership { get; set; }
        public Person Person { get; set; }
    }
}
