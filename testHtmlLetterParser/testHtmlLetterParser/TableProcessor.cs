
namespace testHtmlLetterParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;

    public class TableProcessor
    {
        readonly HtmlNode _tableNode;
        bool _useFirstRowAsHeaders;
        
        public TableProcessor (HtmlNode tableNode)
        {
            _tableNode = tableNode;
        }
        
        public TableProcessor (HtmlNode tableNode, bool useFirstRowAsHeaders) : this(tableNode)
        {
            _useFirstRowAsHeaders = useFirstRowAsHeaders;
        }
        
        public IEnumerable<HtmlNode> ColumnHeaders { get; set; }
        // public HtmlNodeCollection[] Rows { get; set; }
        public IEnumerable<HtmlNode> Rows { get; set; }
        
        public void Process()
        {
            ColumnHeaders = getColumnHeaders();
            Rows = getRows ();
        }

        IEnumerable<HtmlNode> getColumnHeaders()
        {
            return _useFirstRowAsHeaders ? getColumnHeadersAsFirstRow() : getColumnHeadersAsElementsTh();
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsElementsTh()
        {
            return _tableNode.Descendants().Where(node => node.OriginalName == "th"); // ??
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsFirstRow()
        {
            return _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
        }

        IEnumerable<HtmlNode> getRows()
        {
            return _useFirstRowAsHeaders ? getAllRowsButFirst() : getAllRows();
        }

        IEnumerable<HtmlNode> getAllRows()
        {
            return _tableNode.Descendants ().Where (node => node.OriginalName == "tr");
        }

        IEnumerable<HtmlNode> getAllRowsButFirst()
        {
            return _tableNode.Descendants ().Where (node => node.OriginalName == "tr").Skip(1);
        }
    }
}

