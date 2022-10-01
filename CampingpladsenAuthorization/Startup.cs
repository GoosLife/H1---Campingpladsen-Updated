using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampingpladsenAuthorization.Startup))]
namespace CampingpladsenAuthorization
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
