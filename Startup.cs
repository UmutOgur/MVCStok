using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcStok.Startup))]
namespace MvcStok
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
