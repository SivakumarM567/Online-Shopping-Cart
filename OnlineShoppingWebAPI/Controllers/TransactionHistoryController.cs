using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingWebAPI.Data;

namespace OnlineShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public TransactionHistoryController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionHistoryDetails()
        {
            var transactionHistory = await _context.TransactionHistorys.ToListAsync();
            return Ok(transactionHistory);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTransactionHistoryById([FromRoute] int id)
        {
            var transactionHistory = await _context.TransactionHistorys.FirstOrDefaultAsync(x => x.TransactionReportid == id);

            if (transactionHistory != null)
            {
                return Ok(transactionHistory);
            }
            return NotFound("TransactionHistory Not Found");
        }
    }
}
