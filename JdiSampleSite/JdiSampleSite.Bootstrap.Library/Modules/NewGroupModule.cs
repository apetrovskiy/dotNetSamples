namespace JdiSampleSite.Bootstrap.Library.Modules
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

    public class NewGroupModule : NancyModule
    {
        public NewGroupModule() : base(Constants.BootstrapRootUrl + Constants.Groups)
        {
            Post["/"] = _ => CreateNewGroup(this.Bind<Group>());
            Get[Constants.Group] = parameters => GetGroup(parameters.id);
        }

        Negotiator GetGroup(Guid groupId)
        {
            var group = GroupsCollection.Groups.FirstOrDefault(grp => grp.Id == groupId) ?? new Group();
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(group);
        }

        Negotiator CreateNewGroup(IGroup partialGroup)
        {
            GroupsCollection.AddGroup(new Group
            {
                Name = partialGroup.Name
            });
            return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("groups");
        }
    }
}