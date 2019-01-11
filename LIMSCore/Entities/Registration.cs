using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Registration
    {
        public Registration()
        {
            Parcels = new HashSet<Parcel>();
            SpatialUnitSetRegistrations = new HashSet<SpatialUnitSetRegistration>();
        }

        public int RegistrationId { get; set; }
        public string Jurisdiction { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationSection { get; set; }
        public string RegistrationType { get; set; }
        public string TitleNo { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
        public ICollection<SpatialUnitSetRegistration> SpatialUnitSetRegistrations { get; set; }
    }
}
