namespace ProbeGen.SpecFlowPlugin
{
    using System.Diagnostics;
    using TechTalk.SpecFlow.Generator.Plugins;
    using TechTalk.SpecFlow.Infrastructure;

    public class PluginClass : IGeneratorPlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters)
        {
            // throw new System.NotImplementedException();
            Trace.WriteLine("ProbeGen is running");
        }
    }
}