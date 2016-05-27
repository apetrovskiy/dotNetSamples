namespace JdiSampleSite.Bootstrap.Library.Models.Abstract
{
    using System;

    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        // 
    }
}