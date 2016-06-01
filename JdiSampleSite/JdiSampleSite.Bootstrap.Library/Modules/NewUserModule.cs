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
        public NewUserModule() : base(Constants.BootstrapRootUrl + Constants.Users)
        {
            Post["/"] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // this works
            Put["/"] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // Post[Constants.UserPage] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // this works
            // Put[Constants.UserPage] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            Put[Constants.User] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // Put[Constants.User] = _ => 
            Get[Constants.UserPage] = _ => View[Constants.ViewNameUser, new User()];
        }

        Negotiator CreateNewOrUpdateExistingUser(IUser userInfo)
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;
            var cookies = Context.NegotiationContext.Cookies;

            if (UsersCollection.Users.All(usr => usr.Id != userInfo.Id))
            {
                UsersCollection.AddUser(userInfo);
                // return Negotiate.WithView(Constants.ViewNameUsers).WithFullNegotiation().WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.TemporaryRedirect).WithHeader("Location", Constants.BootstrapRootUrl + Constants.Users);
                // return Negotiate.WithView(Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.TemporaryRedirect).WithHeader("Location", Constants.BootstrapRootUrl + Constants.Users).WithCookies(cookies).WithFullNegotiation();

                // this redirects too many times
                // return Negotiate.WithView(Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.TemporaryRedirect).WithHeader("Location", Constants.BootstrapRootUrl + Constants.Users).WithCookies(cookies).WithFullNegotiation();
                return Negotiate.WithView(Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.Created).WithFullNegotiation();
            }

            //var user = UsersCollection.Users.First(usr => usr.Id == userInfo.Id) ?? new User();
            //UsersCollection.AddUser(new User
            //{
            //    FirstName = userInfo.FirstName,
            //    LastName = userInfo.LastName,
            //    BirthDate = userInfo.BirthDate,
            //    City = userInfo.City,
            //    Email = userInfo.Email
            //});

            // UsersCollection.Users.Where(usr => usr.Id == userInfo.Id).ToList().ForEach(usr => usr = userInfo);
            var existingUser = UsersCollection.Users.First(usr => usr.Id == userInfo.Id);
            UsersCollection.Users.Remove(existingUser);
            UsersCollection.AddUser(userInfo);

            // return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("users");
            //return View["users"];
            // return Negotiate.WithView(Constants.ViewNameUsers).WithFullNegotiation().WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.TemporaryRedirect).WithHeader("Location", Constants.BootstrapRootUrl + Constants.Users);

            // this redirects too many times
            // return Negotiate.WithView(Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.TemporaryRedirect).WithHeader("Location", Constants.BootstrapRootUrl + Constants.Users).WithCookies(cookies).WithFullNegotiation();
            return Negotiate.WithView(Constants.ViewNameUsers).WithModel((ExpandoObject)data).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            // return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("users.html");
        }
    }
}