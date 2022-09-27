using EShoppingAPI.Data;
using EShoppingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.Controllers
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
        [Route("addUserType")]
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
