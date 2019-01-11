using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class Apartment
    {
        public Apartment()
        {
            Building = new HashSet<Building>();
        }

        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; }

        public ICollection<Building> Building { get; set; }
    }
}
