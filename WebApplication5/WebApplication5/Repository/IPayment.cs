using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IPayment
    {
        public string SaveTransaction(Payment Payment);

        public string UpdateTransaction(Payment Payment);
        public string DeleteTransaction(int TransactionId);
        Payment GetTransaction(int TransactionId);
        List<Payment> GetAllTransaction();
    }
}
