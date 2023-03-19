/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: The class to be received in login request and hold the string
 * values for UserName and Password
 * Created: 18.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: 
 */


namespace EntryProject_TUFAPI.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
