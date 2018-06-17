using Web_API_Authentication.Models;

namespace Web_API_Authentication.Service
{
    public class UserService
    {

        public User getUser (string username, string password )
        {
            if (username != "amit" || password != "@mit@rora297")
            {
                return null;
            }
            else
            {
                return new User() { UserID = 1, UserName = "amit" };
            }
        }
    }
}