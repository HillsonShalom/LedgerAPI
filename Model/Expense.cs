namespace LedgerAPI.Model
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int GroupID { get; set; }
        public int PaidByUserID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public Group Group { get; set; }
        public User PaidByUser { get; set; }
        public ICollection<ExpenseParticipant> ExpenseParticipants { get; set; }
    }
}
