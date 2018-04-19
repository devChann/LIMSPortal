using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Person
    {
        public Person()
        {
            GroupLeadershipPerson = new HashSet<GroupLeadershipPerson>();
            InstitutionLeadershipPerson = new HashSet<InstitutionLeadershipPerson>();
            PersonGroupMembership = new HashSet<PersonGroupMembership>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int OwnerId { get; set; }
        public string PersonType { get; set; }
        public string Phone { get; set; }
        public string Pin { get; set; }

        public Owner Owner { get; set; }
        public ICollection<GroupLeadershipPerson> GroupLeadershipPerson { get; set; }
        public ICollection<InstitutionLeadershipPerson> InstitutionLeadershipPerson { get; set; }
        public ICollection<PersonGroupMembership> PersonGroupMembership { get; set; }
    }
}
