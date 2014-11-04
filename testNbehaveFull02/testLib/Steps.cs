/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/25/2014
 * Time: 5:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using NBehave.Narrator.Framework;
using NUnit.Framework;

// namespace NBehavePlay
namespace testLib
{
    [ActionSteps]
    public class StepsImpl
    {
        [Given("a list of books:")]
        public void SomeBooks(List<Book> books)
        {
            ScenarioContext.Current.Add("books", books);
        }

        [When("I search for books that have '$titleSearch' in their title")]
        public void When_I_search(string titleSearch)
        {
            var books = ScenarioContext.Current.Get<List<Book>>("books");
            var found = books.Where(_ => _.Title.Contains(titleSearch)).ToList();
            ScenarioContext.Current["found"] = found;
        }

        [Then("I should find:")]
        public void Then_I_should_find_book_with_title_title(List<Book> expectedToFind)
        {
            var actual = ScenarioContext.Current.Get<List<Book>>("found");

            // expectedToFind.Add(new Book { Title = "aaaaa", Isbn = "3333" });
            // actual.Add(new Book { Title = "sdf", Isbn = "3245325" });
            
//            CollectionAssert.AreEquivalent(expectedToFind, actual);
            var aa = expectedToFind.Select(b => new { b.Title, b.Isbn }).ToDictionary(t => t.Title);
            var bb = actual.Select(b => new { b.Title, b.Isbn }).ToDictionary(t => t.Title);
            CollectionAssert.AreEquivalent(aa, bb);
        }
    }
    
    public class Book
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
    }
}
