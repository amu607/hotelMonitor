using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hotelMonitor.Startup))]
namespace hotelMonitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
