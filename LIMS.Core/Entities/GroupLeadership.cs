using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class GroupLeadership
    {
        public GroupLeadership()
        {
            GroupGroupLeadership = new HashSet<GroupGroupLeadership>();
			PersonGroupLeaderships = new HashSet<PersonGroupLeadership>();
        }

        public Guid GroupLeadershipId { get; set; }
        public string LeadershipRole { get; set; }
        public DateTime LeadershipSince { get; set; }
        public string LeadershipStatus { get; set; }
        public DateTime LeadershipUntil { get; set; }
        public Guid PersonId { get; set; }

        public ICollection<GroupGroupLeadership> GroupGroupLeadership { get; set; }
        public ICollection<PersonGroupLeadership> PersonGroupLeaderships { get; set; }
    }
}
