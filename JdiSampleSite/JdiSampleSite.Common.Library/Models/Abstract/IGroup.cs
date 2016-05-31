namespace JdiSampleSite.Common.Library.Models.Abstract
{
    using System;
    using System.Collections.Generic;

    public interface IGroup
    {
        Guid Id { get; set; }
        string Name { get; set; }
        List<IUser> Members { get; set; }
    }
}