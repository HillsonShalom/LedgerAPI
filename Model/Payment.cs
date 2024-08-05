namespace LedgerAPI.Model
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int PayerID { get; set; }
        public int PayeeID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public User Payer { get; set; }
        public User Payee { get; set; }
    }
}
