namespace JdiSampleSite.Common.Library
{
    using Nancy;
    using Nancy.Conventions;
    using Nancy.Diagnostics;

    public class DurandalNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            // base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "Scripts", "Scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "App", "App"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "Assets", "Assets"));

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "Views", "Views"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + @"Views/results", "results"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "Views/Scripts", @"Scripts", ".js"));

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "ScriptsScripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(new RootPathProvider().GetRootPath() + "fontsfonts"));

            // Console.WriteLine(new RootPathProvider().GetRootPath());
            // nancyConventions.StaticContentsConventions.ToList().ForEach(convention => Console.WriteLine(convention.Target.ToString()));

            StaticConfiguration.DisableErrorTraces = false;

            base.ConfigureConventions(nancyConventions);
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get { return new DiagnosticsConfiguration { Password = @"=1qwerty" }; }
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new RootPathProvider(); }
        }
      }
}