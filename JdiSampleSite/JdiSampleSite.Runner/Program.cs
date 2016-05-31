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
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                InitLibraries();
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
                //Console.WriteLine(type.Name);
                //Console.WriteLine(type.Namespace);
                type.GetMethod("Apply").Invoke(Activator.CreateInstance(type), null);

            });
        }
    }
}
