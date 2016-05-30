namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using Models.Abstract;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;

    public class NewGroupModule : NancyModule
    {
        public NewGroupModule() : base(BootstrapLib.RootUrl + BootstrapLib.Groups)
        {
            Post["/"] = _ => CreateNewGroup(this.Bind<Group>());
            Get[BootstrapLib.Group] = parameters => GetGroup(parameters.id);
        }

        Negotiator GetGroup(Guid groupId)
        {
            var group = GroupsCollection.Groups.First(grp => grp.Id == groupId);
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