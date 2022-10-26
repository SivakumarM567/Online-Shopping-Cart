using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IFeedback
    {
        public string SaveFeedDetails(Feedback feedback);
        Feedback GetFeedDetails(int UserId);
        List<Feedback> GetAllFeedDetails();
    }
}
