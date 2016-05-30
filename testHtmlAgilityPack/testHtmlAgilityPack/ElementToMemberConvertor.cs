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

    public class ElementToMemberConvertor
    {
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
    }
}