namespace jdiDeliveryService.Runner
{
    using System;
    using Nancy.Hosting.Self;

    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1236/")))
            {
                host.Start();
            }
            Console.WriteLine("Running on http://localhost:1236");
            Console.ReadKey();
        }
    }
}
