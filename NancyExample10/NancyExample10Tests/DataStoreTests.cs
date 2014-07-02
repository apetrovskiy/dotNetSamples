/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/1/2014
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10Tests
{
	using System;
	using System.Linq;
	using FakeItEasy;
	using Nancy.Testing;
	using NancyExample10;
	using Xunit;
	
	/// <summary>
	/// Description of DataStoreTests.
	/// </summary>
	public class DataStoreTests
	{
		readonly IDataStore fakeDataStore;
		Browser sut;
		readonly Todo aTodo;
		
		public DataStoreTests()
		{
			fakeDataStore = A.Fake<IDataStore>();
			sut = new Browser( with =>
			                  {
			                  	with.Dependency(fakeDataStore);
			                  	with.Module<TodoModule>();
			                  });
			
			aTodo = new Todo() { id = 5, title = "task 10", order = 100, completed = true };
		}
		
		[Fact]
		public void Should_store_posted_todos_in_datastore()
		{
			sut.Post("/todos/", with => with.JsonBody(aTodo));
			
			AssertCalledTryAddOnDataStoreWith(aTodo);
		}
		
		private void AssertCalledTryAddOnDataStoreWith(Todo expected)
		{
			A.CallTo(() =>
			         fakeDataStore.TryAdd(A<Todo>.That.Matches(actual =>
			                                                   AssertEquality(expected, actual)
			                                                  )))
				.MustHaveHappened();
		}
		
		private bool AssertEquality(Todo expected, Todo actual)
		{
			Assert.Equal(expected.title, actual.title);
			Assert.Equal(expected.order, actual.order);
			Assert.Equal(expected.completed, actual.completed);
			return true;
		}
	}
}
