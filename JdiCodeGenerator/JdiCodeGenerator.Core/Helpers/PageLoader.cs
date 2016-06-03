namespace JdiCodeGenerator.Core.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
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
            return GetCodeEntries(_docNode, excludeList);
        }

        IEnumerable<ICodeEntry> GetCodeEntries(HtmlNode docNode, IEnumerable<string> excludeList)
        {
            var convertor = new HtmlElementToCodeEntryConvertor();
            return docNode.Descendants()
                .Select(node => convertor.ConvertToCodeEntry(node))
                .Where(codeEntry => !excludeList.Contains(codeEntry.Type))
                .SetBestChoice()
                .SetNames();
        }
    }
}