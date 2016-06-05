namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System;
    using System.Dynamic;
    using Nancy;
    using Nancy.Responses.Negotiation;
    using System.Linq;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy.ModelBinding;

    public class NewUserModule : NancyModule
    {
        public NewUserModule() : base(Constants.RootPath + Constants.Users)
        {
            Post["/"] = parameters => CreateNewOrUpdateExistingUser(parameters.RootPath, this.Bind<User>());
            Put["/"] = parameters => CreateNewOrUpdateExistingUser(parameters.RootPath, this.Bind<User>());
            Put[Constants.User] = parameters => CreateNewOrUpdateExistingUser(parameters.RootPath, this.Bind<User>());
            Get[Constants.UserPage] = parameters => View[parameters.RootPath + "/" + Constants.ViewNameUser, new User()];
        }

        Negotiator CreateNewOrUpdateExistingUser(string rootPath, IUser userInfo)
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;
            var cookies = Context.NegotiationContext.Cookies;

            if (UsersCollection.Users.All(usr => usr.Id != userInfo.Id))
            {
                UsersCollection.AddUser(userInfo);
                return Negotiate.WithView(rootPath + "/" + Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.Created).WithFullNegotiation();
            }

            var existingUser = UsersCollection.Users.First(usr => usr.Id == userInfo.Id);
            UsersCollection.Users.RemoveAll(usr => usr.Id == userInfo.Id);
            UsersCollection.AddUser(userInfo);

            return Negotiate.WithView(rootPath + "/" + Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }
    }
}