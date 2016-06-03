namespace JdiCodeGenerator.Core.ObjectModel.Plugins
{
    using System;
    using System.Linq;
    using Abstract;

    public class General // : IFrameworkAlingmentAnalysisPlugin
    {
        // public HtmlElementTypes Analyze(HtmlNode node)
        public HtmlElementTypes Analyze(string originalName)
        {
            var result = HtmlElementTypes.Unknown;

            Enum.GetValues(typeof(HtmlElementTypes))
                .Cast<HtmlElementTypes>()
                .ToList()
                .ForEach(htmlElementType =>
                {
                    // if (null != node.OriginalName && string.CompareOrdinal(htmlElementType.ToString(), node.OriginalName) != 0)
                    if (!string.IsNullOrEmpty(originalName) && string.CompareOrdinal(htmlElementType.ToString().ToLower(), originalName) == 0)
                    {
                        result = htmlElementType;
                        return;
                    }
                });

            return result;
        }
    }
}