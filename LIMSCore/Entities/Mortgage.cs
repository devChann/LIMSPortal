using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Mortgage
    {
        public Mortgage()
        {
            Restrictions = new HashSet<Restriction>();
        }

        public int MortgageId { get; set; }
        public double Amount { get; set; }       
        public double InterestRate { get; set; }
        public string Lender { get; set; }
        public int Ranking { get; set; }
        public int RepaymentTerm { get; set; }

        public ICollection<Restriction> Restrictions { get; set; }
    }
}
