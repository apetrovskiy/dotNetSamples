namespace JdiCodeGenerator.Core.ObjectModel.Abstract
{
    using HtmlAgilityPack;
    using System.Collections.Generic;

    public interface IFrameworkAlingmentAnalysisPlugin
    {
        JdiElementTypes Analyze(HtmlNode node);
        IEnumerable<IRule> Rules { get; set; }
    }
}