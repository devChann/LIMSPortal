namespace LIMSCore.Entities
{
	public partial class GroupOw
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string GroupType { get; set; }
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
