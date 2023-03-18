using EntryProject_TUFAPI.Models;

namespace EntryProject_TUFAPI.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
