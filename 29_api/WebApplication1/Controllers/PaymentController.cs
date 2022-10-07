using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly EshoppingZone2Context _context;

        public PaymentController(EshoppingZone2Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentDetails()
        {
            var payments = await _context.PaymentDetails.ToListAsync();
            return Ok(payments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPaymentDetailsById([FromRoute] int id)
        {
            var paymentDetails = await _context.PaymentDetails.FirstOrDefaultAsync(x => x.PaymentId == id);

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
            if (_context.PaymentDetails == null)
            {
                return Problem("Payment Entity is Empty.");
            }
            _context.PaymentDetails.Add(payment);
            await _context.SaveChangesAsync();

            return Ok(payment);
        }

        [HttpDelete]
        [Route("deletepayment/{id:int}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            if (id == null || _context.PaymentDetails == null)
            {
                return NotFound();
            }

            var paymentDetails = await _context.PaymentDetails
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentDetails == null)
            {
                return NotFound();
            }
            _context.Remove(paymentDetails);
            await _context.SaveChangesAsync();
            return Ok(paymentDetails);
        }
    }
}
