namespace JdiSampleSite.Common.Library.Models
{
    using System;
    using System.Collections.Generic;
    using Abstract;

    public class Group : IGroup
    {
        public string Name { get; set; }
        public List<IUser> Members { get; set; }
        public Guid Id { get; set; }

        public Group()
        {
            Id = Guid.NewGuid();
            Members = new List<IUser>();
        }
    }
}