using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productServices;
        public ProductController(ProductService Product)
        {
            _productServices = Product;
        }
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Product Product)
        {
            return Ok(_productServices.SaveProduct(Product));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            return Ok(_productServices.DeleteProduct(ProductId));
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProducte(Product Product)
        {
            return Ok(_productServices.UpdateProduct(Product));
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ProductId)
        {
            return Ok(_productServices.GetProduct(ProductId));
        }

        [HttpGet("GetProductByName")]
        public IActionResult GetProductByName(string ProductName)
        {
            return Ok(_productServices.GetProductByName(ProductName));
        }

        [HttpGet("GetAllProduct()")]
        public List<Product> GetAllProduct()
        {
            return _productServices.GetAllProduct();
        }
    }
}
