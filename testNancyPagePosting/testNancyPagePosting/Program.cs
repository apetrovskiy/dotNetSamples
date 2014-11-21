
namespace testNancyPagePosting
{
    using System;
    using Nancy;
    using Nancy.Hosting;
    using Nancy.Bootstrapper;
    using Nancy.Hosting.Self;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");

            var host = new NancyHost(new Uri("http://127.0.0.1:8888"));
            host.Start();  // start hosting

            Console.ReadKey ();
            host.Stop ();
        }
    }
}
