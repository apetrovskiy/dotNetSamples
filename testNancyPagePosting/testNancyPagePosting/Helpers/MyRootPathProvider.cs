
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
            var index = serverAssembly.Location.LastIndexOf('/');
            if (0 >= index)
                index = serverAssembly.Location.LastIndexOf('\\');
            return serverAssembly.Location.Substring(0, index);
        }
    }
}

