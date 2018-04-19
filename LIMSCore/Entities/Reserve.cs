using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Reserve
    {
        public Reserve()
        {
            Restriction = new HashSet<Restriction>();
        }

        public int Id { get; set; }
        public string ComplianceStatus { get; set; }
        public string EnforcingAuthority { get; set; }
        public string ReserveType { get; set; }

        public ICollection<Restriction> Restriction { get; set; }
    }
}
