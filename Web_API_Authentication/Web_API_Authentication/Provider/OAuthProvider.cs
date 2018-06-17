using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Web_API_Authentication.Models;
using Web_API_Authentication.Service;
using Microsoft.Owin.Security;

namespace Web_API_Authentication.Provider
{
    public class OAuthProvider : OAuthAuthorizationServerProvider 
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew (()=>
            {
                var username = context.UserName;
                var password = context.Password;

                UserService userSvc = new UserService();
                User user = userSvc.getUser(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                {
                    new Claim ( ClaimTypes.Name , user.UserName),
                    new Claim ("UserID", user.UserID.ToString())
                };

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.oAuthServerOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAuthIdentity, null));
                }
                else
                {
                    context.SetError("Invalid User");

                }
            });
            //return base.GrantResourceOwnerCredentials(context);
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}