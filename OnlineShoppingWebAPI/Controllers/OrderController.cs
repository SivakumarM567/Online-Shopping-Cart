using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingWebAPI.Data;
using OnlineShoppingWebAPI.Models;

namespace OnlineShoppingWebAPI.Controllers
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
        [Route("{id:int}")]
        public async Task<IActionResult> GetOrderDetailsById([FromRoute] int id)
        {
            var orderDetails = await _context.Orders.FirstOrDefaultAsync(x => x.Orderid == id);

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
        [Route("deleteorder/{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var oredrDetails = await _context.Orders
                .FirstOrDefaultAsync(m => m.Orderid == id);
            if (oredrDetails == null)
            {
                return NotFound();
            }
            _context.Remove(oredrDetails);
            await _context.SaveChangesAsync();
            return Ok(oredrDetails);
        }
    }
}
