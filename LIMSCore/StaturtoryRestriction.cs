using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class StaturtoryRestriction
    {
        public StaturtoryRestriction()
        {
            Restriction = new HashSet<Restriction>();
        }

        public int Id { get; set; }
        public string NatureOfRestriction { get; set; }
        public string RestrictingAuthority { get; set; }

        public ICollection<Restriction> Restriction { get; set; }
    }
}
