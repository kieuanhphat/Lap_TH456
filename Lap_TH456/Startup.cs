using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lap_TH456.Startup))]
namespace Lap_TH456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
