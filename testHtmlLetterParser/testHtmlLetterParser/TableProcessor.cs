
namespace testHtmlLetterParser
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using HtmlAgilityPack;

    public class TableProcessor
    {
        readonly HtmlNode _tableNode;
        readonly bool _useFirstRowAsHeaders;
        readonly string _customColumnHeaderExpression;
        readonly string _customRowsExpression;
        // readonly string _customRowItemsExpression;

        public TableProcessor (HtmlNode tableNode)
        {
            _tableNode = tableNode;
            if (_tableNode.Descendants ().Any (descNode => descNode.OriginalName == "th"))
                _useFirstRowAsHeaders = false;
            else
                _useFirstRowAsHeaders = true;
        }

        public TableProcessor(HtmlNode tableNode, string columnHeadersExpression, string rowsExpression, string rowItemsExpression) : this(tableNode)
        {
            _customColumnHeaderExpression = columnHeadersExpression;
            _customRowsExpression = rowsExpression;
            // _customRowItemsExpression = rowItemsExpression;
        }

        public IEnumerable<HtmlNode> ColumnHeaders { get; set; }
        public IEnumerable<HtmlNode> Rows { get; set; }
        
        public void Process()
        {
            ColumnHeaders = getColumnHeaders();
            Rows = getRows ();
        }

        public void ExportCsv(string path)
        {
            using (var writer = new StreamWriter (path)) {
                writeColumnHeaders (writer);
                writeRows (writer);
                writer.Flush ();
                writer.Close ();
            }
        }

        IEnumerable<HtmlNode> getColumnHeaders()
        {
            if (!string.IsNullOrEmpty (_customColumnHeaderExpression))
                return _tableNode.SelectNodes (_customColumnHeaderExpression);
            return _useFirstRowAsHeaders ? getColumnHeadersAsFirstRow() : getColumnHeadersAsElementsTh();
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsElementsTh()
        {
            // this works
            // return _tableNode.Descendants().Where(node => node.OriginalName == "th"); // ??
            return _tableNode.SelectNodes(".//th"); // ??
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsFirstRow()
        {
            return _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
        }

        IEnumerable<HtmlNode> getRows()
        {
            if (!string.IsNullOrEmpty (_customRowsExpression))
                return _tableNode.SelectNodes (_customRowsExpression);
            return _useFirstRowAsHeaders ? getAllRowsButFirst() : getAllRows();
        }

        IEnumerable<HtmlNode> getAllRows()
        {
            // return _tableNode.Descendants ().Where (node => node.OriginalName == "tr");
            return _tableNode.SelectNodes (".//tr");
        }

        IEnumerable<HtmlNode> getAllRowsButFirst()
        {
            // return _tableNode.Descendants ().Where (node => node.OriginalName == "tr").Skip(1);
            return _tableNode.SelectNodes (".//tr").Skip (1);
        }

        void writeColumnHeaders (StreamWriter writer)
        {
            var headerItems = string.Empty;
            ColumnHeaders.ToList ().ForEach (node =>  {
                headerItems += node.InnerText.Trim ();
                headerItems += ",";
            });
            writer.WriteLine (headerItems);
        }

        void writeRows (StreamWriter writer)
        {
            Rows.ToList ().ForEach (node =>  {
                string rowItems = string.Empty;
                // this works
                // node.SelectNodes (".//td").ToList ().ForEach (tdNode =>  {
                node.Descendants().Where(childNode => childNode.OriginalName == "td").ToList ().ForEach (tdNode =>  {
                    rowItems += tdNode.InnerText.Trim ();
                    // rowItems += tdNode.SelectNodes("./text()").First().InnerText;
                    rowItems += ",";
                });
                writer.WriteLine (rowItems);
            });
        }
    }
}

