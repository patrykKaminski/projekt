using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autentykacja.Startup))]
namespace Autentykacja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
