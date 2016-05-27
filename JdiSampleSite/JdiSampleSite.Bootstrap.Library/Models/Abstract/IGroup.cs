namespace JdiSampleSite.Bootstrap.Library.Models.Abstract
{
    using System.Collections.Generic;

    public interface IGroup
    {
        string Name { get; set; }
        List<IUser> Members { get; set; }
    }
}