namespace JdiSampleSite.Runner
{
    using System;
    using System.Linq;
    using Common.Library.Abstract;
    using Nancy.Hosting.Self;

    class Program
    {
        static void Main(string[] args)
        {
            // InitLibraries();
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                InitLibraries();
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
            }
        }

        static void InitLibraries()
        {
            var typesWithLibrariesSettings = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assm => assm.FullName.Contains("Library"))
                .SelectMany(assm => assm.GetTypes()).Where(type => type.GetInterfaces().Contains(typeof(ILibrarySettings)));

            typesWithLibrariesSettings.ToList().ForEach(type =>
            {
                type.GetMethod("Apply").Invoke(Activator.CreateInstance(type), null);

            });
        }
    }
}
