using System.ComponentModel.DataAnnotations;

namespace HTTP_API.Models
{
    public class BankTransaction
    {
        [Key]
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string? Narration { get; set; }
        public int balance { get; set; }
    }
}
