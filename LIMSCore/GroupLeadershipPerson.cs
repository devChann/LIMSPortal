using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class GroupLeadershipPerson
    {
        public int GroupLeadershipId { get; set; }
        public int PersonId { get; set; }

        public GroupLeadership GroupLeadership { get; set; }
        public Person Person { get; set; }
    }
}
