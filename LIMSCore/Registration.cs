using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Registration
    {
        public Registration()
        {
            Parcel = new HashSet<Parcel>();
            SpatialUnitSetRegistration = new HashSet<SpatialUnitSetRegistration>();
        }

        public int Id { get; set; }
        public string Jurisdiction { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationSection { get; set; }
        public string RegistrationType { get; set; }
        public string TitleNo { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
        public ICollection<SpatialUnitSetRegistration> SpatialUnitSetRegistration { get; set; }
    }
}
