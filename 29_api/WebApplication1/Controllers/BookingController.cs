using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class BookingController : ControllerBase
{
    private readonly EshoppingZone2Context _context;

    public BookingController(EshoppingZone2Context context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetBookingProduct([FromRoute] int id)
    {
        var bookedproducts = await _context.BookingDetails.Where(m => m.UserId == id).ToListAsync();
        if (bookedproducts == null)
        {
            return NotFound();
        }
        return Ok(bookedproducts);
    }

    [HttpPost]
    [Route("bookproduct")]
    public async Task<IActionResult> BookProduct([FromBody] Booking booked)
    {
        if (_context.BookingDetails == null)
        {
            return Problem("BookedProduct Entity is Empty.");
        }
        _context.BookingDetails.Add(booked);
        await _context.SaveChangesAsync();

        return Ok(booked);
    }

    [HttpDelete]
    [Route("deleteBookedProduct/{id:int}")]
    public async Task<IActionResult> DeleteBookedProduct([FromRoute] int id)
    {
        if (id == null || _context.BookingDetails == null)
        {
            return NotFound();
        }

        var bookedProductDetails = await _context.BookingDetails
            .FirstOrDefaultAsync(m => m.BookedId == id);
        if (bookedProductDetails == null)
        {
            return NotFound();
        }
        _context.Remove(bookedProductDetails);
        await _context.SaveChangesAsync();
        return Ok(bookedProductDetails);
    }
}
