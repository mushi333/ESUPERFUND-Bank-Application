using System.ComponentModel.DataAnnotations;

namespace HTTP_API.Models
{
    public class RawBankTransaction
    {
        [Key]
        public int AccountNumber { get; set; }
        public DateTime Date { get; set; }
        public string? Narration { get; set; }
        public int balance { get; set; }
    }
}
