namespace JdiSampleSite.Bootstrap.Library.Models
{
    using System;
    using Abstract;

    public class User : IUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}