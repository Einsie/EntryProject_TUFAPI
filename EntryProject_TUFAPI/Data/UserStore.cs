/*
 * Title: Gambit's TUF-200M ultrasonic energy meter REST API Controller
 * Description: This API exists to provide users the ability to request data from
 * Gambit's TUF device to themselves through this API. Data will be converted
 * into human readable format by the API and sent to user in JSON format.
 * 
 * 
 * Class description: UserStore class acts as a intermediary class for hard coding
 * and storing the list of users and states the data for them. Normally these would
 * be in a database instead of inside the API code files. Only relevant data here
 * being used are the Username, Password and Role for authentication and authorization
 * of accessible methods.
 * Created: 18.03.2023
 * 
 * 
 * Developer: Albert Kristian Rantala
 * Last edit: 19.03.2023
 * Notes: 
 */


using EntryProject_TUFAPI.Models;

namespace EntryProject_TUFAPI.Data
{
    public class UserStore
    {
        public static List<User> Users = new()
        {
            new() { Username = "albert_admin", Email = "albert.madreth@gmail.com", Password = "MyTempPa55_W0rd", Givenname = "Albert", Surname = "Madreth", Role = "Administrator"},
            new() { Username = "JohnDoe_standard", Email = "john.doe@gmail.com", Password = "MyTempPa55_W0rd", Givenname = "John", Surname = "Doe", Role = "Standard" }
        };
    }
}
