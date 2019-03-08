using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class OwnershipRight
    {
        public OwnershipRight()
        {
            Parcels = new HashSet<Parcel>();
        }

        public int OwnershipRightId { get; set; }
        public string RightType { get; set; }

        public ICollection<Parcel> Parcels { get; set; }
    }
}
