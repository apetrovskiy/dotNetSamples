namespace ProbeRuntime.SpecFlowPlugin
{
    using System.Diagnostics;
    using TechTalk.SpecFlow.Plugins;
    public class PluginClass : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            // throw new System.NotImplementedException();
            Trace.WriteLine("ProbeRuntime is running");
        }
    }
}