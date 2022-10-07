using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService _orderDetailsServices;
        public OrderController(OrderService userDetailsServices)
        {
            _orderDetailsServices = userDetailsServices;
        }
        [HttpPost("SaveOrderDetails")]
        public IActionResult SaveOrderDetails(Order orderDetails)
        {
            return Ok(_orderDetailsServices.SaveOrderDetails(orderDetails));
        }

        [HttpDelete("DeleteOrderDetails")]
        public IActionResult DeleteOrderDetails(int OrderId)
        {
            return Ok(_orderDetailsServices.DeleteOrderDetails(OrderId));
        }

        [HttpPut("UpdateOrderDetails")]
        public IActionResult UpdateOrderDetails(Order orderDetails)
        {
            return Ok(_orderDetailsServices.UpdateOrderDetails(orderDetails));
        }

        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails(int OrderId)
        {
            return Ok(_orderDetailsServices.GetOrderDetails(OrderId));
        }

        [HttpGet("GetAllOrderDetails()")]
        public List<Order> GetAllOrderDetails()
        {
            return _orderDetailsServices.GetAllOrderDetails();
        }
    }
}
