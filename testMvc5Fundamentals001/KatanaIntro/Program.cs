
namespace KatanaIntro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Owin.Hosting;
    using Owin;

    class Program
    {
        static void Main(string[] args)
        {
            // var uri = "http://localhost:8080";
            // var uri = "http://localhost:12340";
            var uri = "http://localhost:9999";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWelcomePage();

            // app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }
}
