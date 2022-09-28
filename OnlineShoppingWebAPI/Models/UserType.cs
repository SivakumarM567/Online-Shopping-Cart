using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWebAPI.Models
{
    public class UserType
    {
        [Key]
        public int Usertypeid { get; set; }
        public string Usertype { get; set; }
    }
}
