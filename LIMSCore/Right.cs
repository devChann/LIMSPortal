using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Right
    {
        public int Id { get; set; }
        public string RightType { get; set; }
        public int Rrrid { get; set; }

        public Rrr Rrr { get; set; }
    }
}
