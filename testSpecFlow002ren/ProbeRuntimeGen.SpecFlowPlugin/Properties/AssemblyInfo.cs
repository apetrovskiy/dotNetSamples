using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ProbeRuntimeGen.SpecFlowPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("EPAM Systems")]
[assembly: AssemblyProduct("ProbeRuntimeGen.SpecFlowPlugin")]
[assembly: AssemblyCopyright("Copyright © EPAM Systems 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: GeneratorPlugin(typeof(ProbeRuntimeGen.SpecFlowPlugin.PluginClass))]
[assembly: RuntimePlugin(typeof(ProbeRuntimeGen.SpecFlowPlugin.PluginClass))]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3cd971c8-35e4-4c64-b1b6-d8fcef150b63")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
