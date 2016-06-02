namespace JdiCodeGenerator.Core.ObjectModel.Abstract
{
    using System;
    using System.Collections.Generic;

    public interface ICodeEntry
    {
        Guid Id { get; set; }
        // List<ILocatorDefinition> Locators { get; set; }
        List<LocatorDefinition> Locators { get; set; }
        string MemberName { get; set; }
        ElementTypes HtmlMemberType { get; set; }
        string MemberType { get; set; }
        string GenerateCodeForEntry(SupportedLanguages language);

        // temporarily!
        string Type { get; set; }
    }
}