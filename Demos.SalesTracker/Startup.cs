using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demos.SalesTracker.Startup))]
namespace Demos.SalesTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
