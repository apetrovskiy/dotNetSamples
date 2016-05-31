namespace JdiSampleSite.Common.Library.Models.Abstract
{
    using System;

    public interface IUser
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        string City { get; set; }
        string Email { get; set; }
    }
}