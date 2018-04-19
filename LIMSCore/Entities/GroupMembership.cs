using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupMembership
    {
        public GroupMembership()
        {
            GroupGroupMembership = new HashSet<GroupGroupMembership>();
            PersonGroupMembership = new HashSet<PersonGroupMembership>();
        }

        public int Id { get; set; }
        public double MembershipShare { get; set; }
        public DateTime MembershipSince { get; set; }
        public string MembershipStatus { get; set; }
        public DateTime MembershipUntil { get; set; }

        public ICollection<GroupGroupMembership> GroupGroupMembership { get; set; }
        public ICollection<PersonGroupMembership> PersonGroupMembership { get; set; }
    }
}
