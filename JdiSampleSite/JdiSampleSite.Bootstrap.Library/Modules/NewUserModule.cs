namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System;
    using Data;
    using Models;
    using Nancy;
    using Nancy.Responses.Negotiation;
    using System.Linq;
    using Models.Abstract;
    using Nancy.ModelBinding;

    public class NewUserModule : NancyModule
    {
        public NewUserModule() : base(BootstrapLib.RootUrl + BootstrapLib.Users)
        {
            Post["/"] = _ => CreateNewUser(this.Bind<User>());
            Get[BootstrapLib.User] = parameters => GetUser(parameters.id);
        }

        Negotiator CreateNewUser(IUser partialUser)
        {
            UsersCollection.AddUser(new User
            {
                FirstName = partialUser.FirstName,
                LastName = partialUser.LastName,
                BirthDate = partialUser.BirthDate
            });

            return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("users");
        }

        Negotiator GetUser(Guid id)
        {
            var user = UsersCollection.Users.First(usr => usr.Id == id);
            // return null == user ? View["error"] : View["user", user];
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(user);
        }
    }
}