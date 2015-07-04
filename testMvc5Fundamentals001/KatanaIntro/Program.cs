
namespace KatanaIntro
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Owin.Hosting;
    using Owin;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
    
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
            app.UseHelloWorld();

            // app.Use<HelloWorldComponent>();

            // app.UseWelcomePage();

            // app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        //public async Task Invoke(IDictionary<string, object> environment)
        //{
        //    await _next(environment);
        //}

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!");
            }
        }
    }
}
