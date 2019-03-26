using System;
using System.Collections.Generic;

namespace LIMS.Core.Entities
{
    public partial class Tenure
    {
        public Guid TenureId { get; set; }
        public TenureType TenureType { get; set; } //can be leashold or freehold
		public DateTime TenureBeginDate { get; set; }
		public DateTime TenureEndDate { get; set; }
		public string Lessor { get; set; }
		public Parcel Parcel { get; set; }
    }

	public enum TenureType
	{
		Leashold, Freehold
	}
}
