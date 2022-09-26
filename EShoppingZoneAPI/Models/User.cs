using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingZoneAPI.Models
{
    public class User
    {
        [Key]
        public Guid User_id { get; set; }
        public string User_firstname { get; set; }
        public string User_lastname { get; set; }
        public string User_email { get; set; }
        public string User_password { get; set; }
        public int User_contact { get; set; }
        public string User_address { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<TransactionHistory>? TransactionHistorys { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
