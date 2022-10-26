using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class FeedbackRepo : IFeedback
    {
        private ShoppingCartDbContext shoppingCartDb;

        public FeedbackRepo(ShoppingCartDbContext ShoppingDbContext)
        {
            shoppingCartDb = ShoppingDbContext;

        }
        public List<Feedback> GetAllFeedDetails()
        {
            List<Feedback> feed = shoppingCartDb.feedback.ToList();
            return feed;
        }

        public Feedback GetFeedDetails(int UserId)
        {
            Feedback feed = shoppingCartDb.feedback.Find(UserId);
            return feed;
        }

        public string SaveFeedDetails(Feedback feedback)
        {
            shoppingCartDb.feedback.Add(feedback);
            shoppingCartDb.SaveChanges();
            return "Saved";
        }
    }
}
