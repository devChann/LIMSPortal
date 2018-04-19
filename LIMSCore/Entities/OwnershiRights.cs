using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class OwnershiRights
    {
        public OwnershiRights()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string RightType { get; set; }

        public ICollection<Parcel> Parcel { get; set; }
    }
}
