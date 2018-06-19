using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Web_API_Authentication.Startup))]
namespace Web_API_Authentication
{
    public  partial class Startup
    {
        /// <summary>
        /// Owin Startup Class
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}