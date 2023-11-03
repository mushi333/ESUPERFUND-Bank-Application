using Microsoft.EntityFrameworkCore;
using HTTP_API.Models;

namespace HTTP_API.Data
{
    public class TransactionContext : DbContext
    {
        public DbSet<RawBankTransaction> RawBankTransactions { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }

        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<RawBankTransaction>()
                .HasData(
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10001,
                        Date = DateTime.Parse("1/07/2022"),
                        Narration = "Credit 1",
                        Amount = 100,
                        Balance = 100,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10002,
                        Date = DateTime.Parse("2/07/2022"),
                        Narration = null,
                        Amount = 200,
                        Balance = 200,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10003,
                        Date = DateTime.Parse("3/07/2022"),
                        Narration = "Credit 3",
                        Amount = 300,
                        Balance = 300,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10001,
                        Date = DateTime.Parse("4/07/2022"),
                        Narration = "Credit 4",
                        Amount = 200,
                        Balance = 300,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10002,
                        Date = DateTime.Parse("5/07/2022"),
                        Narration = "Credit 5",
                        Amount = 100,
                        Balance = 200,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10003,
                        Date = DateTime.Parse("6/07/2022"),
                        Narration = "Credit 6",
                        Amount = 100,
                        Balance = 400,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10001,
                        Date = DateTime.Parse("7/07/2022"),
                        Narration = "Debit 1",
                        Amount = -50,
                        Balance = 250,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10002,
                        Date = DateTime.Parse("8/07/2022"),
                        Narration = "Debit 2",
                        Amount = -20,
                        Balance = 200,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10003,
                        Date = DateTime.Parse("9/07/2022"),
                        Narration = "Debit 3",
                        Amount = null,
                        Balance = null,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10001,
                        Date = DateTime.Parse("10/07/2022"),
                        Narration = "Debit 4",
                        Amount = -100,
                        Balance = 150,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10002,
                        Date = DateTime.Parse("11/07/2022"),
                        Narration = "Debit 5",
                        Amount = -100,
                        Balance = 200,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = 10003,
                        Date = DateTime.Parse("12/07/2022"),
                        Narration = "Debit 6",
                        Amount = null,
                        Balance = null,
                    },
                    new RawBankTransaction
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = null,
                        Date = DateTime.Parse("13/07/2022"),
                        Narration = "Debit 7",
                        Amount = -50,
                        Balance = 200,
                    }
                );
        }
    }
}
