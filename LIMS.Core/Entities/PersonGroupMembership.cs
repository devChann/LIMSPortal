using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class PersonGroupMembership
    {
		//public int PersonGroupMembershipId { get; set; }

		public Guid GroupMembershipId { get; set; }     
        public GroupMembership GroupMembership { get; set; }

		public Guid PersonId { get; set; }
		public Person Person { get; set; }
    }
}
