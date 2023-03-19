/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: The interface class for UserService to hold the UserService
 * class, provides the method available to be interfaced with for any UserService
 * class stored in IUserService
 * Created: 18.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: 
 */


using EntryProject_TUFAPI.Models;

namespace EntryProject_TUFAPI.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
