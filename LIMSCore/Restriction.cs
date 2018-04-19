using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Restriction
    {
        public Restriction()
        {
            Parcel = new HashSet<Parcel>();
        }

        public int Id { get; set; }
        public string RestrictionType { get; set; }
        public int? Morgageid { get; set; }
        public int? ReserveId { get; set; }
        public int? ChrageId { get; set; }
        public int? Statutoryid { get; set; }
        public int? LandUseId { get; set; }

        public Charge Chrage { get; set; }
        public Mortgage Morgage { get; set; }
        public Reserve Reserve { get; set; }
        public StaturtoryRestriction Statutory { get; set; }
        public ICollection<Parcel> Parcel { get; set; }
    }
}
