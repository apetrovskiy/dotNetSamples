namespace JdiSampleSite.Bootstrap.Library.Models
{
    using System.Collections.Generic;
    using Abstract;

    public class Group : IGroup
    {
        public string Name { get; set; }
        public List<IUser> Members { get; set; }

        public Group()
        {
            Members = new List<IUser>();
        }
    }
}