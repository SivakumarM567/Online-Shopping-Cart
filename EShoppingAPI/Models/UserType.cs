using System.ComponentModel.DataAnnotations;

namespace EShoppingAPI.Models
{
    public class UserType
    {
        [Key]
        public int Usertypeid { get; set; }
        public string Usertype { get; set; }
    }
}
