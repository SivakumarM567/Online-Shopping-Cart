using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentService _transactionServices;
        public PaymentController(PaymentService PaymentService)
        {
            _transactionServices = PaymentService;
        }
        [HttpPost("SaveTransaction")]
        public IActionResult SaveTransaction(Payment Payment)
        {
            return Ok(_transactionServices.SaveTransaction(Payment));
        }

        [HttpDelete("DeleteTransaction")]
        public IActionResult DeleteTransaction(int CartId)
        {
            return Ok(_transactionServices.DeleteTransaction(CartId));
        }

        [HttpPut("UpdateTransaction")]
        public IActionResult UpdateTransaction(Payment transaction)
        {
            return Ok(_transactionServices.UpdateTransaction(transaction));
        }

        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction(int TransactionId)
        {
            return Ok(_transactionServices.GetTransaction(TransactionId));
        }

        [HttpGet("GetAllTransaction")]
        public List<Payment> GetAllTransaction()
        {
            return _transactionServices.GetAllTransaction();
        }
    }
}
