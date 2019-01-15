using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class PersonGroupLeadership
	{
		public int PersonGroupLeadershipId { get; set; }
		public int GroupLeadershipId { get; set; }       
        public GroupLeadership GroupLeadership { get; set; }

		public int PersonId { get; set; }
		public Person Person { get; set; }
    }
}
