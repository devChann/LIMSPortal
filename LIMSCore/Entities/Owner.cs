using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Owner
    {
        public Owner()
        {
            GroupOw = new HashSet<GroupOw>();
            Parcel = new HashSet<Parcel>();
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerType { get; set; }
        public string PIN { get; set; }
        public string PostalAddress { get; set; }
        public string TelephoneAddress { get; set; }

        public ICollection<GroupOw> GroupOw { get; set; }
        public ICollection<Parcel> Parcel { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
