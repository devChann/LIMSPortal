using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Reserve
    {
        public Reserve()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public int ReserveId { get; set; }
        public string ComplianceStatus { get; set; }
        public string EnforcingAuthority { get; set; }
        public string ReserveType { get; set; }

        public ICollection<Restriction> Restrictions { get; set; }
    }
}
