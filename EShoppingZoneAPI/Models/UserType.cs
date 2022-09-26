using System.ComponentModel.DataAnnotations;

namespace EShoppingZoneAPI.Models
{
    public class UserType
    {
        [Key]
        public Guid User_type_id { get; set; }
        public string User_type { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
