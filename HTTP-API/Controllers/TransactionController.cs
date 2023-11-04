using HTTP_API.Models;
using HTTP_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HTTP_API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ILogger<TransactionController> _logger;
    private readonly TransactionContext _dbContext;

    public TransactionController(
        ILogger<TransactionController> logger,
        TransactionContext dbContext
    )
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("api/CalculateClosingBalance")]
    public async Task<ActionResult> CalculateClosingBalance()
    {
        try
        {
            var rawBankTransactions = await _dbContext.RawBankTransactions.ToListAsync();
            var rawBankTransactionToCarryOver = new List<RawBankTransaction>();
            var rawBankTransactionAccountNumbers = await _dbContext.RawBankTransactions
                .Where(r => r.AccountNumber != null)
                .Select(r => r.AccountNumber)
                .Distinct()
                .ToListAsync();
            var rawBankBalancesClosed = new List<string>();

            foreach (int? accountNumber in rawBankTransactionAccountNumbers)
            {
                bool valid = true;
                int previousBalance = 0;
                var accountEntries = await _dbContext.RawBankTransactions
                    .Where(r => r.AccountNumber == accountNumber)
                    .Where(r => r.Narration != null)
                    .Where(r => r.Amount != null)
                    .Where(r => r.Balance != null)
                    .OrderBy(r => r.Date)
                    .ToListAsync();

                foreach (RawBankTransaction rawBankTransaction in accountEntries)
                {
                    if (rawBankTransaction.Balance == previousBalance + rawBankTransaction.Amount)
                    {
                        previousBalance = (int)rawBankTransaction.Balance;
                        continue;
                    }
                    else
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    rawBankBalancesClosed.Add(accountNumber.ToString());
                    List<BankTransaction> bankTransactionsToAdd = accountEntries
                        .Select(
                            r =>
                                new BankTransaction
                                {
                                    Id = r.Id,
                                    AccountNumber = r.AccountNumber,
                                    Date = r.Date,
                                    Narration = r.Narration,
                                    Amount = r.Amount,
                                    Balance = r.Balance
                                }
                        )
                        .ToList();
                    _dbContext.BankTransactions.AddRange(bankTransactionsToAdd);
                    _dbContext.SaveChanges();
                }
            }

            var message = "Closed the following bank balances: " + string.Format("{0}", string.Join(", ", rawBankBalancesClosed));
            _logger.LogInformation(message);
            return Ok(message);
        }
        catch (Exception ex)
        {
            var errorMessage = "Could not close accounts";

            _logger.LogError(errorMessage);
            _logger.LogError(ex.Message);
            return Conflict(errorMessage);
        }
    }

    [HttpGet("api/BankTransaction/all")]
    public async Task<ActionResult> GetBankTransactionAsync()
    {
        var bankTransactions = await _dbContext.BankTransactions.ToListAsync();

        _logger.LogInformation("Retrieved all of the bank transactions");
        return Ok(bankTransactions);
    }

    [HttpGet("api/BankTransaction")]
    public async Task<ActionResult> GetSingleBankTransactionAsync([FromQuery] Guid id)
    {
        var bankTransaction = await _dbContext.BankTransactions.FindAsync(id);
        if (bankTransaction == null)
        {
            _logger.LogInformation(
                "Could not retrieve the bank transaction: id = " + id.ToString()
            );
            return NotFound("Id: " + id + " does not exist");
        }

        _logger.LogInformation("Retrieved the bank transaction: id = " + id.ToString());
        return Ok(bankTransaction);
    }

    [HttpGet("api/RawBankTransaction/all")]
    public async Task<ActionResult> GetRawBankTransactionAsync()
    {
        var rawBankTransactions = await _dbContext.RawBankTransactions.ToListAsync();

        _logger.LogInformation("Retrieved all of the raw bank transactions");
        return Ok(rawBankTransactions);
    }

    [HttpGet("api/RawBankTransaction")]
    public async Task<ActionResult> GetSingleRawBankTransactionAsync([FromQuery] Guid id)
    {
        var rawBankTransaction = await _dbContext.RawBankTransactions.FindAsync(id);
        if (rawBankTransaction == null)
        {
            _logger.LogInformation(
                "Could not retrieve the raw bank transaction: id = " + id.ToString()
            );
            return NotFound("Id: " + id + " does not exist");
        }
        _logger.LogInformation("Retrieved raw bank transaction: id = " + id.ToString());
        return Ok(rawBankTransaction);
    }

    [HttpPost("api/RawBankTransaction")]
    public async Task<IActionResult> AddRawBankTransactionAsync(
        [FromBody] RawBankTransaction rawBankTransaction
    )
    {
        await _dbContext.RawBankTransactions.AddAsync(rawBankTransaction);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation(
            "Added the raw bank transaction: id = " + rawBankTransaction.Id.ToString()
        );

        return Ok(rawBankTransaction.AccountNumber);
    }

    [HttpPut("api/RawBankTransaction")]
    public async Task<IActionResult> UpdateRawBankTransactionAsync(
        [FromBody] RawBankTransaction rawBankTransaction
    )
    {
        try
        {
            _dbContext.RawBankTransactions.Any(r => r.Id == rawBankTransaction.Id);
            _dbContext.Entry(rawBankTransaction).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                "Updated the raw bank transaction: id = " + rawBankTransaction.Id.ToString()
            );
            return NoContent();
        }
        catch (Exception ex)
        {
            var errorMessage =
                "Could not update the raw bank transaction: id = "
                + rawBankTransaction.Id.ToString();
            _logger.LogError(errorMessage);

            _logger.LogError(ex.Message);
            return Conflict(errorMessage);
        }
    }

    [HttpDelete("api/RawBankTransaction")]
    public async Task<IActionResult> DeleteRawBankTransactionAsync([FromQuery] Guid id)
    {
        try
        {
            var rawBankTransaction = await _dbContext.RawBankTransactions.FindAsync(id);
            if (rawBankTransaction == null)
            {
                _logger.LogInformation("Could not find the raw bank transaction: id = " + id);
                return NotFound();
            }

            _dbContext.RawBankTransactions.Remove(rawBankTransaction);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Deleted the raw bank transaction: id = " + id);
            return NoContent();
        }
        catch (Exception ex)
        {
            var errorMessage = "Could not delete the raw bank transaction: id = " + id.ToString();
            _logger.LogError(errorMessage);

            _logger.LogError(ex.Message);
            return Conflict(errorMessage);
        }
    }
}
