using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRepairApp.Startup))]
namespace CarRepairApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
