using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CFI_App.Startup))]
namespace CFI_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
