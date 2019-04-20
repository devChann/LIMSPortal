using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class GroupMembership
    {
        public GroupMembership()
        {
            GroupGroupMemberships = new HashSet<GroupGroupMembership>();
            PersonGroupMemberships = new HashSet<PersonGroupMembership>();
        }

        public Guid GroupMembershipId { get; set; }
        public double MembershipShare { get; set; }
        public DateTime MembershipSince { get; set; }
        public string MembershipStatus { get; set; }
        public DateTime MembershipUntil { get; set; }

        public ICollection<GroupGroupMembership> GroupGroupMemberships { get; set; }
        public ICollection<PersonGroupMembership> PersonGroupMemberships { get; set; }
    }
}
