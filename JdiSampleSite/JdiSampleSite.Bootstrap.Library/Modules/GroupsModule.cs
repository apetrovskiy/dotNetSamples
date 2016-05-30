namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System.Dynamic;
    using Data;
    using Nancy;
    using Nancy.Responses.Negotiation;

    public class GroupsModule : NancyModule
    {
        public GroupsModule() : base(BootstrapLib.RootUrl + BootstrapLib.Groups)
        {
            Get["/"] = _ => DisplayGroups();
        }

        Negotiator DisplayGroups()
        {
            dynamic data = new ExpandoObject();
            data.Groups = GroupsCollection.Groups;
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(data);
            return View["groups", data];
        }
    }
}