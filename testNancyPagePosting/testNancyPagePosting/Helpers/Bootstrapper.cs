
namespace testNancyPagePosting
{
    using System;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Extensions;
    using Nancy.Diagnostics;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions (Nancy.Conventions.NancyConventions nancyConventions)
        {
            StaticConfiguration.DisableErrorTraces = false;
            // nancyConventions.ViewLocationConventions.Add (Environment.CurrentDirectory + "/Views", "/");
            // nancyConventions.StaticContentsConventions.Add(
            //     StaticContentConventionBuilder.AddDirectory((new MyRootPathProvider()).GetRootPath() + @"Views/data", "/data")); 
            base.ConfigureConventions (nancyConventions);
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new MyRootPathProvider(); }
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
                        get {
                                return new DiagnosticsConfiguration { Password = "admin" };
                            }
                    } 
    }
}

