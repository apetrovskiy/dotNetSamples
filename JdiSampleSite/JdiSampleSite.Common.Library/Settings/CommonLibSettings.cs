namespace JdiSampleSite.Common.Library.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Data;
    using Models;
    using Models.Abstract;

    public class CommonLibSettings : ILibrarySettings
    {
        public void Apply()
        {
            Path = new FrameworkPath(Frameworks.NoFramework);
            InitCollections();
        }

        public static FrameworkPath Path { get; set; }

        void InitCollections()
        {
            GroupsCollection.Init();
            
            GroupsCollection.Groups.AddRange(
                new List<IGroup> {
                new Group
                {
                    Name = "Group01",
                    Members = new List<IUser>
                    {
                        new User { FirstName = "John", LastName = "Smith", BirthDate = new DateTime(1900, 1, 1), City = "London" },
                        new User { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1953, 11, 12), City = "New York" }
                    }
                },
                new Group
                {
                    Name = "Group02",
                    Members = new List<IUser>
                    {
                        new User { FirstName = "Patrick", LastName = "O'Neil", BirthDate = new DateTime(1971, 4, 3), City = "Dublin" }
                    }
                },
                new Group(),
                new Group
                {
                    Name = "Group04",
                    Members = new List<IUser>
                    {
                        new User { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1953, 11, 13), City = "New York" },
                        new User { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1953, 11, 14), City = "New York" },
                        new User { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1953, 11, 15), City = "New York" }
                    }
                }
                });
            
            UsersCollection.Init();
            
            GroupsCollection.Groups.ToList().ForEach(group => UsersCollection.Users.AddRange(group.Members));
        }
    }
}