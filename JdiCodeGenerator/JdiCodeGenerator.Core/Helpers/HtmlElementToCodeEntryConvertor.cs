namespace JdiCodeGenerator.Core.Helpers
{
    using System.Collections.Generic;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;

    public class HtmlElementToCodeEntryConvertor
    {
        public ICodeEntry ConvertToCodeEntry(HtmlNode node)
        {
            var codeEntry = new CodeEntry { HtmlMemberType = node.Name.ConvertHtmlElementTypeToInternalMemberType() };

            codeEntry.Locators.AddRange(
                // new List<ILocatorDefinition>
                new List<LocatorDefinition>
                {
                    node.CreateIdLocator(),
                    node.CreateNameLocator(),
                    node.CreateClassLocator(),
                    node.CreateTagLocator(),
                    node.CreateLinkTextLocator(),
                    node.CreateCssLocator(),
                    node.CreateXpathLocator()
                });
            codeEntry.Locators.RemoveAll(locator => null == locator);

            // temporarily!
            codeEntry.Type = node.GetOriginalNameOfElement();

            // temporarily!
            codeEntry.MemberType = node.GetOriginalNameOfElement();

            return codeEntry;
        }
    }
}