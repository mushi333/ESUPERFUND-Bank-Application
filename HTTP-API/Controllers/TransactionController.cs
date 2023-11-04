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

    // [HttpGet("api/CalculateClosingBalance")]
    // public async Task<ActionResult> CalculateClosingBalance()
    // {
    //     var rawBankTransactions = await _dbContext.BankTransactions.ToListAsync();

    //     var rawBankBalancesClosed = "";
    //     _logger.LogInformation("Closed the following bank balances: " + rawBankBalancesClosed);
    //     return Ok();
    // }

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
            _logger.LogInformation(errorMessage);
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
            var errorMessage =
                "Could not delete the raw bank transaction: id = "
                + id.ToString();
            _logger.LogInformation(errorMessage);
            _logger.LogError(ex.Message);
            return Conflict(errorMessage);
        }
    }
}
