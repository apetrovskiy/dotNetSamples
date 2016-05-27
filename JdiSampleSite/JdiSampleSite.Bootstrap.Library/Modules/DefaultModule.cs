namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System.Collections.Generic;
    using System.Dynamic;
    using Data;
    using Models.Abstract;
    using Nancy;
    public class DefaultModule : NancyModule
    {
        public DefaultModule() : base(BootstrapLib.RootUrl)
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