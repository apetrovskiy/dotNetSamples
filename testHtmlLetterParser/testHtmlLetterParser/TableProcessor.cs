
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
        readonly string _customColumnHeaderExpression = "./text()";
        // readonly string _customRowsExpression;
        readonly string _customRowItemsExpression = "./text()";
        
        public TableProcessor (HtmlNode tableNode)
        {
            _tableNode = tableNode;
            _useFirstRowAsHeaders = _tableNode.Descendants().All(descNode => descNode.OriginalName != "th");
        }
        
        public TableProcessor (HtmlNode documentNode, string tableExpression) : this(getTableFromDocument(documentNode, tableExpression))
        {
        }
        
        // public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowsExpression, string rowItemsExpression) : this(documentNode, tableExpression)
        public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowItemsExpression) : this(documentNode, tableExpression)
        {
            _customColumnHeaderExpression = columnHeadersExpression;
            // _customRowsExpression = rowsExpression;
            _customRowItemsExpression = rowItemsExpression;
        }
        
        // public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowsExpression, string rowItemsExpression, params string[] columnNames)
        //    : this(documentNode, tableExpression, columnHeadersExpression, rowsExpression, rowItemsExpression)
        public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowItemsExpression, params string[] columnNames)
            : this(documentNode, tableExpression, columnHeadersExpression, rowItemsExpression)
        {
            if (null == columnNames || 0 == columnNames.Length) return;
            var existingColumnNames = getColumnHeaderNames();
            if (columnNames.Any(columnName => !existingColumnNames.Contains(columnName))) throw new Exception("This is not the table you need");
        }
        
        public IEnumerable<HtmlNode> ColumnHeaders { get; set; }
        public IEnumerable<string> ColumnHeaderNames { get; set; }
        public IEnumerable<HtmlNode> Rows { get; set; }
        
        public void Process()
        {
            ColumnHeaders = getColumnHeaders();
            ColumnHeaderNames = getColumnHeaderNames();
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
        
        public IEnumerable<Dictionary<string, string>> GetCollection()
        {
            var resultList = new List<Dictionary<string, string>> ();
            
            Rows.ToList ().ForEach (rowNode => {
                var dict = new Dictionary<string, string>();
                int counter = 0;
                var tdNodes = rowNode.SelectNodes(".//td");
                if (null != tdNodes && ColumnHeaders.Count() == tdNodes.Count) {
                    ColumnHeaders.Select(headerNode => headerNode.SelectNodes(_customColumnHeaderExpression).FirstOrDefault().InnerText.Trim()).ToList().ForEach(headerName => {
                        dict.Add(headerName, tdNodes[counter].SelectNodes(_customRowItemsExpression).FirstOrDefault().InnerText.Trim());
                        counter++;
                    });
                    resultList.Add(dict);
                }
            });
            
            return resultList;
        }
        
        static HtmlNode getTableFromDocument(HtmlNode documentNode, string tableExpression)
        {
            var tableCollection = documentNode.SelectNodes(tableExpression);
//            if (null == tableCollection) //throw new Exception("Could not find the table of your interest by expression " + tableExpression);
//                return new HtmlNode(HtmlNodeType.Element, documentNode, 0);
            return null == tableCollection ? new HtmlNode(HtmlNodeType.Element, documentNode.OwnerDocument, 0) : tableCollection.First();
        }
        
        IEnumerable<HtmlNode> getColumnHeaders()
        {
            return _useFirstRowAsHeaders ? getColumnHeadersAsFirstRow() : getColumnHeadersAsElementsTh();
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsElementsTh()
        {
            return _tableNode.SelectNodes(".//th"); // ??
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsFirstRow()
        {
            var rowNodes = _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr");
            var columnNodes = rowNodes.Descendants().Where(node => node.OriginalName == "td");
            
            var columnNames = columnNodes.SelectMany(node => node.InnerText.Trim());
            
            return _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
        }
        
        IEnumerable<string> getColumnHeaderNames()
        {
            return _useFirstRowAsHeaders ? 
                getColumnHeadersAsFirstRow().Select(columnNode => columnNode.SelectNodes(_customColumnHeaderExpression).FirstOrDefault().InnerText.Trim()) :
                getColumnHeadersAsElementsTh().Select(columnNode => columnNode.InnerText);
        }
        
        IEnumerable<HtmlNode> getRows()
        {
            return _useFirstRowAsHeaders ? getAllRowsButFirst() : getAllRows();
        }
        
        IEnumerable<HtmlNode> getAllRows()
        {
            return _tableNode.SelectNodes (".//tr");
        }
        
        IEnumerable<HtmlNode> getAllRowsButFirst()
        {
            return _tableNode.SelectNodes (".//tr").Skip (1);
        }
        
        void writeColumnHeaders (TextWriter writer)
        {
            var headerItems = string.Empty;
            ColumnHeaders.ToList ().ForEach (node =>  {
                headerItems += "\"";
                headerItems += node.SelectNodes(_customColumnHeaderExpression).FirstOrDefault().InnerText.Trim ();
                headerItems += "\",";
            });
            writer.WriteLine (headerItems);
        }
        
        void writeRows (TextWriter writer)
        {
            Rows.ToList ().ForEach (node =>  {
                string rowItems = string.Empty;
                node.SelectNodes (".//td").ToList ().ForEach (tdNode =>  rowItems += getNodeData(tdNode));
                if (!string.IsNullOrEmpty(rowItems))
                    writer.WriteLine (rowItems);
            });
        }
        
        string getNodeData(HtmlNode tdNode)
        {
            if (null == tdNode.SelectNodes (_customRowItemsExpression))
                return string.Empty;
            var tdData = tdNode.SelectNodes (_customRowItemsExpression).FirstOrDefault ().InnerText.Trim ();
            return "\"" + tdData + "\",";
        }
    }
}
