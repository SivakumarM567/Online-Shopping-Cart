using EShoppingZoneAPI.Data;
using EShoppingZoneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingZoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public PaymentController(ShoppingDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("addpayment")]
        public async Task<IActionResult> AddPaymentDetails([FromBody] Payment payment)
        {
            if (_context.Payments == null)
            {
                return Problem("Payment Entity is Empty.");
            }
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(payment);
        }
    }
}
