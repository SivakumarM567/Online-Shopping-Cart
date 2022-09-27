using EShoppingAPI.Data;
using EShoppingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public UserController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetailsById(int id)
        {
            var userDetails = await _context.Users.FirstOrDefaultAsync(x => x.Userid == id);

            if (userDetails != null)
            {
                return Ok(userDetails);
            }
            return NotFound("User Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> AddUserDetails(User user)
        {
            if (_context.Users == null)
            {
                return Problem("User Entity is Empty.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var userDetails = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userDetails == null)
            {
                return NotFound();
            }
            _context.Remove(userDetails);
            await _context.SaveChangesAsync();
            return Ok(userDetails);
        }
    }
}
