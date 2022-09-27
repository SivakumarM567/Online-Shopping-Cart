using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingAPI.Models
{
    public class Order
    {
        [Key]
        public int Orderid { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderQuantity { get; set; }
        public float OrderTotalAmount { get; set; }
        public int? Userid { get; set; }
        [ForeignKey("Userid")]
        public User? User { get; set; }
    }
}
