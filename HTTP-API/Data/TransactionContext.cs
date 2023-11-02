using Microsoft.EntityFrameworkCore;
using HTTP_API.Models;

namespace HTTP_API.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options) { }

        public DbSet<RawBankTransaction> RawBankTransactions { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}
