using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public string CardHolderName { get; set; }
        public decimal TransactionAmount { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string Mode { get; set; }

        [MinLength(16, ErrorMessage = "Please enter the card number")]
        [Required(ErrorMessage = "Please enter a valid Card Number")]
        [Display(Name = "Card Number")]
        public string Cardnumber { get; set; }
        public int Cardcvv { get; set; }
    }
}
