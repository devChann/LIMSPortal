using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class PersonGroupMembership
    {
        public int GroupMembershipId { get; set; }
        public int PersonId { get; set; }

        public GroupMembership GroupMembership { get; set; }
        public Person Person { get; set; }
    }
}
