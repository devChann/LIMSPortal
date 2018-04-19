using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Service
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public bool IsComplete { get; set; }
        public int Opid { get; set; }
        public int? Progress { get; set; }

        public Operation Op { get; set; }
    }
}
