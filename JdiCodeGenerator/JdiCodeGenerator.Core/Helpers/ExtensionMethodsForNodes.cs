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

        public static JdiElementTypes ConvertHtmlTypeToJdiType(this HtmlNode node)
        {
            // var result = JdiElementTypes.Element;

            // var htmlNodeType = new General().Analyze(node.OriginalName);
            
            // result = node.ApplyGeneralAnalyzer();

            // TODO: switch it on
            return node.ApplyApplicableAnalyzers();

            // return result;
        }

        internal static JdiElementTypes ApplyApplicableAnalyzers(this HtmlNode node)
        {
            var result = JdiElementTypes.Element;

            // TODO: write code here
            // // apply General

            // apply all applicable
            // TODO: use the selection the user provided
            var typesOfAnalyzers = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assm => assm.FullName.Contains("JdiCodeGenerator.Core"))
                .SelectMany(assm => assm.GetTypes())
                .Where(type => type.GetInterfaces().Contains(typeof(IFrameworkAlingmentAnalysisPlugin)));

            typesOfAnalyzers.ToList().ForEach(type =>
            {
                result = (JdiElementTypes)type.GetMethod("Analyze").Invoke(Activator.CreateInstance(type), new object[] { node });

            });

            return result;
        }

        public static string GetOriginalNameOfElement(this HtmlNode node)
        {
            return !string.IsNullOrEmpty(node.OriginalName) ? node.OriginalName : "*";
        }

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
    }
}