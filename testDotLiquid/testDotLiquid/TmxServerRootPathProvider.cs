
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
			string resultPath = string.Empty;
			try {
			    resultPath = serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('/'));
			}
			catch {}
			if (string.Empty == resultPath)
			    resultPath = serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('\\'));
			// return serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('/'));
			return resultPath;
		}
	}
}

