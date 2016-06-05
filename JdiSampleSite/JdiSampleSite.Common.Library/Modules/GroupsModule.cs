namespace JdiSampleSite.Common.Library.Modules
{
    using System.Dynamic;
    using Common.Library;
    using Common.Library.Data;
    using Nancy;
    using Nancy.Responses.Negotiation;
    using Settings;

    public class GroupsModule : NancyModule
    {
        public GroupsModule() : base(Constants.RootPath + Constants.Groups)
        {
            Get["/"] = parameters => DisplayGroups(parameters.RootPath);
        }

        Negotiator DisplayGroups(string rootPath)
        {
            dynamic data = new ExpandoObject();
            data.Groups = GroupsCollection.Groups;
            return Negotiate.WithView(rootPath + "/" + Constants.ViewNameGroups).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }
    }
}
