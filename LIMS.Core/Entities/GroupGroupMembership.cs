using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class GroupGroupMembership
    {
		

		public Guid GroupId { get; set; }
		public Group Group { get; set; }

		public Guid GroupMembershipId { get; set; }
		public GroupMembership GroupMembership { get; set; }
    }
}
