using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingZoneAPI.Models
{
    public class Order
    {
        [Key]
        public Guid Order_id { get; set; }
        public DateTime Order_date { get; set; }
        public int Order_quantity { get; set; }
        public float Order_totalAmount { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<TransactionHistory>? TransactionHistorys { get; set; }
    }
}
