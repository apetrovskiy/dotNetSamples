namespace JdiSampleSite.Bootstrap.Library.Data
{
    using System.Collections.Generic;
    using Models.Abstract;

    public class GroupsCollection
    {
        public static List<IGroup> Groups { get; set; } = new List<IGroup>();
    }
}