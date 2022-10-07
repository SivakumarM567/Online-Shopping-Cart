using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public string CardholderName { get; set; }

        public string CardNumber { get; set; }

        public string Email { get; set; }
    }
}
