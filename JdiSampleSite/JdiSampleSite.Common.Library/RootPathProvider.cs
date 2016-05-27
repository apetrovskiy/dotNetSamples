namespace JdiSampleSite.Common.Library
{
    using System;
    using System.Linq;
    using Nancy;

    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var serverAssembly = (AppDomain.CurrentDomain.GetAssemblies().First(asm => asm.FullName.Contains("JdiSampleSite")));
            return serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('\\'));
        }
    }
}