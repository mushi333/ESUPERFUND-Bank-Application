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

    [HttpGet("api/BankTransaction/all")]
    public async Task<ActionResult> GetBankTransactionAsync()
    {
        var bankTransactions = await _dbContext.BankTransactions.ToListAsync();
        _logger.LogInformation("Retrieved all bank transactions");
        return Ok(bankTransactions);
    }

    [HttpGet("api/RawBankTransaction/all")]
    public async Task<ActionResult> GetRawBankTransactionAsync()
    {
        var rawBankTransactions = await _dbContext.RawBankTransactions.ToListAsync();
        _logger.LogInformation("Retrieved all raw bank transactions");
        return Ok(rawBankTransactions);
    }

    [HttpPost("api/RawBankTransaction")]
    public async Task<IActionResult> AddRawBankTransaction(
        [FromBody] RawBankTransaction rawBankTransaction
    )
    {
        await _dbContext.RawBankTransactions.AddAsync(rawBankTransaction);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation(
            "Added raw bank transaction: id = " + rawBankTransaction.Id.ToString()
        );
        return Ok(rawBankTransaction.AccountNumber);
    }

    [HttpPut("api/RawBankTransaction")]
    public async Task<IActionResult> UpdateRawBankTransaction(
        [FromBody] RawBankTransaction rawBankTransaction
    )
    {
        _dbContext.RawBankTransactions.Any(r => r.Id == rawBankTransaction.Id);
        _dbContext.Entry(rawBankTransaction).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation(
            "Updated raw bank transaction: id = " + rawBankTransaction.Id.ToString()
        );
        return NoContent();
    }

    [HttpDelete("api/RawBankTransaction")]
    public async Task<IActionResult> DeleteRawBankTransaction([FromQuery] Guid id)
    {
        var rawBankTransaction = await _dbContext.RawBankTransactions.FindAsync(id);

        if (rawBankTransaction == null)
        {
            _logger.LogInformation(
                "Could not find the raw bank transaction: id = " + id
            );
            return NotFound();
        }

        _dbContext.RawBankTransactions.Remove(rawBankTransaction);
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation(
            "Deleted the raw bank transaction: id = " + id
        );
        return NoContent();
    }
}
