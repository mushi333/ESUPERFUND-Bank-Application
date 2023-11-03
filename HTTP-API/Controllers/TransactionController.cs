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

    [HttpGet(Name = "BankTransaction")]
    public async Task<ActionResult> GetBankTransactionAsync()
    {
        var bankTransactions = await _dbContext.BankTransactions.ToListAsync();
        return Ok(bankTransactions);
    }

    [HttpGet(Name = "RawBankTransaction")]
    public async Task<ActionResult> GetRawBankTransactionAsync()
    {
        var rawBankTransactions = await _dbContext.RawBankTransactions.ToListAsync();
        return Ok(rawBankTransactions);
    }

    [HttpPost(Name = "RawBankTransaction")]
    public async Task<IActionResult> AddContact([FromBody] RawBankTransaction rawBankTransaction)
    {
        await _dbContext.RawBankTransactions.AddAsync(rawBankTransaction);
        await _dbContext.SaveChangesAsync();
        return Ok(rawBankTransaction.AccountNumber);
    }
}
