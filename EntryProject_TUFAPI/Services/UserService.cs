/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: UserService class identifies that the user login information sent, username and password 
 * is found in a user in the UserStore list and returns the first user that matched the login data, otherwise
 * it returns a default value of null.
 * Created: 18.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: 
 */



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
