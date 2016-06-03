namespace JdiCodeGenerator.Core.Helpers
{
    using System.Linq;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;

    public static class ExtensionMethodsForHtmlElements
    {
        public static string GenerateElementCss(this HtmlNode node)
        {
            var originalName = node.GetOriginalNameOfElement();

            if (new[]
            {
                WebNames.ElementTypeHtml,
                WebNames.ElementTypeHead,
                WebNames.ElementTypeBody,
                WebNames.ElementTypeComment,
                WebNames.ElementTypeText
            }.Contains(originalName))
                return string.Empty;

            var result = string.Empty;

            // [id='createUserId']
            if (!string.IsNullOrEmpty(node.Id))
                result += string.Format(@"[id='{0}']", node.Id);
            // [name='createUser']
            if (node.HasAttribute(WebNames.AttributeNameName))
                result += string.Format(@"[name='{0}']", node.GetAttributeValue(WebNames.AttributeNameName));

            // [title*='Hello beautiful']
            // [title='Hello beautiful']
            if (node.HasAttribute("title"))
                result += string.Format(@"[title='{0}']",
                    node.GetAttributeValue("title"));

            return result;
        }

        public static LocatorDefinition CreateClassLocator(this HtmlNode node)
        {
            return node.CreateDomLocatorByAttribute(WebNames.AttributeNameClass, SearchTypePreferences.className);
        }

        public static LocatorDefinition CreateTagLocator(this HtmlNode node)
        {
            return node.CreateDomLocatorByAttribute(WebNames.AttributeNameTag, SearchTypePreferences.tagName);
        }

        public static LocatorDefinition CreateIdLocator(this HtmlNode node)
        {
            return node.CreateDomLocatorByAttribute(WebNames.AttributeNameId, SearchTypePreferences.id);
        }

        public static LocatorDefinition CreateNameLocator(this HtmlNode node)
        {
            return node.CreateDomLocatorByAttribute(WebNames.AttributeNameName, SearchTypePreferences.name);
        }

        public static LocatorDefinition CreateLinkTextLocator(this HtmlNode node)
        {
            return node.CreateDomLocatorByAttribute(WebNames.AttributeNameHref, SearchTypePreferences.linkText);
        }
    }
}