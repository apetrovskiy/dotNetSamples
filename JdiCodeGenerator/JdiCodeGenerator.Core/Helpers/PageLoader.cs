namespace JdiCodeGenerator.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Epam.JDI.Commons;
    using HtmlAgilityPack;
    using ObjectModel.Abstract;

    public class PageLoader
    {
        HtmlNode _docNode;

        void LoadPage(string url)
        {
            var web = new HtmlWeb();
            _docNode = web.Load(url).DocumentNode;
        }

        public IEnumerable<ICodeEntry> GetCodeEntries(string url, IEnumerable<string> excludeList)
        {
            LoadPage(url);
            var convertor = new HtmlElementToCodeEntryConvertor();
            return _docNode.Descendants()
                .Select(node => convertor.ConvertToCodeEntry(node))
                .Where(codeEntry => !excludeList.Contains(codeEntry.Type))
                .SetBestChoice()
                .SetNames();
        }
    }
}