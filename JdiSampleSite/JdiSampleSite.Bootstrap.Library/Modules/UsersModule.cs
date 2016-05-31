namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Nancy;
    using Nancy.Responses.Negotiation;

    public class UsersModule : NancyModule
    {
        public UsersModule() : base(Constants.BootstrapRootUrl + Constants.Users)
        {
            Get["/"] = _ => DisplayUsers();
            Get[Constants.User] = parameters => GetUser(parameters.id);
        }

        Negotiator DisplayUsers()
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;
            return View["users", data];
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView("users").WithModel<ExpandoObject>(data);
        }

        Negotiator GetUser(Guid id)
        {
            var user = UsersCollection.Users.FirstOrDefault(usr => usr.Id == id) ?? new User();
            // return null == user ? View["error"] : View["user", user];
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(user);
            //dynamic data = new ExpandoObject();
            //data.FirstName = user.FirstName;
            //data.LastName = user.LastName;
            // data.User = user;
            // return View["user", user].WithModel(user).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            // return View["user", data].WithModel(user).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            // return View["user", data].WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            // return View["user", data];
            return View["user", user];
        }
    }
}