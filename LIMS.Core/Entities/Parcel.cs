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

        public Guid ParcelId { get; set; }        
        public double? Area { get; set; }                  
        public string ParcelNum { get; set; }

		public Guid AdministrationId { get; set; }
		public Administration Administration { get; set; }

		public Guid LandUseId { get; set; }
		public LandUse LandUse { get; set; }

		public Guid OwnerId { get; set; }
		public Owner Owner { get; set; }

		public Guid OwnershipRightId { get; set; }
		public OwnershipRight OwnershipRight { get; set; }

		public Guid RateId { get; set; }
		public Rate Rate { get; set; }

		public Guid RegistrationId { get; set; }
		public Registration Registration { get; set; }

		public Guid ResponsibilityId { get; set; }
		public Responsibility Responsibility { get; set; }

		public Guid RestrictionId { get; set; }
		public Restriction Restriction { get; set; }

		public Guid SpatialUnitId { get; set; }
		public SpatialUnit SpatialUnit { get; set; }

		public Guid TenureId { get; set; }
		public Tenure Tenure { get; set; }

		public Guid ValuationId { get; set; }
		public Valuation Valuation { get; set; }

        public ICollection<Operation> Operations { get; set; }
		public ICollection<Invoice> Invoices { get; set; }
	}
}
