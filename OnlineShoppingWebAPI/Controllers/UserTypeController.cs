using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingWebAPI.Data;
using OnlineShoppingWebAPI.Models;

namespace OnlineShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public UserTypeController(ShoppingDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("addusertype")]
        public async Task<IActionResult> AddUserType([FromBody] UserType userType)
        {
            if (_context.UserTypes == null)
            {
                return Problem("UserType Entity is Empty.");
            }
            _context.UserTypes.Add(userType);
            await _context.SaveChangesAsync();

            return Ok(userType);
        }
    }
}
