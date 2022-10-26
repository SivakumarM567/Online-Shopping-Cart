using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Services
{
    public class FeedbackService
    {
        public IFeedback _feedbackRepository;
        public FeedbackService(IFeedback FeedDetailsRepository)
        {
            _feedbackRepository = FeedDetailsRepository;
        }
        public string SaveFeedDetails(Feedback feedback)
        {
            return _feedbackRepository.SaveFeedDetails(feedback);
        }

        public List<Feedback> GetAllFeedDetails()
        {
            return _feedbackRepository.GetAllFeedDetails();
        }
    }
}
