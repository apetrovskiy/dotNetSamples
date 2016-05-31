namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System.Dynamic;
    using Common.Library;
    using Common.Library.Data;
    using Nancy;
    public class DefaultModule : NancyModule
    {
        public DefaultModule() : base(Constants.BootstrapRootUrl)
        {
            // Get["/"] = _ => "Bootstrap root is here!";
            Get["/"] = _ =>
            {
                dynamic data = new ExpandoObject();
                data.Groups = GroupsCollection.Groups;
                return View["bootstrap", data];
            };
        }
    }
}