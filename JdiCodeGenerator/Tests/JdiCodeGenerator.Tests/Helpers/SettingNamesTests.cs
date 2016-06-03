namespace JdiCodeGenerator.Tests.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Helpers;
    using Core.ObjectModel;
    using Core.ObjectModel.Abstract;
    using Xunit;

    public class SettingNamesTests
    {
        List<ICodeEntry> _codeEntries;
        List<ICodeEntry> _expectedCodeEntries;

        public SettingNamesTests()
        {
            _codeEntries = null;
            _expectedCodeEntries = null;
        }

        [Theory]
        [InlineData(new[] { "a", "b", "c" }, new[] { "buttonA", "buttonB", "buttonC" })]
        [InlineData(new[] { "a", "a", "b", "c" }, new[] { "buttonA", "buttonA1", "buttonB", "buttonC" })]
        [InlineData(new[] { "a", "a", "b", "b", "c" }, new[] { "buttonA", "buttonA1", "buttonB", "buttonB1", "buttonC" })]
        [InlineData(new[] { "a", "a", "a", "b", "c" }, new[] { "buttonA", "buttonA1", "buttonA2", "buttonB", "buttonC" })]
        [InlineData(new[] { "a", "b", "c", "a", "c" }, new[] { "buttonA", "buttonB", "buttonC", "buttonA1", "buttonC1" })]
        [Trait("Category", "SettingNames")]
        public void SetsDistinctNames(string[] originalSequence, string[] expectedSequence)
        {
            GivenCodeEntries(originalSequence);
            WhenCalculatingNames();
            ThenTheResultIs(expectedSequence);
        }

        void GivenCodeEntries(string[] originalSequence)
        {
            _codeEntries = new List<ICodeEntry>();
            originalSequence.ToList().ForEach(item => _codeEntries.Add(new CodeEntry { MemberName = item, MemberType = "button", Locators = new List<LocatorDefinition> { new LocatorDefinition { IsBestChoice = true, SearchString = item, Attribute = FindTypes.FindBy, SearchTypePreference = SearchTypePreferences.id } } }));
            for (int i = 0; i < originalSequence.Length; i++)
                _codeEntries[i].MemberName = originalSequence[i];
        }

        void WhenCalculatingNames()
        {
            _codeEntries.SetDistinguishNamesForMembers();
        }

        void ThenTheResultIs(string[] expectedSequence)
        {
            _expectedCodeEntries = new List<ICodeEntry>();
            var expectedNames = expectedSequence.ToList();
            var actualNames = _codeEntries.Select(entry1 => entry1.MemberName).ToList();
            Assert.Equal(expectedNames, actualNames);
        }
    }
}