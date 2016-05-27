namespace JdiSampleSite.Common.Library.Modules
{
    using Nancy;

    public class FirstDurandalNancyModule : NancyModule
    {
        public FirstDurandalNancyModule()
        {
            Get["/"] = p => View["index"];

            Get["/api/list"] = p => Response.AsJson(new
            {
                Title = "Durandal & Nancy",
                Message = "Super-Duper-Happy SPA Done Right!"
            });
        }
    }
}