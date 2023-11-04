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
        _logger.LogInformation("Retrieved all of the bank transactions");
        return Ok(bankTransactions);
    }

    [HttpGet("api/BankTransaction")]
    public async Task<ActionResult> GetSingleBankTransactionAsync([FromQuery] Guid id)
    {
        var bankTransaction = await _dbContext.BankTransactions.FindAsync(id);
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
        _dbContext.RawBankTransactions.Any(r => r.Id == rawBankTransaction.Id);
        _dbContext.Entry(rawBankTransaction).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        _logger.LogInformation(
            "Updated the raw bank transaction: id = " + rawBankTransaction.Id.ToString()
        );
        return NoContent();
    }

    [HttpDelete("api/RawBankTransaction")]
    public async Task<IActionResult> DeleteRawBankTransactionAsync([FromQuery] Guid id)
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
}
