using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Charge
    {
        public Charge()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public int ChargeId { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public string Lender { get; set; }
        public int Ranking { get; set; }
        public int RepaymentTerm { get; set; }

        public ICollection<Restriction> Restrictions { get; set; }
    }
}
