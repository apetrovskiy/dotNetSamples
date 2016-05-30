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
            GroupsCollection.Groups.Clear();
            _browser = new Browser(with => with.Modules(typeof(NewGroupModule)));
        }

        ~NewGroupModuleTests()
        {
            GroupsCollection.Groups.Clear();
        }

        [Fact]
        public void NewEmptyGroup()
        {
            GroupsCollection.Groups.Clear();
            var group = GivenNewGroup(Name01);
            WhenPostingGroup(group);
            ThenThereIsGroupInTheGroupsCollection(group);
        }

        [Fact]
        public void GetGroup()
        {
            GroupsCollection.Groups.Clear();
            var @group = GivenNewGroup(Name02);
            @group.Id = _guid02;
            GroupsCollection.Groups.Add(@group);

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
            _response = _browser.Post(BootstrapLib.RootUrl + BootstrapLib.Groups + "/", with =>
            {
                with.JsonBody(group);
                with.Accept("application/json");
            });
        }

        void WhenGettingGroup(Guid groupId)
        {
            _response = _browser.Get(BootstrapLib.RootUrl + BootstrapLib.Groups + "/" + groupId, with =>
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