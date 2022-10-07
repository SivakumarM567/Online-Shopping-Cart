using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
    private readonly EshoppingZone2Context _context;
    
    public ProductController(EshoppingZone2Context context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductDetails()
    {
        var product = await _context.ProductDetails.ToListAsync();
        return Ok(product);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetProductDetailsById([FromRoute] int id)
    {
        var productDetails = await _context.ProductDetails.FirstOrDefaultAsync(x => x.ProductId == id);

        if (productDetails != null)
        {
            return Ok(productDetails);
        }
        return NotFound("Product Not Found");
    }

    [HttpPost]
    [Route("addproduct")]
    public async Task<IActionResult> AddProductDetails([FromBody] Product product)
    {
        if (_context.ProductDetails == null)
        {
            return Problem("Product Entity is Empty.");
        }
        _context.ProductDetails.Add(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }
    
    [HttpDelete]
    [Route("deleteproduct/{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        if (id == null || _context.ProductDetails == null)
        {
            return NotFound();
        }

        var productDetails = await _context.ProductDetails
            .FirstOrDefaultAsync(m => m.ProductId == id);
        if (productDetails == null)
        {
            return NotFound();
        }
        _context.Remove(productDetails);
        await _context.SaveChangesAsync();
        return Ok(productDetails);
    }
    
    [HttpPut]
    [Route("updateproduct/{id:int}")]
    public async Task<IActionResult> UpdateProductDetails([FromRoute] int id, [FromBody] Product product)
    {
        var existingDetails = await _context.ProductDetails.FirstOrDefaultAsync(_ => _.ProductId == id);
        if (existingDetails != null)
        {
            existingDetails.ProductName = product.ProductName;
            existingDetails.Brand = product.Brand;
            existingDetails.Description = product.Description;
            existingDetails.Cost = product.Cost;

            await _context.SaveChangesAsync();
            return Ok("Updated Sucessfully");
        }
        return NotFound("Product Not Found");
    }

    [HttpGet]
    [Route("totalcost")]
    public async Task<IActionResult> GetProductTotalCost()
    {
        
        var productCost = (from product in _context.ProductDetails join booking in _context.BookingDetails on product.ProductName equals booking.ProductName
                           select new{ product = product, booking = booking})
                           .GroupBy(x => new { ProductName = x.product.ProductName })
                           .Select(x => new
                           {
                               productName = x.First().product.ProductName,
                               totalCost = x.Sum(y => y.booking.Cost)
                           });
        return Ok(productCost);
    }
}