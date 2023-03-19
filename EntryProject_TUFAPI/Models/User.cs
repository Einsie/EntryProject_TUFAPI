/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: User class determines which holds the potentially relevant
 * user information of potential accounts that can login. Only Username, Password
 * and Role are being used in this case, the rest act as examples of potentially relevant values.
 * Created: 18.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: 
 */


namespace EntryProject_TUFAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Givenname { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
