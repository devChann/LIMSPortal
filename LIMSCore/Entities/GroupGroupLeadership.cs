using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupGroupLeadership
    {
		public int GroupGroupLeadershipId { get; set; }

		public int GroupId { get; set; }
		public Group Group { get; set; }

		public int GroupLeadershipId { get; set; }
        public GroupLeadership GroupLeadership { get; set; }
    }
}
