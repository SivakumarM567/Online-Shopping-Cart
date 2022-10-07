using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public interface IUser
    {
        public string SaveUserDetails(UserDetails userDetails);
        public string UpdateUserDetails(UserDetails userDetails);
        public string DeleteUserDetails(int UserId);
        UserDetails GetUserDetails(int UserId);
        List<UserDetails> GetAllUserDetails();
        UserDetails GetUserbyEmail(string EmailId);
    }
}
