using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lands_V9.Backend.Startup))]
namespace Lands_V9.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
