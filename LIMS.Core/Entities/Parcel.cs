using LIMS.Core.Billing;
using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Parcel
    {
        public Parcel()
        {
            Operations = new HashSet<Operation>();
			Invoices = new HashSet<Invoice>();
        }

        public int ParcelId { get; set; }        
        public double? Area { get; set; }                  
        public string ParcelNum { get; set; }

		public int AdministrationId { get; set; }
		public Administration Administration { get; set; }

		public int LandUseId { get; set; }
		public LandUse LandUse { get; set; }

		public int OwnerId { get; set; }
		public Owner Owner { get; set; }

		public int OwnershipRightId { get; set; }
		public OwnershipRight OwnershipRight { get; set; }

		public int? RateId { get; set; }
		public Rate Rate { get; set; }

		public int RegistrationId { get; set; }
		public Registration Registration { get; set; }

		public int ResponsibilityId { get; set; }
		public Responsibility Responsibility { get; set; }

		public int RestrictionId { get; set; }
		public Restriction Restriction { get; set; }

		public int SpatialUnitId { get; set; }
		public SpatialUnit SpatialUnit { get; set; }

		public int TenureId { get; set; }
		public Tenure Tenure { get; set; }

		public int ValuationId { get; set; }
		public Valuation Valuation { get; set; }

        public ICollection<Operation> Operations { get; set; }
		public ICollection<Invoice> Invoices { get; set; }
	}
}
