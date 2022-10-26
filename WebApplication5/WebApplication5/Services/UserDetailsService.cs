using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Services
{
    public class UserDetailsService
    {
        private IUser _userDetailsRepository;


        public UserDetailsService(IUser userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public string DeleteUserDetails(int UserId)
        {
            return _userDetailsRepository.DeleteUserDetails(UserId);
        }

        public string UpdateUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.UpdateUserDetails(userDetails);
        }


        public UserDetails GetUserDetails(int UserId)
        {
            return _userDetailsRepository.GetUserDetails(UserId);
        }


        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsRepository.GetAllUserDetails();
        }

        public string SaveUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.SaveUserDetails(userDetails);
        }

        public UserDetails GetUserbyEmail(string EmailId,string Password, string Role)
        {
            return _userDetailsRepository.GetUserbyEmail(EmailId,Password,Role);
        }
    }
}
