using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dziennik.Startup))]
namespace Dziennik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
