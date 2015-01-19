
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
        readonly string _customRowItemsExpression = "./text()";
        readonly bool _noHeaders;
        
        public TableProcessor (HtmlNode tableNode)
        {
            if (!tableNode.Descendants().Any()) return; // throw new Exception("There are no table or no descendants in the table");
            _tableNode = tableNode;
            _useFirstRowAsHeaders = _tableNode.Descendants().All(descNode => descNode.OriginalName != "th");
            // _useFirstRowAsHeaders = _tableNode.Descendants().All(descNode => descNode.OriginalName != "th") && !_noHeaders;
            processTable();
            Ready = true;
        }
        
        public TableProcessor(HtmlNode tableNode, string columnHeadersExpression, string rowItemsExpression) : this(tableNode)
        {
            _noHeaders = string.IsNullOrEmpty(columnHeadersExpression);
            _customColumnHeaderExpression = columnHeadersExpression;
            _customRowItemsExpression = rowItemsExpression;
        }
        
        public TableProcessor (HtmlNode documentNode, string tableExpression) : this(getTableFromDocument(documentNode, tableExpression))
        {
        }
        
        public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowItemsExpression) : this(documentNode, tableExpression)
        {
            // _noHeaders = string.IsNullOrEmpty(columnHeadersExpression);
            // _noHeaders = noHeaders;
            _customColumnHeaderExpression = columnHeadersExpression;
            _customRowItemsExpression = rowItemsExpression;
        }
        
        public TableProcessor(HtmlNode documentNode, string tableExpression, string columnHeadersExpression, string rowItemsExpression, params string[] columnNames)
            : this(documentNode, tableExpression, columnHeadersExpression, rowItemsExpression)
        {
            _noHeaders = string.IsNullOrEmpty(columnHeadersExpression);
            // if (null == columnNames || 0 == columnNames.Length) return;
            if (_noHeaders) return;
            var existingColumnNames = getColumnHeaderNames();
            if (columnNames.Any(columnName => !existingColumnNames.Contains(columnName))) throw new Exception("This is not the table you need");
        }
        
        public IEnumerable<HtmlNode> ColumnHeaders { get; set; }
        public IEnumerable<string> ColumnHeaderNames { get; set; }
        public IEnumerable<HtmlNode> Rows { get; set; }
        public bool Ready { get; set; }
        
        void processTable()
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
                var dict = getDictionaryOfTdNodes(rowNode);
                if (0 < dict.Count) resultList.Add(dict);
            });
            
            return resultList;
        }
        
        public bool Exists(string action, string objectType, string what, string where, string who) // , string workstation) // DateTime when,
        {
            var changes = GetCollection();
            if (null == changes || !changes.Any()) return false;
            return changes.Any(change => 
                               compareStringData(change, "Action", action) &&
                               compareStringData(change, "Object Type", objectType) &&
                               compareStringData(change, "What Changed", what) &&
                               compareStringData(change, "Where Changed", where) &&
                               compareStringData(change, "Who Changed", who)
                              );
        }
        
        public bool Exists(string hostname, string username)
        {
            var changes = GetCollection();
            if (null == changes || !changes.Any()) return false;
            return changes.Any(change => 
                               compareStringData(change, "Computer", hostname) &&
                               compareStringData(change, "User", username)
                              );
        }
        
        bool compareStringData(IDictionary<string, string> change, string key, string value)
        {
            var existingKey = change.Keys.First(k => 0 == string.Compare(k, key, StringComparison.OrdinalIgnoreCase));
            return !string.IsNullOrEmpty(existingKey) && change.Values.Any(v => 0 == string.Compare(v, value, StringComparison.OrdinalIgnoreCase));
        }
        
        Dictionary<string, string> getDictionaryOfTdNodes(HtmlNode rowNode)
        {
            var dict = new Dictionary<string, string>();
            int counter = 0;
            var tdNodes = rowNode.SelectNodes(".//td");
            if (null != tdNodes && ColumnHeaders.Count() == tdNodes.Count) {
                ColumnHeaderNames.ToList().ForEach(headerName => {
                    dict.Add(headerName, selectRowItemNode(tdNodes[counter]));
                    counter++;
                });
                return dict;
            }
            
            if (null != tdNodes && !ColumnHeaders.Any()) {
                int columnCode = 0;
//                ColumnHeaderNames.ToList().ForEach(headerName => {
//                    dict.Add(headerName, selectRowItemNode(tdNodes[counter]));
//                    counter++;
//                });
//                
                tdNodes.ToList().ForEach(tdNode => {
                                             dict.Add(columnCode++.ToString(), selectRowItemNode(tdNodes[counter]));
                                             counter++;
                                         });
                
                return dict;
            }
            return dict;
        }
        
        string selectRowItemNode(HtmlNode tdNode)
        {
            /*
            var rowItemNodes = tdNode.SelectNodes(_customRowItemsExpression);
            var firstNode = tdNode.SelectNodes(_customRowItemsExpression).FirstOrDefault();
            var text = tdNode.SelectNodes(_customRowItemsExpression).FirstOrDefault().InnerText;
            var trimmedText = tdNode.SelectNodes(_customRowItemsExpression).FirstOrDefault().InnerText.Trim();
            */
            return tdNode.SelectNodes(_customRowItemsExpression).FirstOrDefault().InnerText.Trim();
        }
        
        static HtmlNode getTableFromDocument(HtmlNode documentNode, string tableExpression)
        {
            var tableCollection = documentNode.SelectNodes(tableExpression);
            return null == tableCollection ? new HtmlNode(HtmlNodeType.Element, documentNode.OwnerDocument, 0) : tableCollection.First();
        }
        
        IEnumerable<HtmlNode> getColumnHeaders()
        {
            Console.WriteLine (_customColumnHeaderExpression);
            Console.WriteLine (_customRowItemsExpression);

            return _useFirstRowAsHeaders ? getColumnHeadersAsFirstRow() : getColumnHeadersAsElementsTh();
            // return _noHeaders ? generateHeaders() : (_useFirstRowAsHeaders ? getColumnHeadersAsFirstRow() : getColumnHeadersAsElementsTh());
        }

        IEnumerable<HtmlNode> generateHeaders()
        {
            return new List<HtmlNode> ();
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsElementsTh()
        {
            return _tableNode.SelectNodes(".//th"); // ??
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsFirstRow()
        {
//            var rowNodes = _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr");
//            var columnNodes = rowNodes.Descendants().Where(node => node.OriginalName == "td");
//            
//            var columnNames = columnNodes.SelectMany(node => node.InnerText.Trim());
            
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
