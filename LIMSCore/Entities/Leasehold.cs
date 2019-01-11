using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Leasehold
    {
        public int LeaseholdId { get; set; }
        public DateTime LeasePeriod { get; set; }
        public string Lessor { get; set; }

        public int TenureId { get; set; }
        public Tenure Tenure { get; set; }
    }
}
