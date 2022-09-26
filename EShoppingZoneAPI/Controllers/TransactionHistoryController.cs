using EShoppingZoneAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingZoneAPI.Controllers
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
        public async Task<IActionResult> GetTransactionHistory()
        {
            var TransactionHistory = await _context.TransactionHistorys.ToListAsync();
            return Ok(TransactionHistory);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTransactionHistoryById([FromRoute] Guid id)
        {
            var TransactionHistory = await _context.TransactionHistorys.FirstOrDefaultAsync(x => x.Transaction_reportid == id);

            if (TransactionHistory != null)
            {
                return Ok(TransactionHistory);
            }
            return NotFound("TransactionHistory Not Found");
        }
    }
}
