namespace JdiSampleSite.Tests.Modules
{
    using System;
    using System.Linq;
    using Bootstrap.Library;
    using Bootstrap.Library.Data;
    using Bootstrap.Library.Models;
    using Bootstrap.Library.Models.Abstract;
    using Bootstrap.Library.Modules;
    using Nancy.Testing;
    using Xunit;

    public class UsersModuleTests
    {
        const string FirstName01 = "Shek";
        const string LastName01 = "The Great";
        readonly DateTime _birthDate01 = new DateTime(2004, 4, 4);
        IUser _user01;
        const string FirstName02 = "Pinoccio";
        const string LastName02 = "The Wood";
        readonly DateTime _birthDate02 = new DateTime(1753, 3, 3);
        IUser _user02;
        Browser _browser;
        BrowserResponse _response;

        public UsersModuleTests()
        {
            UsersCollection.Users.Clear();
            _user01 = null;
            _user02 = null;
            _browser = new Browser(with => with.Modules(typeof(UsersModule)));
        }

        ~UsersModuleTests()
        {
            UsersCollection.Users.Clear();
        }

        [Fact]
        public void GettingNoUsers()
        {
            GivenThereAreNoUsersInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereAreNoUsersFromTheUsersCollection();
        }

        [Fact]
        public void GettingOneUser()
        {
            UsersCollection.Users.Clear();
            GivenThereIsUserInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereIsUserFromTheUsersCollection();
        }

        [Fact]
        public void GettingTwoUsers()
        {
            UsersCollection.Users.Clear();
            GivenThereIsUserInTheUsersCollection();
            GivenThereIsAnotherUserInTheUsersCollection();
            WhenGettingAllUsers();
            ThenThereIsUserFromTheUsersCollection();
            ThenThereIsAnotherUserFromTheUsersCollection();
        }

        void GivenThereAreNoUsersInTheUsersCollection()
        {
            // nothing to do
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
            _response = _browser.Get(BootstrapLib.RootUrl + BootstrapLib.Users + "/", with => {with.Accept("application/json");});
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
    }
}