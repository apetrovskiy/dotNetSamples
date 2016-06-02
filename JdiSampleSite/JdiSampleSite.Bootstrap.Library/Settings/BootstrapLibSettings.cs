namespace JdiSampleSite.Bootstrap.Library.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Library;
    using Common.Library.Abstract;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;

    public class BootstrapLibSettings : ILibrarySettings
    {
        //public void Apply()
        //{
        //    InitCollections();
        //}

        //void InitCollections()
        //{
        //    GroupsCollection.Groups.AddRange(
        //        new List<IGroup> {
        //        new Group
        //        {
        //            Name = "Group01",
        //            Members = new List<IUser>
        //            {
        //                new User { FirstName = "John", LastName = "Smith", BirthDate = new DateTime(1900, 1, 1), City = "London" },
        //                new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" }
        //            }
        //        },
        //        new Group
        //        {
        //            Name = "Group02",
        //            Members = new List<IUser>
        //            {
        //                new User { FirstName = "Patrick", LastName = "O'Neil", BirthDate = new DateTime(1971, 4, 3), City = "Dublin" }
        //            }
        //        },
        //        new Group(),
        //        new Group
        //        {
        //            Name = "Group04",
        //            Members = new List<IUser>
        //            {
        //                new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" },
        //                new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" },
        //                new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" }
        //            }
        //        }
        //        });

        //    GroupsCollection.Groups.ToList().ForEach(group => UsersCollection.Users.AddRange(group.Members));
        //}
        public void Apply()
        {
            Path = new FrameworkPath(Frameworks.Bootstrap);

        }

        public static FrameworkPath Path { get; set; }
    }
}