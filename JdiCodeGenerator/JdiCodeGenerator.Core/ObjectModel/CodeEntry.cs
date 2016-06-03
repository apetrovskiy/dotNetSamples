namespace JdiCodeGenerator.Core.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Epam.JDI.Core.Interfaces.Base;

    public class CodeEntry : ICodeEntry
    {
        public Guid Id { get; set; }
        // [JsonProperty(ItemConverterType = typeof(IEnumerable<LocatorDefinition>))]
        // public List<ILocatorDefinition> Locators { get; set; }
        public List<LocatorDefinition> Locators { get; set; }
        public string MemberName { get; set; }
        public ElementTypes HtmlMemberType { get; set; }
        public string MemberType { get; set; }

        // temporarily!
        public string Type { get; set; }

        SupportedLanguages _language;

        public CodeEntry()
        {
            Id = Guid.NewGuid();
            // Locators = new List<ILocatorDefinition>();
            Locators = new List<LocatorDefinition>();
        }

        //[JsonConstructor]
        //public CodeEntry(IEnumerable<ILocatorDefinition> locatorDefinitions) : this()
        //{
            
        //}

        // public string GenerateCodeForEntry()
        public string GenerateCodeForEntry(SupportedLanguages language)
        {
            var result = string.Empty;

            // TODO: for the future use
            _language = language;

            FilterOutWrongLocators();

            // TODO: temporarily
            // GenerateEntryTitle();

            result = GenerateCodeEntryWithBestLocator();

            return result;
        }

        void GenerateEntryTitle()
        {
            // TODO: make real calculation
            MemberType = string.Format("{0}", typeof(IElement).Name);
            var memberTypeWithoutInterface = MemberType.Substring(1);
            MemberName = string.Format("{0}Suffix", memberTypeWithoutInterface.Substring(0, 1).ToLower() + memberTypeWithoutInterface.Substring(1));
        }

        void FilterOutWrongLocators()
        {
            // TODO: test with Selenium
            Locators.ForEach(locator =>
            {
                // if () outside the screen
            });
        }

        string GenerateCodeEntryWithBestLocator()
        {
            if (!Locators.Any())
                return string.Empty;

            // TODO: temporarily!!!!
            //            var locator = Locators.First();
            //            return string.Format(@"
            //@{0}({1}=""{2}"")
            //public {3} {4}
            //",
            //                locator.Attribute,
            //                locator.searchTypePreference,
            //                locator.SearchString,
            //                // MemberType.GetType().Name,
            //                MemberType,
            //                MemberName);

            var result = string.Empty;
            // var result = "\r";
            Locators.ForEach(locator =>
            {
                //if (!string.IsNullOrEmpty(result))
                //    result += "\r\n";
                result += string.Format("\r\n@{0}({1}=\"{2}\")", locator.Attribute, locator.SearchTypePreference, locator.SearchString);
            } );
            var overallResult = string.IsNullOrEmpty(result) ? result : result + string.Format("\r\npublic {0} {1}",
                MemberType,
                MemberName);


            if (Locators.Any(locator => locator.SearchTypePreference == SearchTypePreferences.xpath))
            {
                var xpath =
                    Locators.Where(locator => locator.SearchTypePreference == SearchTypePreferences.xpath)
                        .Select(locator => locator.SearchString).First();
                //if (!xpath.ToLower().Contains("body"))
                //    Console.WriteLine(
                //        "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< There is no BODY >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }

            return overallResult;
        }
    }
}