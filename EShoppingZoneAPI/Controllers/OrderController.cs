using EShoppingZoneAPI.Data;
using EShoppingZoneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingZoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public OrderController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOrderDetailsById([FromRoute] Guid id)
        {
            var orderDetails = await _context.Orders.FirstOrDefaultAsync(x => x.Order_id == id);

            if (orderDetails != null)
            {
                return Ok(orderDetails);
            }
            return NotFound("Order Not Found");
        }

        [HttpPost]
        [Route("addorder")]
        public async Task<IActionResult> AddOrderDetails([FromBody] Order order)
        {
            if (_context.Orders == null)
            {
                return Problem("Order Entity is Empty.");
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpDelete]
        [Route("deleteorder/{id:guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.Orders
                .FirstOrDefaultAsync(m => m.Order_id == id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            _context.Remove(orderDetails);
            await _context.SaveChangesAsync();
            return Ok(orderDetails);
        }
    }
}
