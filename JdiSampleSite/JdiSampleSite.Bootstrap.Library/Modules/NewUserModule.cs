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

        Negotiator CreateNewUser(IUser userInfo)
        {
            UsersCollection.AddUser(new User
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                BirthDate = userInfo.BirthDate,
                City = userInfo.City,
                Email = userInfo.Email
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