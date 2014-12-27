
namespace testHtmlLetterParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;

    public class TableProcessor
    {
        HtmlNode _tableNode;

        public TableProcessor (HtmlNode tableNode)
        {
            _tableNode = tableNode;
        }

        public IEnumerable<string> Headers { get; set; }
        public HtmlNodeCollection[] Rows { get; set; }

        public void Process()
        {
            var descendants = _tableNode.Descendants ();
            var headers = descendants.Where (node => node.InnerHtml.Contains ("th"));
            var headerNames = headers.Select (headerNode => headerNode.InnerText);

            Headers = _tableNode.Descendants ().Where(node => node.InnerHtml.Contains("th")).ToList().Select (headerNode => headerNode.InnerText);
        }
    }
}

