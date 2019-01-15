using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class StatutoryRestriction
    {
        public StatutoryRestriction()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public int StatutoryRestrictionId { get; set; }
        public string NatureOfRestriction { get; set; }
        public string RestrictingAuthority { get; set; }

        public ICollection<Restriction> Restrictions { get; set; }
    }
}
