using EShoppingAPI.Data;
using EShoppingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.Controllers
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
        public async Task<IActionResult> GetPaymentDetailsById(int id)
        {
            var paymentDetails = await _context.Payments.FirstOrDefaultAsync(x => x.Paymentid == id);

            if (paymentDetails != null)
            {
                return Ok(paymentDetails);
            }
            return NotFound("Payment Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentDetails(Payment payment)
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
