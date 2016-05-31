namespace testHtmlAgilityPack.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Epam.JDI.Core.Interfaces.Base;

    public class CodeEntry : ICodeEntry
    {
        public List<ILocatorDefinition> Locators { get; set; }
        public string MemberName { get; set; }
        public ElementTypes HtmlMemberType { get; set; }
        public string MemberType { get; set; }

        public CodeEntry()
        {
            Locators = new List<ILocatorDefinition>();

            // TODO: make real calculation
            MemberType = string.Format("{0}", typeof(IElement).Name);
            var memberTypeWithoutInterface = MemberType.Substring(1);
            MemberName = string.Format("{0}Suffix", memberTypeWithoutInterface.Substring(0, 1).ToLower() + memberTypeWithoutInterface.Substring(1));

        }
        public string GenerateCodeEntry()
        {
            var result = string.Empty;

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
            //                locator.SearchType,
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
                result += string.Format("\r\n@{0}({1}=\"{2}\")", locator.Attribute, locator.SearchType, locator.SearchString);
            } );
            var overallResult = string.IsNullOrEmpty(result) ? result : result + string.Format("\r\npublic {0} {1}",
                MemberType,
                MemberName);

            return overallResult;
        }
    }
}