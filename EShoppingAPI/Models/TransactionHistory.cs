using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingAPI.Models
{
    public class TransactionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionReportid { get; set; }
        public int? Orderid { get; set; }
        [ForeignKey("Orderid")]
        public Order? Order { get; set; }
        public int? Userid { get; set; }
        [ForeignKey("Userid")]
        public User? User { get; set; }
        public int? Paymentid { get; set; }
        [ForeignKey("Paymentid")]
        public Payment? Payment { get; set; }
    }
}
