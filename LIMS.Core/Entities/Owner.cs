using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Owner
    {
        public Owner()
        {
            Groups = new HashSet<Group>();
            Parcels = new HashSet<Parcel>();
            Persons = new HashSet<Person>();
        }

        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string OwnerType { get; set; }
        public string PIN { get; set; }
        public string PostalAddress { get; set; }
        public string TelephoneAddress { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
