namespace testHtmlAgilityPack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Epam.JDI.Core.Interfaces.Base;
    using Epam.JDI.Core.Interfaces.Common;
    using Epam.JDI.Core.Interfaces.Complex;
    using HtmlAgilityPack;
    using ObjectModel;
    using ObjectModel.Abstract;

    public class ElementToMemberConvertor
    {
        ICodeEntry _codeEntry;

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

        //T GetButton<T>(HtmlNode node) where T : IElement
        //{

        //}

        string GetClassString(HtmlNode node)
        {
            const string classAttributeName = "class";
            if (!node.Attributes.Any())
                return string.Empty;
            return node.Attributes.All(attribute => attribute.Name != classAttributeName) ? string.Empty : node.Attributes.FirstOrDefault(attribute => attribute.Name == classAttributeName).Value;
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
            CreateCssLocaltor(node);
            CreateXpathLocaltor(node);

            return _codeEntry;
        }

        void CreateCssLocaltor(HtmlNode node)
        {
            
        }

        void CreateClassLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, "class", SearchTypes.className);
        }

        void CreateTagLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, "tag", SearchTypes.tagName);
        }

        void CreateIdLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, "id", SearchTypes.id);
        }

        void CreateNameLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, "name", SearchTypes.name);
        }

        void CreateLinkTextLocator(HtmlNode node)
        {
            CreateDomLocatorByAttribute(node, "href", SearchTypes.linkText);
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

        void CreateXpathLocaltor(HtmlNode node)
        {
            
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