using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupGroupMembership
    {
		//public int GroupGroupMembershipId { get; set; }

		public int GroupId { get; set; }
		public Group Group { get; set; }

		public int GroupMembershipId { get; set; }
		public GroupMembership GroupMembership { get; set; }
    }
}
