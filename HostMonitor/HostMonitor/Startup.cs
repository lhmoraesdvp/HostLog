using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HostMonitor.Startup))]
namespace HostMonitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
