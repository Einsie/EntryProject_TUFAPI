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
