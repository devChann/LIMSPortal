using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Administration
    {
        public Administration()
        {
            Parcels = new HashSet<Parcel>();
        }

        public Guid AdministrationId { get; set; }
        public string BlockName { get; set; }
        public string DistrictName { get; set; }
        public string LocationName { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
