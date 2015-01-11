
namespace PartyInvites.Models
{
    using System;
    using System.Web.Mvc.Html;
    // using System.Web.Mvc.Ajax;

    public class GuestResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
    }
}

