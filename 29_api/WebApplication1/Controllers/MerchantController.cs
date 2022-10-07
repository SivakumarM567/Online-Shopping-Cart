using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class MerchantController : ControllerBase
{
    
    private readonly EshoppingZone2Context _context;
    
    public MerchantController(EshoppingZone2Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMerchantDetails()
    {
        var merchants = await _context.MerchantDetails.ToListAsync();
        return Ok(merchants);

    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterMerchant([FromBody] Merchant merchant)
    {
        if (_context.MerchantDetails == null)
        {
            return Problem("Merchant Entity is Empty.");
        }
        _context.MerchantDetails.Add(merchant);
        await _context.SaveChangesAsync();

        return Ok(merchant);
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<Merchant>> Login([FromBody] Merchant merchant)
    {
        if (_context.MerchantDetails == null)
        {
            return NotFound("Invalid credentials not found");
        }
        var regMerchant = await _context.MerchantDetails
            .Where(x => x.Email == merchant.Email && x.Pass == merchant.Pass)
            .Select(x => new Merchant()
            {
                Id = x.Id,
                Email = x.Email,
                Pass = x.Pass,

            })
            .FirstOrDefaultAsync();

        if (regMerchant == null)
        {
            return NotFound("Invalid credentials not found");
        }
        return Ok(regMerchant);
    }
}