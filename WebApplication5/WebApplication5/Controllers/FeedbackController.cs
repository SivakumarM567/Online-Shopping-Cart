using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private FeedbackService _FeedDetailsServices;
        public FeedbackController(FeedbackService feedbackService)
        {
            _FeedDetailsServices = feedbackService;
        }
        [HttpPost("SaveFeedDetails")]
        public IActionResult SaveFeedDetails(Feedback feedback)
        {
            return Ok(_FeedDetailsServices.SaveFeedDetails(feedback));
        }
        [HttpGet("GetAllFeedDetails()")]
        public List<Feedback> GetAllFeedDetails()
        {
            return _FeedDetailsServices.GetAllFeedDetails();
        }
    }
}
