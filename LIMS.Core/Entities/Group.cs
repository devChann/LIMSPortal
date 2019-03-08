namespace LIMS.Core.Entities
{
	public partial class Group
    {
        public int GroupId { get; set; }
        public string County { get; set; }
        public string GroupType { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
