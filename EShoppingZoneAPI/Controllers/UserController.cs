using EShoppingZoneAPI.Data;
using EShoppingZoneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShoppingZoneAPI.Controllers
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
        [HttpPost]
        [Route("adduser")]
        public async Task<IActionResult> AddUserDetails([FromBody] User user)
        {
            if (_context.Users == null)
            {
                return Problem("User Entity is Empty.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("updateuser/{id:guid}")]
        public async Task<IActionResult> UpdateUserDetails([FromRoute] Guid id, [FromBody] User user)
        {
            var existingDetails = await _context.Users.FirstOrDefaultAsync(_ => _.User_id == id);
            if (existingDetails != null)
            {
                existingDetails.User_firstname = user.User_firstname;
                existingDetails.User_lastname = user.User_lastname;
                existingDetails.User_email = user.User_email;
                existingDetails.User_password = user.User_password;
                existingDetails.User_contact = user.User_contact;
                existingDetails.User_address = user.User_address;

                await _context.SaveChangesAsync();
                return Ok("Updated Sucessfully");
            }
            return NotFound("User Not Found");
        }
    }
}
