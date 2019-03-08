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

        public int RestrictionId { get; set; }                       
        public string RestrictionType { get; set; }       

		public int? ChargeId { get; set; }
		public Charge Charge { get; set; }

		public int? MortgageId { get; set; }
		public Mortgage Mortgage { get; set; }

		public int? ReserveId { get; set; }
		public Reserve Reserve { get; set; }

		public int? StatutoryRestrictionId { get; set; }
		public StatutoryRestriction StatutoryRestriction { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
