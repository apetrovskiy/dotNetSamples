namespace JdiSampleSite.Common.Library.Modules
{
    using System;
    using System.Linq;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using System.Dynamic;
    using Settings;

    public class NewGroupModule : NancyModule
    {
        public NewGroupModule() : base(Constants.RootPath + Constants.Groups)
        {
            Post["/"] = parameters => CreateNewGroup(parameters.RootPath, this.Bind<Group>());
            Get[Constants.Group] = parameters => GetGroup(parameters.RootPath, parameters.id);
        }

        Negotiator GetGroup(string rootPath, Guid groupId)
        {
            var group = GroupsCollection.Groups.FirstOrDefault(grp => grp.Id == groupId) ?? new Group();
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel((Group)group).WithView(rootPath + "/" + Constants.ViewNameGroup).WithFullNegotiation();
        }

        Negotiator CreateNewGroup(string rootPath, IGroup partialGroup)
        {
            GroupsCollection.AddGroup(new Group
            {
                Name = partialGroup.Name
            });
            dynamic data = new ExpandoObject();
            data.Groups = GroupsCollection.Groups;
            return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView(rootPath + "/" + Constants.ViewNameGroups).WithModel((ExpandoObject)data).WithFullNegotiation();
        }
    }
}