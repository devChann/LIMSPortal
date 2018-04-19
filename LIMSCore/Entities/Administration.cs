using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Administration
    {
        public Administration()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string BlockName { get; set; }
        public string DistrictName { get; set; }
        public string LocationName { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
    }
}
