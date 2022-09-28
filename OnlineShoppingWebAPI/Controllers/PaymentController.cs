using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingWebAPI.Data;
using OnlineShoppingWebAPI.Models;

namespace OnlineShoppingWebAPI.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var payments = await _context.Payments.ToListAsync();
            return Ok(payments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPaymentDetailsById([FromRoute] int id)
        {
            var paymentDetails = await _context.Payments.FirstOrDefaultAsync(x => x.Paymentid == id);

            if (paymentDetails != null)
            {
                return Ok(paymentDetails);
            }
            return NotFound("Payment Not Found");
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
