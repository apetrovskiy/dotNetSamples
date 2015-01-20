
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
        const string _customColumnHeaderExpression = "./text()";
        const string _customRowItemsExpression = "./td"; // |./text()";
        readonly bool _thElementsPresented;
        
        public TableProcessor(HtmlNode tableNode) : this(tableNode, true)
        {
        }
        
        public TableProcessor (HtmlNode tableNode, bool useFirstRowAsColumnHeaders)
        {
            if (!tableNode.Descendants().Any()) return; // throw new Exception("There are no table or no descendants in the table");
            
            _tableNode = tableNode;
            ColumnHeaderExpression = _customColumnHeaderExpression;
            RowItemExpression = _customRowItemsExpression;
            UseFirstRowAsColumnHeaders = useFirstRowAsColumnHeaders;
            _thElementsPresented = _tableNode.Descendants().Any(descNode => descNode.OriginalName == "th");
            
            processTable();
            Ready = true;
        }
        
        public bool UseFirstRowAsColumnHeaders { get; set; }
        public string ColumnHeaderExpression { get; set; }
        public string RowItemExpression { get; set; }
        public string[] ColumnNames { get; set; }
        
        public IEnumerable<HtmlNode> ColumnHeaders { get; set; }
        public IEnumerable<string> ColumnHeaderNames { get; set; }
        public IEnumerable<HtmlNode> Rows { get; set; }
        public bool Ready { get; set; }
        
        void processTable()
        {
            Rows = getRows();
            ColumnHeaders = getColumnHeaders();
            ColumnHeaderNames = getColumnHeaderNames();
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
            return tdNode.SelectNodes(RowItemExpression).FirstOrDefault().InnerText.Trim();
        }
        
        static HtmlNode getTableFromDocument(HtmlNode documentNode, string tableExpression)
        {
            var tableCollection = documentNode.SelectNodes(tableExpression);
            return null == tableCollection ? new HtmlNode(HtmlNodeType.Element, documentNode.OwnerDocument, 0) : tableCollection.First();
        }
        
        IEnumerable<HtmlNode> getColumnHeaders()
        {
            return _thElementsPresented ? getColumnHeadersAsElementsTh() : (UseFirstRowAsColumnHeaders ? getColumnHeadersAsFirstRow() : generateColumnHeaders());
        }
        
        IEnumerable<HtmlNode> generateColumnHeaders()
        {
            var headersList = new List<HtmlNode>();
            var numberOfColumns = Rows.Max(row => row.SelectNodes(RowItemExpression).Count());
            for(int i = 0; i < numberOfColumns; i++) {
                headersList.Add(new HtmlNode(HtmlNodeType.Element, _tableNode.OwnerDocument, i + 1) { Name = "tr", InnerHtml = (i + 1).ToString() });
                /*
                var newNode = new HtmlNode(HtmlNodeType.Element, _tableNode.OwnerDocument, i + 1);
                newNode.Name = "tr";
                newNode.InnerHtml = (i + 1).ToString();
                headersList.Add(newNode);
                */
            }
            return headersList;
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsElementsTh()
        {
            return _tableNode.SelectNodes(".//th"); // ??
        }
        
        IEnumerable<HtmlNode> getColumnHeadersAsFirstRow()
        {
            return _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
        }
        
        IEnumerable<string> getColumnHeaderNames()
        {
            if (_thElementsPresented) return getColumnHeadersAsElementsTh().Select(columnNode => columnNode.InnerText);
            return UseFirstRowAsColumnHeaders ?
                getColumnHeadersAsFirstRow().Select(columnNode => columnNode.SelectNodes(ColumnHeaderExpression).FirstOrDefault().InnerText.Trim()) :
                ColumnHeaders.Select(columnNode => columnNode.InnerText);
        }
        
        IEnumerable<HtmlNode> getRows()
        {
            if (_thElementsPresented || !UseFirstRowAsColumnHeaders) return getAllRows();
            return getAllRowsButFirst();
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
                headerItems += node.SelectNodes(ColumnHeaderExpression).FirstOrDefault().InnerText.Trim ();
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
            if (null == tdNode.SelectNodes (RowItemExpression))
                return string.Empty;
            var tdData = tdNode.SelectNodes (RowItemExpression).FirstOrDefault ().InnerText.Trim ();
            return "\"" + tdData + "\",";
        }
    }
}
