using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Rrr
    {
        public Rrr()
        {
            Responsibility = new HashSet<Responsibility>();
            Restriction = new HashSet<Restriction>();
            Right = new HashSet<Right>();
        }

        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Expires { get; set; }
        public string Rrrtype { get; set; }
        public double Share { get; set; }
        public DateTime StartDate { get; set; }
        public int? Ownerid { get; set; }

        public Owner Owner { get; set; }
        public ICollection<Responsibility> Responsibility { get; set; }
        public ICollection<Restriction> Restriction { get; set; }
        public ICollection<Right> Right { get; set; }
    }
}
