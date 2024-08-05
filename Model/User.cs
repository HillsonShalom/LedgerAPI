namespace LedgerAPI.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties
        public ICollection<GroupMember> GroupMembers { get; set; } = new HashSet<GroupMember>();
        public ICollection<Expense> PaidExpenses { get; set; } = new HashSet<Expense>();
        public ICollection<ExpenseParticipant> ExpenseParticipants { get; set; } = new HashSet<ExpenseParticipant>();
    }

}
