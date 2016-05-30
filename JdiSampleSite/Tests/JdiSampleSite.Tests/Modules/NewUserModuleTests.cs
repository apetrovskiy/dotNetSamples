namespace JdiSampleSite.Tests.Modules
{
    using System;
    using Bootstrap.Library;
    using Bootstrap.Library.Data;
    using Bootstrap.Library.Models;
    using Bootstrap.Library.Models.Abstract;
    using Bootstrap.Library.Modules;
    using Nancy.Testing;
    using Xunit;

    public class NewUserModuleTests
    {
        const string FirstName01 = "Mickey";
        const string LastName01 = "Mouse";
        readonly Guid _guid01 = Guid.NewGuid();
        readonly DateTime _birthDate01 = new DateTime(1938, 8, 8);
        const string FirstName02 = "Donald";
        const string LastName02 = "Duck";
        readonly Guid _guid02 = Guid.NewGuid();
        readonly DateTime _birthDate02 = new DateTime(1941, 1, 1);
        Browser _browser;
        BrowserResponse _response;

        public NewUserModuleTests()
        {
            UsersCollection.Users.Clear();
            _browser = new Browser(with => with.Modules(typeof(NewUserModule)));
        }

        ~NewUserModuleTests()
        {
            UsersCollection.Users.Clear();
        }

        [Fact]
        public void NewEmptyUser()
        {
            UsersCollection.Users.Clear();
            var user = GivenNewUser(FirstName01, LastName01, _birthDate01);
            WhenPostingUser(user);
            ThenThereIsUserInTheUsersCollection(user);
        }

        [Fact]
        public void GetUser()
        {
            UsersCollection.Users.Clear();
            var user = GivenNewUser(FirstName02, LastName02, _birthDate02);
            user.Id = _guid02;
            UsersCollection.AddUser(user);

            WhenGettingUser(_guid02);

            ThenThereIsUserLoadedFromTheUsersCollection(user);
        }


        IUser GivenNewUser(string firstName, string lastName, DateTime birthDate)
        {
            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };
        }

        void WhenPostingUser(IUser user)
        {
            _response = _browser.Post(BootstrapLib.RootUrl + BootstrapLib.Users + "/", with =>
            {
                with.JsonBody(user);
                with.Accept("application/json");
            });
        }

        void WhenGettingUser(Guid userId)
        {
            _response = _browser.Get(BootstrapLib.RootUrl + BootstrapLib.Users + "/" + userId, with =>
            {
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
                        user.BirthDate == userExpected.BirthDate));
        }

        void ThenThereIsUserLoadedFromTheUsersCollection(IUser user)
        {
            var actualUser = _response.Body.DeserializeJson<User>();
            Assert.Equal(user.FirstName, actualUser.FirstName);
            Assert.Equal(user.LastName, actualUser.LastName);
            Assert.Equal(user.BirthDate, actualUser.BirthDate);
            Assert.Equal(user.Id, actualUser.Id);
        }
    }
}