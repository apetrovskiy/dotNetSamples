using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testMvc5Fundamentals001.Startup))]
namespace testMvc5Fundamentals001
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
