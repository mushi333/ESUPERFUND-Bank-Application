namespace HTTP_API.Models
{
    public class BankTransaction
    {
        public Guid Id { get; set; }
        public int? AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string? Narration { get; set; }
        public int? Amount { get; set; }
        public int? Balance { get; set; }
    }
}
