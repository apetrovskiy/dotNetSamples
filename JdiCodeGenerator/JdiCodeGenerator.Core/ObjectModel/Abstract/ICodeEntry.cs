namespace JdiCodeGenerator.Core.ObjectModel.Abstract
{
    using System;
    using System.Collections.Generic;

    public interface ICodeEntry
    {
        Guid Id { get; set; }
        List<LocatorDefinition> Locators { get; set; }
        string MemberName { get; set; }
        HtmlElementTypes HtmlMemberType { get; set; }
        JdiElementTypes JdiMemberType { get; set; }
        string MemberType { get; set; }
        string GenerateCodeForEntry(SupportedLanguages language);

        // temporarily!
        string Type { get; set; }
    }
}