using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cyclops.Web.Startup))]
namespace Cyclops.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
