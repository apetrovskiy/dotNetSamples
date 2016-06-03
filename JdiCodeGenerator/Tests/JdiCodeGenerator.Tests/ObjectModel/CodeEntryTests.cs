namespace JdiCodeGenerator.Tests.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Core.Helpers;
    using Core.ObjectModel;
    using Core.ObjectModel.Abstract;
    using Xunit;

    public class CodeEntryTests
    {
        ICodeEntry _entry;

        public CodeEntryTests()
        {
            _entry = null;
        }

        /*
        Guid Id { get; set; }
        List<LocatorDefinition> Locators { get; set; }
        string MemberName { get; set; }
        ElementTypes HtmlMemberType { get; set; }
        string MemberType { get; set; }

        // temporarily!
        string Type { get; set; }
        */

        [Theory]
        [InlineData(new[] { "id", "" }, "", "noTypeDetectedNoName")]
        [InlineData(new[] { "id", "" }, "input", "inputNoName")]
        [InlineData(new[] { "id", "id" }, "input", "inputId")]
        [InlineData(new[] { "name", "some name" }, "input", "inputSomeName")]
        [InlineData(new[] { "css", ".a .ul" }, "input", "inputNoName")] // ??
        [InlineData(new[] { "css", "[name='a']" }, "input", "inputNoName")] // ??
        [InlineData(new[] { "className", ".a .ul" }, "input", "inputAUl")]
        [InlineData(new[] { "xpath", "//*[class=test]" }, "input", "inputNoName")] // ??
        [InlineData(new[] { "linkText", "/aa/bb/cc" }, "input", "inputAaBbCc")]
        [InlineData(new[] { "tagName", "ttt" }, "input", "inputTtt")]
        [Trait("Category", "EntryTitle")]
        public void GeneratesEntryTitle(string[] stringLocatorDefinitions, string memberType, string expectedTitle)
        {
            var locatorDefinitions = new List<LocatorDefinition> { new LocatorDefinition {Attribute = FindTypes.FindBy, IsBestChoice = true, SearchTypePreference = ConvertStringToSearchTypePreference(stringLocatorDefinitions[0]), SearchString = stringLocatorDefinitions[1] } };
            GivenCodeEntry(locatorDefinitions, memberType);
            WhenGeneratingTitle();
            ThenTitleIs(expectedTitle);
        }

        void GivenCodeEntry(IEnumerable<LocatorDefinition> locatorDefinitions, string memberType)
        {
            _entry = new CodeEntry
            {
                Locators = locatorDefinitions.ToList(),
                // HtmlMemberType = memberType,
                MemberType = memberType
            };
        }

        void WhenGeneratingTitle()
        {
            _entry.MemberName = _entry.GenerateNameBasedOnNamingPreferences();
        }

        void ThenTitleIs(string expectedTitle)
        {
            Assert.Equal(expectedTitle, _entry.MemberName);
        }

        SearchTypePreferences ConvertStringToSearchTypePreference(string stringTypePreference)
        {
            switch (stringTypePreference)
            {
                case "id":
                    return SearchTypePreferences.id;
                case "name":
                    return SearchTypePreferences.name;
                case "css":
                    return SearchTypePreferences.css;
                case "className":
                    return SearchTypePreferences.className;
                case "xpath":
                    return SearchTypePreferences.xpath;
                case "linkText":
                    return SearchTypePreferences.linkText;
                case "tagName":
                    return SearchTypePreferences.tagName;
                default:
                    return SearchTypePreferences.id;
            }
        }
    }
}