
namespace testDotLiquid
{
	using System;
	using System.Reflection;
	using System.Linq;
	using Nancy;

	public class TmxServerRootPathProvider : IRootPathProvider
	{
		public string GetRootPath()
		{
			var serverAssembly = (AppDomain.CurrentDomain.GetAssemblies().First(asm => asm.FullName.Contains("testDotLiquid")));
			return serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('/'));
		}
	}
}

