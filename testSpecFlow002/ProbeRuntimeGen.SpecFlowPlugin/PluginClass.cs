namespace ProbeRuntimeGen.SpecFlowPlugin
{
    using System.Diagnostics;
    using TechTalk.SpecFlow.Generator.Plugins;
    using TechTalk.SpecFlow.Plugins;
    public class PluginClass : IGeneratorPlugin, IRuntimePlugin
    {
        public void Initialize(GeneratorPluginEvents generatorPluginEvents, GeneratorPluginParameters generatorPluginParameters)
        {
            // throw new System.NotImplementedException();
            Trace.WriteLine("ProbeRuntimeGen is running");
        }

        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            // throw new System.NotImplementedException();
            Trace.WriteLine("ProbeRuntimeGen is running");
        }
    }
}
