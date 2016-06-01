namespace JdiCodeGenerator.Core.Helpers
{
    using System;
    using System.Linq;
    using Core;
    using Epam.JDI.Core.Interfaces.Common;
    using Epam.JDI.Core.Interfaces.Complex;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;

    public class ElementToMemberConvertor
    {
        ICodeEntry _codeEntry;

        [Obsolete("This was applicable only to the initial version")]
        public string Convert(HtmlNode node) // where T : IElement
        {
            Type resultType;
            var classString = GetClassString(node);
            switch (GetExactClass(classString))
            {
                case "btn":
                    return GenerateCodeString(typeof(IButton), classString);
                case "radio":
                    // case "radio-inline":
                    return GenerateCodeString(typeof(IRadioButtons), classString);
                case "checkbox":
                    // case "checkbox-inline":
                    return GenerateCodeString(typeof(ICheckBox), classString);
                default:
                    return string.Empty;
            }
        }

        string GenerateCodeString(Type type, string classString)
        {
            var memberName = type.Name + PrepareClassStringToBeMemberName(classString);
            return string.Format(
                @"
@FindBy(css = '{0}')
public {1} {2};
", classString, type.Name, memberName);
        }

        string PrepareClassStringToBeMemberName(string classString)
        {
            if (string.IsNullOrEmpty(classString))
                return new Random().Next().ToString();
            classString = classString.Replace(" ", string.Empty);
            classString = classString.Replace(".", string.Empty);
            classString = classString.Replace("-", string.Empty);
            return classString;
        }

        string GetClassString(HtmlNode node)
        {
            if (!node.HasAttributes)
                return string.Empty;
            return !node.HasAttribute(WebNames.AttributeNameClass) ? string.Empty : node.GetAttributeValue(WebNames.AttributeNameClass);
        }

        string GetExactClass(string classString)
        {
            if (classString.Contains("btn"))
                return "btn";
            if (classString.Contains("radio"))
                return "radio";
            if (classString.Contains("checkbox"))
                return "checkbox";
            return string.Empty;
        }

        public ICodeEntry ConvertToCodeEntry(HtmlNode node)
        {
            _codeEntry = new CodeEntry();

            _codeEntry.HtmlMemberType = ConvertHtmlElementTypeToInternalMemberType(node.Name);
            CreateIdLocator(node);
            CreateNameLocator(node);
            CreateClassLocator(node);
            CreateTagLocator(node);
            CreateLinkTextLocator(node);
            CreateCssLocator(node);
            CreateXpathLocator(node);

            // temporarily!
            _codeEntry.Type = GetOriginalNameOfElement(node);

            return _codeEntry;
        }

        void CreateClassLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, WebNames.AttributeNameClass, SearchTypes.className);
        }

        void CreateTagLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, WebNames.AttributeNameTag, SearchTypes.tagName);
        }

        void CreateIdLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, WebNames.AttributeNameId, SearchTypes.id);
        }

        void CreateNameLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, WebNames.AttributeNameName, SearchTypes.name);
        }

        void CreateLinkTextLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, WebNames.AttributeNameHref, SearchTypes.linkText);
        }

        void CreateDomLocatorByAttribute(HtmlNode node, string attributeName, SearchTypes searchType)
        {
            if (!node.Attributes.Contains(attributeName))
                return;
            var attributeValue = node.Attributes[attributeName].Value;
            _codeEntry.Locators.Add(new LocatorDef
            {
                Attribute = FindTypes.FindBy,
                SearchType = searchType,
                SearchString = attributeValue
            });
        }

        void CreateCssLocator(HtmlNode node)
        {
            var searchString = GenerateElementCss(node);
            if (string.IsNullOrEmpty(searchString))
                return;
            _codeEntry.Locators.Add(new LocatorDef
            {
                Attribute = FindTypes.FindBy,
                SearchType = SearchTypes.css,
                SearchString = searchString
            });
        }

        void CreateXpathLocator(HtmlNode node)
        {
            var searchString = GenerateElementXpath(node);
            _codeEntry.Locators.Add(new LocatorDef
            {
                Attribute = FindTypes.FindBy,
                SearchType = SearchTypes.xpath,
                SearchString = searchString
            });
        }

        string GenerateElementCss(HtmlNode node)
        {
            var originalName = GetOriginalNameOfElement(node);

            if (new[]
            {
                WebNames.ElementTypeHtml,
                WebNames.ElementTypeHead,
                WebNames.ElementTypeBody,
                "#comment",
                "#text"
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

        string GenerateElementXpath(HtmlNode node)
        {
            var originalName = GetOriginalNameOfElement(node);
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

        string GetOriginalNameOfElement(HtmlNode node)
        {
            return !string.IsNullOrEmpty(node.OriginalName) ? node.OriginalName : "*";
        }

        bool NodeIsAppropriateForXpathBuilding(HtmlNode node)
        {
            if (null == node)
                return false;
            if (HtmlNodeType.Comment == node.NodeType || HtmlNodeType.Document == node.NodeType ||
                HtmlNodeType.Text == node.NodeType)
                return false;
            return true;
        }

        ElementTypes ConvertHtmlElementTypeToInternalMemberType(string elementType)
        {
            switch (elementType.ToLower())
            {
                case "button":
                    return ElementTypes.Button;
                case "input":
                    return ElementTypes.Input;
                default:
                    return ElementTypes.Unknown;
            }
        }
    }
}