using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Freehold
    {
        public int FreeholdId { get; set; }

        public int TenureId { get; set; }
        public Tenure Tenure { get; set; }
    }
}
