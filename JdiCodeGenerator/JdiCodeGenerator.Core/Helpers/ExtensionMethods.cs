namespace JdiCodeGenerator.Core.Helpers
{
    using System.Linq;
    using HtmlAgilityPack;

    public static class ExtensionMethods
    {
        public static bool HasAttribute(this HtmlNode node, string attributeName)
        {
            return node.Attributes.Any(attribute => attribute.Name.ToLower() == attributeName);
        }

        public static string GetAttributeValue(this HtmlNode node, string attributeName)
        {
            return node.Attributes.First(attribute => attribute.Name.ToLower() == attributeName).Value;
        }
    }
}