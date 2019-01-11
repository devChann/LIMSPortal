using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Person
    {
        public Person()
        {
			PersonGroupLeaderships = new HashSet<PersonGroupLeadership>();
			PersonInstitutionLeaderships = new HashSet<PersonInstitutionLeadership>();
            PersonGroupMemberships = new HashSet<PersonGroupMembership>();
        }

        public int PersonId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }       
        public string PersonType { get; set; }
        public string Phone { get; set; }
        public string PIN { get; set; }

		public int OwnerId { get; set; }
		public Owner Owner { get; set; }

        public ICollection<PersonGroupLeadership> PersonGroupLeaderships { get; set; }
        public ICollection<PersonInstitutionLeadership> PersonInstitutionLeaderships { get; set; }
        public ICollection<PersonGroupMembership> PersonGroupMemberships { get; set; }
    }
}
