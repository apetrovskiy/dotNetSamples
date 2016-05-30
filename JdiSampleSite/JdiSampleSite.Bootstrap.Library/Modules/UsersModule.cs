namespace JdiSampleSite.Bootstrap.Library.Modules
{
    using System.Dynamic;
    using Data;
    using Nancy;
    using Nancy.Responses.Negotiation;

    public class UsersModule : NancyModule
    {
        public UsersModule() : base(BootstrapLib.RootUrl + BootstrapLib.Users)
        {
            Get["/"] = _ => DisplayUsers();
        }

        Negotiator DisplayUsers()
        {
            dynamic data = new ExpandoObject();
            data.Users = UsersCollection.Users;
            return View["users", data];
            // return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView("users").WithModel<ExpandoObject>(data);
        }
    }
}