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
            // Post["/"] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            Put["/"] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // Post[Constants.UserPage] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            Put[Constants.UserPage] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            Put[Constants.User] = _ => CreateNewOrUpdateExistingUser(this.Bind<User>());
            // Put[Constants.User] = _ => 
            Get[Constants.UserPage] = _ => View["user", new User()];
        }

        Negotiator CreateNewOrUpdateExistingUser(IUser userInfo)
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;

            if (UsersCollection.Users.All(usr => usr.Id != userInfo.Id))
            {
                UsersCollection.AddUser(userInfo);
                return View["users", data];
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

            UsersCollection.Users.Where(usr => usr.Id == userInfo.Id).ToList().ForEach(usr => usr = userInfo);

            // return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("users");
            //return View["users"];
            return View["users", data];
            // return Negotiate.WithStatusCode(HttpStatusCode.Created).WithView("users.html");
        }
    }
}