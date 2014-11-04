/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/26/2014
 * Time: 6:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NBehave.Narrator.Framework;
using NBehave.Narrator.Framework.Internal;
using NBehave.Narrator.Framework.Extensions;

namespace testNbehaveWithCastle
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			
			
			var config = NBehaveConfiguration.New;
//                .SetScenarioFiles((options.ScenarioFiles).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
//                .SetDryRun(options.DryRun)
//                .SetAssemblies(assemblies)
//                .UseTagsFilter(options.Tags.Select(_=>_.Split(',')))
//                .SetEventListener(CreateEventListener(options));

			
			var specExample = new SpecExample();
			specExample.Some_extension_methods_you_can_use();
			
			var fluentExample = new FluentExample();
			fluentExample.MainSetup();
			fluentExample.should_add_1_plus_1_correctly();
			fluentExample.MainTeardown();
			
            // FeatureResults featureResults = null;

            // try
            // {
                // featureResults = Run(config);
            IRunner runner = config.Build();
            FeatureResults featureResults = runner.Run();
            // return featureResults;
			

			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}