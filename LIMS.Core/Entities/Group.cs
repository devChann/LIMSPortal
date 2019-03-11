using System;

namespace LIMS.Core.Entities
{
	public partial class Group
    {
        public Guid GroupId { get; set; }
        public string County { get; set; }
        public string GroupType { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
