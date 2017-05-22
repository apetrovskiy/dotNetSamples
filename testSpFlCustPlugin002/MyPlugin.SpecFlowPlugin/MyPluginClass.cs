namespace MyPlugin.SpecFlowPlugin
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using TechTalk.SpecFlow.Configuration;
    using TechTalk.SpecFlow.Generator.Configuration;
    using TechTalk.SpecFlow.Generator.Plugins;

    public class MyPluginClass : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters)
        {
            // throw new System.NotImplementedException();
            // generatorPluginParameters.Parameters.ToList().ForEach(item => Trace.WriteLine(item));

            using (var writer = new StreamWriter(@"d:\projects\my_output.txt"))
            {
                writer.WriteLine("Parameters start");
                writer.WriteLine(generatorPluginParameters.Parameters.Length);
                generatorPluginParameters.Parameters.ToList().ForEach(item =>
                {
                    writer.WriteLine(item);
                    writer.Flush();
                });
                writer.WriteLine("Parameters stop");
                writer.Flush();
            }

            generatorPluginEvents.CustomizeDependencies += GeneratorPluginEventsOnCustomizeDependencies;
            generatorPluginEvents.RaiseConfigurationDefaults(new SpecFlowProjectConfiguration
            { 
                GeneratorConfiguration = new GeneratorConfiguration
                {
                    AllowDebugGeneratedFiles = true,
                    AllowRowTests = true //,
                    // CustomDependencies = 
                    // FeatureLanguage`
                },
                RuntimeConfiguration = new RuntimeConfiguration
                {
                    TraceSuccessfulSteps = true,
                    TraceTimings = true,
                    
                }
            });
        }

        private void GeneratorPluginEventsOnCustomizeDependencies(object sender, CustomizeDependenciesEventArgs customizeDependenciesEventArgs)
        {
            string unitTestProviderName = customizeDependenciesEventArgs.SpecFlowProjectConfiguration.GeneratorConfiguration.GeneratorUnitTestProvider;

            if (unitTestProviderName.Equals("mstest", StringComparison.InvariantCultureIgnoreCase) ||
                unitTestProviderName.Equals("mstest.2010", StringComparison.InvariantCultureIgnoreCase))
            {
                // customizeDependenciesEventArgs.ObjectContainer.RegisterTypeAs<MsTestContextGeneratorProvider, IUnitTestGeneratorProvider>();
            }
        }

    }
}
