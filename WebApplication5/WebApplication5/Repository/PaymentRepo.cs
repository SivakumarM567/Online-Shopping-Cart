using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using WebApplication5.Data;
using WebApplication5.Models;
using MimeKit.Text;

namespace WebApplication5.Repository
{
    public class PaymentRepo : IPayment
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        public PaymentRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteTransaction(int TransactionId)
        {
            string msg = "";
            Payment deleteTransaction = _ShoppingCartDb.Payment.Find(TransactionId);
            if (deleteTransaction != null)
            {
                _ShoppingCartDb.Payment.Remove(deleteTransaction);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<Payment> GetAllTransaction()
        {
            List<Payment> transactions = _ShoppingCartDb.Payment.ToList();
            return transactions;
        }

        public Payment GetTransaction(int TransactionId)
        {
            Payment transaction = _ShoppingCartDb.Payment.Find(TransactionId);
            return transaction;
        }

        public string SaveTransaction(Payment payment)
        {
            _ShoppingCartDb.Payment.Add(payment);
            _ShoppingCartDb.SaveChanges();
            SendEmail(payment);
            return "Saved";
        }

        public string UpdateTransaction(Payment Payment)
        {
            _ShoppingCartDb.Entry(Payment).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }

        #region SendEmail
        public async Task<Payment> SendEmail(Payment payment)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("eshoppingzone123@gmail.com"));
                email.To.Add(MailboxAddress.Parse(payment.Email));
                email.Subject = "Payment Done";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Welcome to our EShoppingZone. Your payment was done successful. Visit us again."
                };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("eshoppingzone123@gmail.com", "udhsvultituhthsb");
                smtp.Send(email);
                smtp.Disconnect(true);
                return payment;

            }
            catch (Exception ex)
            {
                string msg = "Error";
            }
            return payment;
        }
        #endregion

    }
}
