namespace LedgerAPI.Model
{
    public class GroupMember
    {
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
