namespace testHtmlAgilityPack.ObjectModel.Abstract
{
    using System;
    using System.Collections.Generic;
    using Epam.JDI.Core.Interfaces.Base;
    using NUnit.Framework;

    public interface ICodeEntry
    {
        List<ILocatorDefinition> Locators { get; set; }
        string MemberName { get; set; }
        ElementTypes HtmlMemberType { get; set; }
        string MemberType { get; set; }
        string GenerateCodeEntry();
    }
}