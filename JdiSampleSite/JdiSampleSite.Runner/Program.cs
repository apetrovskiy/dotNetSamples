namespace JdiSampleSite.Runner
{
    using System;
    using System.Collections.Generic;
    using Bootstrap.Library.Data;
    using Bootstrap.Library.Models;
    using Bootstrap.Library.Models.Abstract;
    using Nancy.Hosting.Self;

    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1234")))
            {
                host.Start();
                InitLibraries();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
            }
        }

        static void InitLibraries()
        {
            GroupsCollection.Groups.AddRange(
                new List<IGroup> {
                new Group
                {
                    Name = "Group01",
                    Members = new List<IUser>
                    {
                        new User { FirstName = "John", LastName = "Smith", BirthDate = new DateTime(1900, 1, 1), City = "London" },
                        new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" }
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
                        new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" },
                        new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" },
                        new User { FirstName = "John", LastName = "Joe", BirthDate = new DateTime(1953, 11, 12), City = "New York" }
                    }
                }
                });
        }
    }
}
