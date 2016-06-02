namespace JdiCodeGenerator.Core.Helpers
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;

    public static class ExtensionMethodsForNodes
    {
        public static bool HasAttribute(this HtmlNode node, string attributeName)
        {
            return node.Attributes.Any(attribute => attribute.Name.ToLower() == attributeName);
        }

        public static string GetAttributeValue(this HtmlNode node, string attributeName)
        {
            return node.Attributes.First(attribute => attribute.Name.ToLower() == attributeName).Value;
        }

        public static string GetOriginalNameOfElement(this HtmlNode node)
        {
            return !String.IsNullOrEmpty(node.OriginalName) ? node.OriginalName : "*";
        }

        // public static ILocatorDefinition CreateDomLocatorByAttribute(this HtmlNode node, string attributeName, SearchTypePreferences searchTypePreference)
        public static LocatorDefinition CreateDomLocatorByAttribute(this HtmlNode node, string attributeName, SearchTypePreferences searchTypePreference)
        {
            if (!node.Attributes.Contains(attributeName))
                return null;
            var attributeValue = node.Attributes[attributeName].Value;
            return new LocatorDefinition
            {
                Attribute = FindTypes.FindBy,
                SearchTypePreference = searchTypePreference,
                SearchString = attributeValue
            };
        }

        // public static ILocatorDefinition CreateCssLocator(this HtmlNode node)
        public static LocatorDefinition CreateCssLocator(this HtmlNode node)
        {
            var searchString = node.GenerateElementCss();
            if (String.IsNullOrEmpty(searchString))
                return null;
            return new LocatorDefinition
            {
                Attribute = FindTypes.FindBy,
                SearchTypePreference = SearchTypePreferences.css,
                SearchString = searchString
            };
        }

        // public static ILocatorDefinition CreateXpathLocator(this HtmlNode node)
        public static LocatorDefinition CreateXpathLocator(this HtmlNode node)
        {
            var searchString = node.GenerateElementXpath();
            return new LocatorDefinition
            {
                Attribute = FindTypes.FindBy,
                SearchTypePreference = SearchTypePreferences.xpath,
                SearchString = searchString
            };
        }

        static string GenerateElementXpath(this HtmlNode node)
        {
            var originalName = node.GetOriginalNameOfElement();
            if (WebNames.ElementTypeBody == originalName)
                return "/";

            var result = !string.IsNullOrEmpty(node.Id)
                ? string.Format(@"/{0}[@id='{1}']", originalName, node.Id)
                : node.HasAttribute(WebNames.AttributeNameName)
                    ? string.Format(@"/{0}[@name='{1}']", originalName, node.GetAttributeValue(WebNames.AttributeNameName))
                    : node.HasAttribute(WebNames.AttributeNameClass) && !node.GetAttributeValue(WebNames.AttributeNameClass).Contains(" ")
                        ? string.Format(@"/{0}[@class='{1}']", originalName, node.GetAttributeValue(WebNames.AttributeNameClass))
                        // experimental
                        : string.Format(@"/{0}", originalName);
            // : string.Empty;
            return NodeIsAppropriateForXpathBuilding(node.ParentNode) ? GenerateElementXpath(node.ParentNode) + result : result;
        }

        static bool NodeIsAppropriateForXpathBuilding(this HtmlNode node)
        {
            if (null == node)
                return false;
            if (HtmlNodeType.Comment == node.NodeType || HtmlNodeType.Document == node.NodeType ||
                HtmlNodeType.Text == node.NodeType)
                return false;
            return true;
        }

        [Obsolete("This was applicable only to the initial version")]
        static string GetClassString(this HtmlNode node)
        {
            if (!node.HasAttributes)
                return string.Empty;
            return !node.HasAttribute(WebNames.AttributeNameClass) ? string.Empty : node.GetAttributeValue(WebNames.AttributeNameClass);
        }
    }
}