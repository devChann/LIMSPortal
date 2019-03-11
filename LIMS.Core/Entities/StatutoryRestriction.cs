using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class StatutoryRestriction
    {
        public StatutoryRestriction()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public Guid StatutoryRestrictionId { get; set; }
        public string NatureOfRestriction { get; set; }
        public string RestrictingAuthority { get; set; }

        public ICollection<Restriction> Restrictions { get; set; }
    }
}
