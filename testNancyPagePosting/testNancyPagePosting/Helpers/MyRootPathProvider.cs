
namespace testNancyPagePosting
{
    using System;
    using System.Linq;
    using Nancy;

    public class MyRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            var serverAssembly = (AppDomain.CurrentDomain.GetAssemblies().First(asm => asm.FullName.Contains("testNancyPagePosting")));
            return serverAssembly.Location.Substring(0, serverAssembly.Location.LastIndexOf('/'));
        }
    }
}

