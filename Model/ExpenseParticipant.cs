namespace LedgerAPI.Model
{
    public class ExpenseParticipant
    {
        public int ExpenseID { get; set; }
        public int ParticipantUserID { get; set; }
        public decimal Share { get; set; }

        // Navigation properties
        public Expense Expense { get; set; }
        public User ParticipantUser { get; set; }
    }
}
