using System;
using System.Collections.Generic;

namespace LIMSCore.Entities
{
    public partial class BuruParcels
    {
        public double? Area2 { get; set; }
        public string Boundary { get; set; }
        public double? ShapeLeng { get; set; }
        public double? ShapeArea { get; set; }
        public int? AmountPai { get; set; }
        public string ParcelOwn { get; set; }
        public string Status { get; set; }
        public byte[] Geometry { get; set; }
        public int Id { get; set; }

        public Parcel Parcel { get; set; }
    }
}
