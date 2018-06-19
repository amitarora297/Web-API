using API_Data_Layer;
using API_Data_Layer.Model;

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