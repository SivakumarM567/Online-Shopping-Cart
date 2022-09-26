using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingZoneAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid Payment_id { get; set; }
        public string Payment_type { get; set; }

        public virtual ICollection<TransactionHistory>? TransactionHistorys { get; set; }
    }
}
