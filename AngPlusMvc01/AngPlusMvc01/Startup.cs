using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngPlusMvc01.Startup))]
namespace AngPlusMvc01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
