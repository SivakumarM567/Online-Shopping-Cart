using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
    }
}
