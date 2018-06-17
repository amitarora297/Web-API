using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API_Authentication.Provider;

namespace Web_API_Authentication
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions oAuthServerOptions { get; set; }
        static Startup()
        {
            oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new OAuthProvider(),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(oAuthServerOptions);
        }
    }
}