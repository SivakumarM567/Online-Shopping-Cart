using EShoppingAPI.Data;
using EShoppingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.Controllers
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
        public async Task<IActionResult> GetOrderDetailsById(int id)
        {
            var orderDetails = await _context.Orders.FirstOrDefaultAsync(x => x.Orderid == id);

            if (orderDetails != null)
            {
                return Ok(orderDetails);
            }
            return NotFound("Order Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetails(Order order)
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
        public async Task<IActionResult> DeleteOrder(int id)
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
