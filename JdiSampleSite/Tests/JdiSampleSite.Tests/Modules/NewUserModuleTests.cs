namespace JdiSampleSite.Tests.Modules
{
    using System;
    using Bootstrap.Library;
    using Bootstrap.Library.Modules;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy.Testing;
    using Xunit;

    public class NewUserModuleTests
    {
        readonly Guid _guid01 = Guid.NewGuid();
        const string FirstName01 = "Mickey";
        const string LastName01 = "Mouse";
        readonly DateTime _birthDate01 = new DateTime(1938, 8, 8);
        const string City01 = "New York";
        const string @Email01 = "micky@hotmail.com";

        Browser _browser;
        BrowserResponse _response;

        public NewUserModuleTests()
        {
            UsersCollection.Clear();
            _browser = new Browser(with => with.Modules(typeof(NewUserModule)));
        }

        ~NewUserModuleTests()
        {
            UsersCollection.Clear();
        }

        [Fact]
        public void NewUserViaPut()
        {
            UsersCollection.Clear();
            var user = GivenNewUser(FirstName01, LastName01, _birthDate01, City01, Email01);
            WhenPuttingNewUser(user);
            ThenThereIsUserInTheUsersCollection(user);
        }

        [Fact]
        public void NewUserViaPost()
        {
            UsersCollection.Clear();
            var user = GivenNewUser(FirstName01, LastName01, _birthDate01, City01, Email01);
            WhenPostingUser(user);
            ThenThereIsUserInTheUsersCollection(user);
        }

        IUser GivenNewUser(string firstName, string lastName, DateTime birthDate, string city, string email)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                City = city,
                Email = email
            };
        }

        void WhenPuttingNewUser(IUser user)
        {
            _response = _browser.Put(Constants.BootstrapRootUrl + Constants.Users + "/", with =>
            {
                with.JsonBody(user);
                with.Accept("application/json");
            });
        }

        void WhenPostingUser(IUser user)
        {
            _response = _browser.Post(Constants.BootstrapRootUrl + Constants.Users + "/", with =>
            {
                with.JsonBody(user);
                with.Accept("application/json");
            });
        }

        void ThenThereIsUserInTheUsersCollection(IUser userExpected)
        {
            // TODO: create a comparator
            // Assert.True(UsersCollection.Users.Exists(user => user == _user01));
            // Assert.True(UsersCollection.Users.Exists(user => user.FirstName == userExpected.FirstName && user.LastName == userExpected.LastName && user.BirthDate == userExpected.BirthDate && user.Id == userExpected.Id));
            Assert.True(
                UsersCollection.Users.Exists(
                    user =>
                        user.FirstName == userExpected.FirstName && user.LastName == userExpected.LastName &&
                        user.BirthDate == userExpected.BirthDate && user.City == userExpected.City && user.Email == userExpected.Email));
        }
    }
}