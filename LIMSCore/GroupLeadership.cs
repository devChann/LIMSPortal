using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupLeadership
    {
        public GroupLeadership()
        {
            GroupGroupLeadership = new HashSet<GroupGroupLeadership>();
            GroupLeadershipPerson = new HashSet<GroupLeadershipPerson>();
        }

        public int Id { get; set; }
        public string LeadershipRole { get; set; }
        public DateTime LeadershipSince { get; set; }
        public string LeadershipStatus { get; set; }
        public DateTime LeadershipUntil { get; set; }
        public int PersonId { get; set; }

        public ICollection<GroupGroupLeadership> GroupGroupLeadership { get; set; }
        public ICollection<GroupLeadershipPerson> GroupLeadershipPerson { get; set; }
    }
}
