//namespace JdiSampleSite.Bootstrap.Library.Modules
//{
//    using System;
//    using System.Dynamic;
//    using System.Linq;
//    using Common.Library;
//    using Common.Library.Data;
//    using Common.Library.Models;
//    using Common.Library.Models.Abstract;
//    using Nancy;
//    using Nancy.Responses.Negotiation;
//    using Settings;

//    public class UsersModule : NancyModule
//    {
//        public UsersModule() : base(Constants.BootstrapRootUrl + Constants.Users)
//        // public UsersModule() : base(BootstrapLibSettings.Path.FrameworkRoot + Constants.Users)
//        {
//            Get["/"] = _ => DisplayUsers();
//            Get[Constants.User] = parameters => GetUser(parameters.id);
//            Delete[Constants.User] = parameters => RemoveUser(parameters.id);
//        }

//        Negotiator DisplayUsers()
//        {
//            return Negotiate.WithView(Constants.ViewNameUsers).WithModel(GetUsers()).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
//        }

//        Negotiator GetUser(Guid id)
//        {
//            var user = GetUserById(id);
//            return Negotiate.WithView(Constants.ViewNameUser).WithModel((User)user).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
//        }

//        Negotiator RemoveUser(Guid id)
//        {
//            var user = GetUserById(id);
//            UsersCollection.Users.RemoveAll(usr => usr.Id == user.Id);
//            return Negotiate.WithView(Constants.ViewNameUsers).WithModel(GetUsers()).WithStatusCode(HttpStatusCode.NoContent).WithFullNegotiation();
//        }

//        IUser GetUserById(Guid id)
//        {
//            return UsersCollection.Users.FirstOrDefault(usr => usr.Id == id) ?? new User();
//        }

//        ExpandoObject GetUsers()
//        {
//            dynamic data = new ExpandoObject();
//            data.Users = UsersCollection.Users;
//            return data;
//        }
//    }
//}