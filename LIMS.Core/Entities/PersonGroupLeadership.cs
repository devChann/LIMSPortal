using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class PersonGroupLeadership
	{
		//public int PersonGroupLeadershipId { get; set; }

		public Guid GroupLeadershipId { get; set; }       
        public GroupLeadership GroupLeadership { get; set; }

		public Guid PersonId { get; set; }
		public Person Person { get; set; }
    }
}
