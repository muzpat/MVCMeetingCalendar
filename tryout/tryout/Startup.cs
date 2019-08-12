using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tryout.Startup))]
namespace tryout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
