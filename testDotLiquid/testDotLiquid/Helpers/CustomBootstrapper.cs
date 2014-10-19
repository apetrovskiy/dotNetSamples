
namespace testDotLiquid
{
	using System;
    using System.Reflection;
	using Nancy;
	using Nancy.Bootstrapper;
	using Nancy.Conventions;
	using Nancy.Diagnostics;

	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
Console.WriteLine("0000000000000001");
			nancyConventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath(), "Root"));

			// TODO: to a separate assembly
			nancyConventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"/Nwx", "Nwx"));

			nancyConventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("probe", @"dotLiquid/probe")
				);
			nancyConventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory(@"dotLiquid/probe", "probe")
				);

			base.ConfigureConventions(nancyConventions);
Console.WriteLine("0000000000000002");
                     
		}

		protected override DiagnosticsConfiguration DiagnosticsConfiguration {
			get {
				return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
			}
		}

		protected override IRootPathProvider RootPathProvider
		{
			get { return new TmxServerRootPathProvider(); }
		}
	}
}

