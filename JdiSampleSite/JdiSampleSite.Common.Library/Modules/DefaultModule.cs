namespace JdiSampleSite.Common.Library.Modules
{
    using System.Dynamic;
    using Common.Library;
    using Common.Library.Data;
    using Nancy;
    using Nancy.Responses.Negotiation;

    public class DefaultModule : NancyModule
    {
        // public DefaultModule() : base(BootstrapLibSettings.Path.FrameworkRoot)
        // public DefaultModule() : base(Constants.BootstrapRootUrl)
        public DefaultModule() : base(Constants.RootPath)
        {
            // Get["/"] = _ => "Bootstrap root is here!";
            // Get["/"] = _ =>
            Get["/"] = parameters => DisplayDefaultPage(parameters.RootPath);
            //{
            //    dynamic data = new ExpandoObject();
            //    data.Groups = GroupsCollection.Groups;
            //    // return View["bootstrap", data];
            //    return View["bootstrap", data];
            //};
        }

        Negotiator DisplayDefaultPage(string rootPath)
        {
            dynamic data = new ExpandoObject();
            data.Groups = GroupsCollection.Groups;
            return View[rootPath + "/" + Constants.ViewNameDefault, data];
        }
    }
}
