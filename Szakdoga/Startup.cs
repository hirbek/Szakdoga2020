using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Szakdoga.Startup))]
namespace Szakdoga
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
