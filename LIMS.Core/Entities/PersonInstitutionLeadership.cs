using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class PersonInstitutionLeadership
	{
		//public int PersonInstitutionLeadershipId { get; set; }

		public int InstitutionLeadershipId { get; set; }      
        public InsitutionLeadership InstitutionLeadership { get; set; }

		public int PersonId { get; set; }
		public Person Person { get; set; }
    }
}
