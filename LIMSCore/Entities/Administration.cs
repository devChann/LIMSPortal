using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Administration
    {
        public Administration()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int AdministrationId { get; set; }
        public string BlockName { get; set; }
        public string DistrictName { get; set; }
        public string LocationName { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
