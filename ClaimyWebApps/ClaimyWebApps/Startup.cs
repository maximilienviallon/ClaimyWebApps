using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClaimyWebApps.Startup))]
namespace ClaimyWebApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
