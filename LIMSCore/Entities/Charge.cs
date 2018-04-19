using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Charge
    {
        public Charge()
        {
            Restriction = new HashSet<Restriction>();
        }

        public int Id { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public string Lender { get; set; }
        public int Ranking { get; set; }
        public int RepaymentTerm { get; set; }

        public ICollection<Restriction> Restriction { get; set; }
    }
}
