using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectronicsShop.Startup))]
namespace ElectronicsShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
