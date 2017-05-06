using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmersWareHouse.Startup))]
namespace FarmersWareHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
