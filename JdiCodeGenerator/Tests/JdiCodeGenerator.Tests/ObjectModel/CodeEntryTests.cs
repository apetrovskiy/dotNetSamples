namespace JdiCodeGenerator.Tests.ObjectModel
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Helpers;
    using Core.ObjectModel;
    using Core.ObjectModel.Abstract;
    using Core.ObjectModel.Plugins.BootstrapAndCompetitors;
    using HtmlAgilityPack;
    using Mocks;
    using NSubstitute;
    using Xunit;

    public class CodeEntryTests
    {
        ICodeEntry _entry;
        string _code;

        public CodeEntryTests()
        {
            _entry = null;
            _code = string.Empty;
        }

        /*
        Guid Id { get; set; }
        List<LocatorDefinition> Locators { get; set; }
        string MemberName { get; set; }
        HtmlElementTypes HtmlMemberType { get; set; }
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
            var locatorDefinitions = ConvertStringArrayToLocatorDefinitions(stringLocatorDefinitions);
            GivenCodeEntry(locatorDefinitions, memberType);
            WhenGeneratingTitle();
            ThenTitleIs(expectedTitle);
        }

        [Theory]
        [InlineData(new[] { "id", "id" }, "", "IElement")]
        [InlineData(new[] { "id", "id" }, "input", "ITextField")]
        [InlineData(new[] { "id", "id" }, "label", "ILabel")]
        [InlineData(new[] { "id", "id" }, "button", "IButton")]
        [InlineData(new[] { "id", "id" }, "select", "ICheckBox")]
        [InlineData(new[] { "id", "id" }, "a", "ILink")]
        [InlineData(new[] { "id", "id" }, "img", "IImage")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        //[InlineData(new[] { "id", "id" }, "label", "ILabel")]
        [Trait("Category", "EntryJdiType")]
        public void GenerateCodeEntryWithBestLocator(string[] stringLocatorDefinitions, string memberType, string expectedJdiType)
        {
            var locatorDefinitions = ConvertStringArrayToLocatorDefinitions(stringLocatorDefinitions);
            GivenCodeEntry(locatorDefinitions, memberType);
            WhenGeneratingCode();
            ThenCodeContains(expectedJdiType);
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

        void WhenGeneratingCode()
        {
            // var node = Substitute.For<HtmlNode>(HtmlNodeType.Element, new HtmlDocument(), 1);
            var node = Substitute.For<HtmlNodeMock>(HtmlNodeType.Element, new HtmlDocument(), 1);
            node.OriginalName.Returns(_entry.MemberType);
            // _entry.JdiMemberType = node.ConvertHtmlTypeToJdiType();

            // var htmlNodeType = new General().Analyze(node.OriginalName);
            //// result = node.ApplyGeneralAnalyzer();
            // _entry.JdiMemberType = node.ApplyApplicableAnalyzers();
            // _entry.JdiMemberType = node.ApplyApplicableAnalyzers();
            var bootstrapAnalyzer = new Bootstrap();
            var htmlElementType = bootstrapAnalyzer.ConvertHtmlNativeTypeToHtmlElementType(node.OriginalName);
            _entry.JdiMemberType = bootstrapAnalyzer.ConvertHtmlTypeToJdiType(htmlElementType);

            _code = _entry.GenerateCodeForEntry(SupportedLanguages.Java);
        }

        void ThenTitleIs(string expectedTitle)
        {
            Assert.Equal(expectedTitle, _entry.MemberName);
        }

        void ThenCodeContains(string expectedJdiType)
        {
            Assert.True(_code.Contains(expectedJdiType));
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

        List<LocatorDefinition> ConvertStringArrayToLocatorDefinitions(string[] stringLocatorDefinitions)
        {
            return new List<LocatorDefinition> { new LocatorDefinition { Attribute = FindTypes.FindBy, IsBestChoice = true, SearchTypePreference = ConvertStringToSearchTypePreference(stringLocatorDefinitions[0]), SearchString = stringLocatorDefinitions[1] } };
        }
    }
}