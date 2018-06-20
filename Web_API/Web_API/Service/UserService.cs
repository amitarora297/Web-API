using API_Data_Layer;
using API_Data_Layer.Model;

namespace Web_API_Authentication.Service
{
    public class UserService
    {

        public User getUser (string username, string password )
        {
            if ((username != "amit" && password != "@mit@rora297") || (username != "amit1" && password != "@mit@rora297"))
            {
                return null;
            }
            else
            {
                if (username == "amit")
                    return new User() { UserID = 1, UserName = "amit" };
                else
                    return new User() { UserID = 1, UserName = "amit1" };
            }
        }
    }
}