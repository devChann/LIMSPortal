using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupGroupLeadership
    {
        public int GroupId { get; set; }
        public int GroupLeadershipId { get; set; }

        public GroupLeadership GroupLeadership { get; set; }
    }
}
