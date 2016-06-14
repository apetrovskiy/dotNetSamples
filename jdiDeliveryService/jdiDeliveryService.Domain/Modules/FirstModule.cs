namespace jdiDeliveryService.Domain.Modules
{
    using Nancy;
    public class FirstModule : NancyModule
    {
        public FirstModule()
        {
            Get["/"] = _ => View["index"];
        }
    }
}