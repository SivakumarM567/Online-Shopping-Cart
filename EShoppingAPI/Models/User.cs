using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShoppingAPI.Models
{
    public class User
    {
        [Key]
        public int Userid { get; set; }
        public string UserFirstname { get; set; }
        public string UserLastname { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserContact { get; set; }
        public string UserAddress { get; set; }
        public int? Usertypeid { get; set; }
        [ForeignKey("Usertypeid")]
        public UserType? UserType { get; set; }
    }
}
