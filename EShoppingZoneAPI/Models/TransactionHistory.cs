using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingZoneAPI.Models
{
    public class TransactionHistory
    {
        [Key]
        public Guid Transaction_reportid { get; set; }
        
    }
}
