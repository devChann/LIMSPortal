using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Restriction
    {
        public Restriction()
        {
            Parcels = new HashSet<Parcel>();
        }

        public Guid RestrictionId { get; set; }                       
        public string RestrictionType { get; set; }       

		public Guid ChargeId { get; set; }
		public Charge Charge { get; set; }

		public Guid MortgageId { get; set; }
		public Mortgage Mortgage { get; set; }

		public Guid ReserveId { get; set; }
		public Reserve Reserve { get; set; }

		public Guid StatutoryRestrictionId { get; set; }
		public StatutoryRestriction StatutoryRestriction { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
