using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Parcel
    {
        public Parcel()
        {
            Operation = new HashSet<Operation>();
            Payments = new HashSet<Payments>();
        }

        public int Id { get; set; }
        public int Administrationid { get; set; }
        public double? Area { get; set; }
        public int LandUseId { get; set; }
        public int OwnerId { get; set; }
        public int OwnershipRights { get; set; }
        public string ParcelNum { get; set; }
        public int RegistrationId { get; set; }
        public int Responsibilities { get; set; }
        public int Restrictions { get; set; }
        public int SpatialUnitId { get; set; }
        public int TenureId { get; set; }
        public int ValuationId { get; set; }
        public int? RateId { get; set; }

        public Administration Administration { get; set; }
        public LandUse LandUse { get; set; }
        public Owner Owner { get; set; }
        public OwnershipRights OwnershipRightsNavigation { get; set; }
        public Rates Rate { get; set; }
        public Registration Registration { get; set; }
        public Responsibility ResponsibilitiesNavigation { get; set; }
        public Restriction RestrictionsNavigation { get; set; }
        public SpatialUnit SpatialUnit { get; set; }
        public Tenure Tenure { get; set; }
        public Valution Valuation { get; set; }
        public ICollection<Operation> Operation { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
