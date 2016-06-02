namespace JdiSampleSite.Tests.Modules
{
    using System;
    using System.Linq;
    using Bootstrap.Library;
    using Bootstrap.Library.Modules;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy.Testing;
    using Xunit;

    public class UsersModuleTests
    {
        const string FirstName01 = "Shek";
        const string LastName01 = "The Great";
        readonly DateTime _birthDate01 = new DateTime(2004, 4, 4);
        IUser _user01;

        readonly Guid _guid02 = Guid.NewGuid();
        const string FirstName02 = "Pinoccio";
        const string LastName02 = "The Wood";
        readonly DateTime _birthDate02 = new DateTime(1753, 3, 3);
        const string City02 = "Napoli";
        const string @Email02 = "pino.the.wood@yandex.ru";
        IUser _user02;
        Browser _browser;
        BrowserResponse _response;

        public UsersModuleTests()
        {
            // UsersCollection.Users.Clear();
            UsersCollection.Clear();
            _user01 = null;
            _user02 = null;
            _browser = new Browser(with => with.Modules(typeof(UsersModule)));
        }

        ~UsersModuleTests()
        {
            UsersCollection.Clear();
        }

        [Fact]
        public void GettingAllUsersButThereIsNone()
        {
            UsersCollection.Clear();
            GivenThereAreNoUsersInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereAreNoUsersFromTheUsersCollection();
        }

        [Fact]
        public void GettingAllUsersWhenThereIsOne()
        {
            UsersCollection.Clear();
            GivenThereIsUserInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereIsUserFromTheUsersCollection();
        }

        [Fact]
        public void GettingAllUsersWhenThereAreTwo()
        {
            UsersCollection.Clear();
            GivenThereIsUserInTheUsersCollection();
            GivenThereIsAnotherUserInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereIsUserFromTheUsersCollection();
            ThenThereIsAnotherUserFromTheUsersCollection();
        }

        [Fact]
        public void GetSpecificUserById()
        {
            UsersCollection.Clear();
            UsersCollection.AddUser(new User
            {
                FirstName = FirstName02,
                LastName = LastName02,
                BirthDate = _birthDate02,
                City = City02,
                Email = Email02,
                Id = _guid02
            });

            WhenGettingUser(_guid02);

            ThenThereIsUserLoadedFromTheUsersCollection(UsersCollection.Users[0]);
        }

        [Fact]
        public void RemoveUserById()
        {
            UsersCollection.Clear();
            UsersCollection.AddUser(new User
            {
                FirstName = FirstName02,
                LastName = LastName02,
                BirthDate = _birthDate02,
                City = City02,
                Email = Email02,
                Id = _guid02
            });

            WhenDeletingUser(_guid02);

            ThenThereAreNoUsersFromTheUsersCollection();
        }

        void GivenThereAreNoUsersInTheUsersCollection()
        {
            UsersCollection.Clear();
        }

        void GivenThereIsUserInTheUsersCollection()
        {
            _user01 = new User
            {
                FirstName = FirstName01,
                LastName = LastName01,
                BirthDate = _birthDate01
            };
            UsersCollection.AddUser(_user01);
        }

        void GivenThereIsAnotherUserInTheUsersCollection()
        {
            _user02 = new User
            {
                FirstName = FirstName02,
                LastName = LastName02,
                BirthDate = _birthDate02
            };
            UsersCollection.AddUser(_user02);
        }

        void WhenGettingAllUsers()
        {
            _response = _browser.Get(Constants.BootstrapRootUrl + Constants.Users + "/", with => {with.Accept("application/json");});
        }

        void WhenGettingUser(Guid userId)
        {
            _response = _browser.Get(Constants.BootstrapRootUrl + Constants.Users + "/" + userId, with =>
            {
                with.Accept("application/json");
            });
        }

        void WhenDeletingUser(Guid userId)
        {
            _response = _browser.Delete(Constants.BootstrapRootUrl + Constants.Users + "/" + userId, with =>
            {
                with.Accept("application/json");
            });
        }

        void ThenThereAreNoUsersFromTheUsersCollection()
        {
            Assert.True(0 == UsersCollection.Users.Count || !UsersCollection.Users.Any());
        }

        void ThenThereIsUserFromTheUsersCollection()
        {
            Assert.True(UsersCollection.Users.Exists(user => user.FirstName == _user01.FirstName && user.LastName == _user01.LastName && user.BirthDate == _user01.BirthDate));
        }

        void ThenThereIsAnotherUserFromTheUsersCollection()
        {
            Assert.True(UsersCollection.Users.Exists(user => user.FirstName == _user02.FirstName && user.LastName == _user02.LastName && user.BirthDate == _user02.BirthDate));
        }

        void ThenThereIsUserLoadedFromTheUsersCollection(IUser user)
        {
            var actualUser = _response.Body.DeserializeJson<User>();
            Assert.Equal(user.Id, actualUser.Id);
            Assert.Equal(user.FirstName, actualUser.FirstName);
            Assert.Equal(user.LastName, actualUser.LastName);
            Assert.Equal(user.BirthDate, actualUser.BirthDate);
            Assert.Equal(user.City, actualUser.City);
            Assert.Equal(user.Email, actualUser.Email);
        }
    }
}