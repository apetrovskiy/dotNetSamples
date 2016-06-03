namespace JdiCodeGenerator.Core.ObjectModel.Abstract
{
    using HtmlAgilityPack;

    public interface IFrameworkAlingmentAnalysisPlugin
    {
        JdiElementTypes Analyze(HtmlNode node);
    }
}