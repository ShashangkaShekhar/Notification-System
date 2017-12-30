using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotifSystem.Web.Startup))]
namespace NotifSystem.Web
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
