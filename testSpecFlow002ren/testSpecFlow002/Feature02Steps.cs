namespace testSpecFlow002
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class Feature02Steps
    {
        [Given(@"the user orders the following items")]
        public void GivenTheUserOrdersTheFollowingItems(Table table)
        {
            table.Rows.ToList().ForEach(row => row.Keys.ToList().ForEach(key => Console.WriteLine("{0} = {1}", key, row[key])));
        }

        [Given(@"the following customer")]
        public void GivenTheFollowingCustomer(Table table)
        {
            table.Rows.ToList().ForEach(row => row.Keys.ToList().ForEach(key => Console.WriteLine("{0} = {1}", key, row[key])));
        }

        [Given(@"the user orders the following items 2nd way")]
        public void GivenTheUserOrdersTheFollowingItemsNdWay(Table table)
        {
            var set = table.CreateSet<Book>(() => new Book() { ISBN = "123123123"});

            set.ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.ISBN}"));

            // var dict = table.CreateSet<KeyValuePair<string, float>>().ToList();
            // var dict = table.CreateSet<KeyValuePair<string, string>>().ToList();
            // var dict = table.CreateSet<Pair>().ToList();
            // var dict = table.CreateSet<Pair>(); //new Pair { Key = row["Key"], Value = row["Value"] } );
            // var dict = table.CreateSet<Pair>(new Pair { Key = , Value = row["Value"] } );
            // ScenarioContext.Current.Di
            // dict.ToList().ForEach(item => Console.WriteLine(@"{0} = {1}", item.Key, item.Value));
        }

        [Given(@"the following customer 2nd way")]
        public void GivenTheFollowingCustomerNdWay(Table table)
        {
            // ScenarioContext.Current.Pending();
            var result = table.CreateInstance<MyUser>();
            Console.WriteLine("{0} {1} {2}", result.FirstName, result.LastName, result.Email);
        }

    }

    public class Book
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }

    public class Pair
    {
        public string Key { get; set; }
        // public float Value { get; set; }
        public decimal Value { get; set; }
    }

    public class MyUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
