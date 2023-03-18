using EntryProject_TUFAPI.Data;
using EntryProject_TUFAPI.Models;

namespace EntryProject_TUFAPI.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserStore.Users.FirstOrDefault(o => o.Username.Equals
            (userLogin.UserName, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.Password));

            return user;
        }
    }
}
