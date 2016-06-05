namespace JdiSampleSite.Tests.Modules
{
    using System;
    using Bootstrap.Library;
    using Common.Library.Modules;
    using Common.Library;
    using Common.Library.Data;
    using Common.Library.Models;
    using Common.Library.Models.Abstract;
    using Nancy.Testing;
    using Xunit;

    public class NewGroupModuleTests
    {
        const string Name01 = "Cartoon characters";
        readonly Guid _guid01 = Guid.NewGuid();
        const string Name02 = "Presidents";
        readonly Guid _guid02 = Guid.NewGuid();
        Browser _browser;
        BrowserResponse _response;

        public NewGroupModuleTests()
        {
            // GroupsCollection.Groups.Clear();
            GroupsCollection.Clear();
            _browser = new Browser(with => with.Modules(typeof(NewGroupModule)));
        }

        ~NewGroupModuleTests()
        {
            // GroupsCollection.Groups.Clear();
            GroupsCollection.Clear();
        }

        [Fact]
        public void NewEmptyGroup()
        {
            // GroupsCollection.Groups.Clear();
            GroupsCollection.Clear();
            var group = GivenNewGroup(Name01);
            WhenPostingGroup(group);
            ThenThereIsGroupInTheGroupsCollection(group);
        }

        [Fact]
        public void GetGroup()
        {
            // GroupsCollection.Groups.Clear();
            GroupsCollection.Clear();
            var @group = GivenNewGroup(Name02);
            @group.Id = _guid02;
            GroupsCollection.AddGroup(@group);

            WhenGettingGroup(_guid02);

            ThenThereIsGroupLoadedFromTheGroupsCollection(@group);
        }

        IGroup GivenNewGroup(string groupName)
        {
            return new Group
            {
                Name = groupName
            };
        }

        void WhenPostingGroup(IGroup group)
        {
            _response = _browser.Post(Constants.BootstrapRootUrl + Constants.Groups + "/", with =>
            {
                with.JsonBody(group);
                with.Accept("application/json");
            });
        }

        void WhenGettingGroup(Guid groupId)
        {
            _response = _browser.Get(Constants.BootstrapRootUrl + Constants.Groups + "/" + groupId, with =>
            {
                with.Accept("application/json");
            });
        }

        void ThenThereIsGroupInTheGroupsCollection(IGroup groupExpected)
        {
            // TODO: create a comparator
            // Assert.True(GroupsCollection.Groups.Exists(@group => @group.Name == groupExpected.Name && @group.Id == groupExpected.Id));
            Assert.True(GroupsCollection.Groups.Exists(@group => @group.Name == groupExpected.Name));
        }

        void ThenThereIsGroupLoadedFromTheGroupsCollection(IGroup @group)
        {
            var actualGroup = _response.Body.DeserializeJson<Group>();
            Assert.Equal(@group.Name, actualGroup.Name);
            Assert.Equal(@group.Id, actualGroup.Id);
        }
    }
}