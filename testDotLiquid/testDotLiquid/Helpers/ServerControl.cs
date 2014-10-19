/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/14/2014
 * Time: 2:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDotLiquid.Helpers
{
    using System;
    using DotLiquid;
    using Nancy;
    using Nancy.Hosting.Self;
    
    /// <summary>
    /// Description of ServerControl.
    /// </summary>
    public static class ServerControl
    {
        public static void Start()
        {
			StaticConfiguration.DisableErrorTraces = false;
			
			Template.RegisterSafeType(typeof(User), new[] { "Name", "Tasks" });
			Template.RegisterSafeType(typeof(Task), new[] { "Name" });
			Template.RegisterSafeType(typeof(Suite), new[] { "Id", "Name", "Scenarios" });
			Template.RegisterSafeType(typeof(Scenario), new[] { "Id", "Name", "Status", "Results" });
			Template.RegisterSafeType(typeof(Result), new[] { "Id", "Name", "Status" });

			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.WriteLine ("Press any key to stop server...");
				Console.ReadLine();
			}
        }
        
        public static void Stop()
        {
            // 
        }
    }
}
