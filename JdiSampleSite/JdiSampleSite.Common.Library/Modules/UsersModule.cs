namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy;
    using Nancy.Responses.Negotiation;

    public class UsersModule : NancyModule
    {
        public UsersModule() : base(Constants.RootPath + Constants.Users)
        {
            Get["/"] = parameters => DisplayUsers(parameters.RootPath);
            Get[Constants.User] = parameters => GetUser(parameters.RootPath, parameters.id);
            Delete[Constants.User] = parameters => RemoveUser(parameters.RootPath, parameters.id);
        }

        Negotiator DisplayUsers(string rootPath)
        {
            return Negotiate.WithView(rootPath + "/" + Constants.ViewNameUsers).WithModel(GetUsers()).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }

        Negotiator GetUser(string rootPath, Guid id)
        {
            var user = GetUserById(id);
            return Negotiate.WithView(rootPath + "/" + Constants.ViewNameUser).WithModel((User)user).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }

        Negotiator RemoveUser(string rootPath, Guid id)
        {
            var user = GetUserById(id);
            UsersCollection.Users.RemoveAll(usr => usr.Id == user.Id);
            return Negotiate.WithView(rootPath + "/" + Constants.ViewNameUsers).WithModel(GetUsers()).WithStatusCode(HttpStatusCode.NoContent).WithFullNegotiation();
        }

        IUser GetUserById(Guid id)
        {
            return UsersCollection.Users.FirstOrDefault(usr => usr.Id == id) ?? new User();
        }

        ExpandoObject GetUsers()
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;
            return data;
        }
    }
}