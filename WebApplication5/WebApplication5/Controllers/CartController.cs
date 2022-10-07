using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartService _cartServices;
        public CartController(CartService cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpPost("SaveCart")]
        public IActionResult SaveCart(Cart cart)
        {
            return Ok(_cartServices.SaveCart(cart));
        }

        [HttpDelete("DeleteCart")]
        public IActionResult DeleteCart(int CartId)
        {
            return Ok(_cartServices.DeleteCart(CartId));
        }

        [HttpPut("UpdateCart")]
        public IActionResult UpdateCart(Cart cart)
        {
            return Ok(_cartServices.UpdateCart(cart));
        }

        [HttpGet("GetCart")]
        public IActionResult GetCart(int CartId)
        {
            return Ok(_cartServices.GetCart(CartId));
        }

        [HttpGet("GetAllCart")]
        public List<Cart> GetAllCart()
        {
            return _cartServices.GetAllCart();
        }

        [HttpGet("GetCartHistory")]
        public IActionResult GetCartByUserID(int UserId)
        {
            return Ok(_cartServices.GetCartByUserID(UserId));
        }
        [HttpGet("GetCartId")]
        public IActionResult GetCartId(int UserId)
        {
            return Ok(_cartServices.GetCartId(UserId));
        }
    }
}
