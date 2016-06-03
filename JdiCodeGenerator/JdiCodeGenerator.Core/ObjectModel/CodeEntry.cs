namespace JdiCodeGenerator.Core.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;

    public class CodeEntry : ICodeEntry
    {
        public Guid Id { get; set; }
        public List<LocatorDefinition> Locators { get; set; }
        public string MemberName { get; set; }
        public HtmlElementTypes HtmlMemberType { get; set; }
        public JdiElementTypes JdiMemberType { get; set; }
        public string MemberType { get; set; }

        // temporarily!
        public string Type { get; set; }

        SupportedLanguages _language;

        public CodeEntry()
        {
            Id = Guid.NewGuid();
            Locators = new List<LocatorDefinition>();
        }

        public string GenerateCodeForEntry(SupportedLanguages language)
        {
            var result = string.Empty;

            // TODO: for the future use
            _language = language;

            FilterOutWrongLocators();

            result = GenerateCodeEntryWithBestLocator();

            return result;
        }

        void FilterOutWrongLocators()
        {
            // TODO: test with Selenium
            Locators.ForEach(locator =>
            {
                // if () outside the screen
            });
        }

        internal string GenerateCodeEntryWithBestLocator()
        {
            if (!Locators.Any())
                return string.Empty;

            var bestLocator = Locators.First(locator => locator.IsBestChoice);
            var result = string.Empty;
            if (SupportedLanguages.Java == _language)
                result = string.Format("\r\n@{0}({1}=\"{2}\")", bestLocator.Attribute, bestLocator.SearchTypePreference, bestLocator.SearchString);
            if (SupportedLanguages.CSharp == _language)
                result = string.Format("\r\n[{0}({1}=\"{2}\")]", bestLocator.Attribute, bestLocator.SearchTypePreference, bestLocator.SearchString);

            var overallResult = string.Empty;

            if (SupportedLanguages.Java == _language || SupportedLanguages.CSharp == _language)
                overallResult = string.IsNullOrEmpty(result) ? result : result + string.Format("\r\npublic {0} {1};", "I" + JdiMemberType, MemberName);

            return overallResult;
        }
    }
}