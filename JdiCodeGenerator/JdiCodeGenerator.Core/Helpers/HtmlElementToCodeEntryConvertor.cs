namespace JdiCodeGenerator.Core.Helpers
{
    using System.Collections.Generic;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;
    using ObjectModel.Plugins;

    public class HtmlElementToCodeEntryConvertor
    {
        public ICodeEntry ConvertToCodeEntry(HtmlNode node)
        {
            var codeEntry = new CodeEntry { HtmlMemberType = new General().Analyze(node.OriginalName) };

            codeEntry.Locators.AddRange(
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

            // TODO: write the code behind // ??
            codeEntry.JdiMemberType = node.ConvertHtmlTypeToJdiType();

            // temporarily!
            codeEntry.Type = node.GetOriginalNameOfElement();

            // temporarily!
            codeEntry.MemberType = node.GetOriginalNameOfElement();

            return codeEntry;
        }
    }
}