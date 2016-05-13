
namespace HtmlConverter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using HtmlAgilityPack;

    public class TableProcessor
    {
        readonly HtmlNode _tableNode;
        const string CustomColumnHeaderExpression = "./text()";
        const string CustomRowItemsExpression = "./td"; // |./text()";
        readonly bool _thElementsPresented;
        
        public TableProcessor(HtmlNode tableNode) : this(tableNode, true)
        {
        }
        
        public TableProcessor (HtmlNode tableNode, bool useFirstRowAsColumnHeaders)
        {
            if (!tableNode.Descendants().Any()) throw new Exception("There are no table or no descendants in the table");
            
            _tableNode = tableNode;
            ColumnHeaderExpression = CustomColumnHeaderExpression;
            RowItemExpression = CustomRowItemsExpression;
            UseFirstRowAsColumnHeaders = useFirstRowAsColumnHeaders;
            _thElementsPresented = _tableNode.Descendants().Any(descNode => descNode.OriginalName == "th");
            
            ProcessTable();
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
        
        void ProcessTable()
        {
            Rows = GetRows();
            ColumnHeaders = GetColumnHeaders();
            ColumnHeaderNames = GetColumnHeaderNames();
        }
        
        public void ExportCsv(string path)
        {
            using (var writer = new StreamWriter (path)) {
                WriteColumnHeaders (writer);
                WriteRows (writer);
                writer.Flush ();
                writer.Close ();
            }
        }
        
        public IEnumerable<Dictionary<string, string>> GetCollection()
        {
            var resultList = new List<Dictionary<string, string>> ();

            // 20160405
            if (null == Rows || !Rows.Any())
                return resultList;

            Rows.ToList ().ForEach (rowNode => {
                var dict = GetDictionaryOfTdNodes(rowNode);
                if (0 < dict.Count) resultList.Add(dict);
            });
            
            return resultList;
        }
        
//        public bool Exists(string action, string objectType, string what, string where, string who) // , string workstation) // DateTime when,
//        {
//            var changes = GetCollection();
//            var changesArray = changes as Dictionary<string, string>[] ?? changes.ToArray();
//            if (null == changes || !changesArray.Any()) return false;
//            return changesArray.Any(change =>
//                               CompareStringData(change, "Action", action) &&
//                               CompareStringData(change, "Object Type", objectType) &&
//                               /*
//                               CompareStringData(change, "What Changed", what) &&
//                               CompareStringData(change, "Where Changed", where) &&
//                               CompareStringData(change, "Who Changed", who)
//                               */
//                               CompareStringData(change, "What", what) &&
//                               CompareStringData(change, "Where", where) &&
//                               CompareStringData(change, "Who", who)
//                              );
//        }
        
        public bool Exists(string action, string objectType, string what, string where, string who, string workstation) // DateTime when,
        {
            var changes = GetCollection();
            var changesArray = changes as Dictionary<string, string>[] ?? changes.ToArray();
            if (null == changes || !changesArray.Any()) return false;
            return changesArray.Any(change =>
                               CompareStringData(change, "Action", action) &&
                               CompareStringData(change, "Object Type", objectType) &&
                               /*
                               CompareStringData(change, "What Changed", what) &&
                               CompareStringData(change, "Where Changed", where) &&
                               CompareStringData(change, "Who Changed", who)
                               */
                               CompareStringData(change, "What", what) &&
                               CompareStringData(change, "Where", where) &&
                               CompareStringData(change, "Who", who) &&
                               CompareStringData(change, "Workstation", workstation)
                              );
        }
        
        public bool Exists(string hostname, string username)
        {
            var changes = GetCollection();
            var changesArray = changes as Dictionary<string, string>[] ?? changes.ToArray();
            if (null == changes || !changesArray.Any()) return false;
            return changesArray.Any(change =>
                               CompareStringData(change, "Computer", hostname) &&
                               CompareStringData(change, "User", username)
                              );
        }
        
        public bool Exists(int columnNumber, string data)
        {
            var changes = GetCollection();
            var changesArray = changes as Dictionary<string, string>[] ?? changes.ToArray();
            if (null == changes || !changesArray.Any()) return false;
            return changesArray.Any(change => data == change[columnNumber.ToString()]);
        }
        
        bool CompareStringData(IDictionary<string, string> change, string key, string value)
        {
            // 20150402
            // TODO: experimental
            if (!change.Keys.Contains(key))
                return true;
            
            var existingKey = change.Keys.First(k => 0 == string.Compare(k, key, StringComparison.OrdinalIgnoreCase));
            return !string.IsNullOrEmpty(existingKey) && change.Values.Any(v => 0 == string.Compare(v, value, StringComparison.OrdinalIgnoreCase));
        }
        
        Dictionary<string, string> GetDictionaryOfTdNodes(HtmlNode rowNode)
        {
            var dict = new Dictionary<string, string>();
            int counter = 0;
            var tdNodes = rowNode.SelectNodes(".//td");
            if (null != tdNodes && ColumnHeaders.Count() == tdNodes.Count) {
                ColumnHeaderNames.ToList().ForEach(headerName => {
                    dict.Add(headerName, SelectRowItemNode(tdNodes[counter]));
                    counter++;
                });
                return dict;
            }
            
            if (null != tdNodes && !ColumnHeaders.Any()) {
                int columnCode = 0;
                tdNodes.ToList().ForEach(tdNode => {
                                             dict.Add(columnCode++.ToString(), SelectRowItemNode(tdNodes[counter]));
                                             counter++;
                                         });
                
                return dict;
            }
            return dict;
        }
        
        string SelectRowItemNode(HtmlNode tdNode)
        {
            // 20160405
            // return tdNode.SelectNodes(RowItemExpression).FirstOrDefault().InnerText.Trim();
            var collection = tdNode.SelectNodes(RowItemExpression);
            return null == collection ? string.Empty : collection.FirstOrDefault().InnerText.Trim();
        }
        
        IEnumerable<HtmlNode> GetColumnHeaders()
        {
            return _thElementsPresented ? GetColumnHeadersAsElementsTh() : (UseFirstRowAsColumnHeaders ? GetColumnHeadersAsFirstRow() : GenerateColumnHeaders());
        }
        
        IEnumerable<HtmlNode> GenerateColumnHeaders()
        {
            var headersList = new List<HtmlNode>();
            var numberOfColumns = Rows.Max(row => row.SelectNodes(RowItemExpression).Count());
            for (int i = 0; i < numberOfColumns; i++)
                headersList.Add(new HtmlNode(HtmlNodeType.Element, _tableNode.OwnerDocument, i + 1) {
                    Name = "tr",
                    InnerHtml = (i + 1).ToString()
                });
            return headersList;
        }
        
        IEnumerable<HtmlNode> GetColumnHeadersAsElementsTh()
        {
            return _tableNode.SelectNodes(".//th"); // ??
        }
        
        IEnumerable<HtmlNode> GetColumnHeadersAsFirstRow()
        {
            // 20150703
            // return _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
            var theFirstRow = _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr");
            return null == theFirstRow ? 
                _tableNode.Descendants().Where(node => node.OriginalName == "td") :
                _tableNode.Descendants().FirstOrDefault(node => node.OriginalName == "tr").Descendants().Where(node => node.OriginalName == "td");
        }
        
        IEnumerable<string> GetColumnHeaderNames()
        {
            if (_thElementsPresented) return GetColumnHeadersAsElementsTh().Select(columnNode => columnNode.InnerText);
            return UseFirstRowAsColumnHeaders ?
                GetColumnHeadersAsFirstRow().Select(columnNode => columnNode.SelectNodes(ColumnHeaderExpression).FirstOrDefault().InnerText.Trim()) :
                ColumnHeaders.Select(columnNode => columnNode.InnerText);
        }
        
        IEnumerable<HtmlNode> GetRows()
        {
            if (_thElementsPresented || !UseFirstRowAsColumnHeaders) return GetAllRows();
            return GetAllRowsButFirst();
        }
        
        IEnumerable<HtmlNode> GetAllRows()
        {
            return _tableNode.SelectNodes (".//tr");
        }
        
        IEnumerable<HtmlNode> GetAllRowsButFirst()
        {
            // 20150703
            // return _tableNode.SelectNodes (".//tr").Skip (1);
            
            
            var rowNodes = _tableNode.SelectNodes (".//tr|.//td/..");
            return rowNodes.Skip(1);
        }
        
        void WriteColumnHeaders (TextWriter writer)
        {
            var headerItems = string.Empty;
            ColumnHeaders.ToList ().ForEach (node =>  {
                headerItems += "\"";
                headerItems += node.SelectNodes(ColumnHeaderExpression).FirstOrDefault().InnerText.Trim ();
                headerItems += "\",";
            });
            writer.WriteLine (headerItems);
        }
        
        void WriteRows (TextWriter writer)
        {
            Rows.ToList ().ForEach (node =>  {
                string rowItems = string.Empty;
                node.SelectNodes (".//td").ToList ().ForEach (tdNode =>  rowItems += GetNodeData(tdNode));
                if (!string.IsNullOrEmpty(rowItems))
                    writer.WriteLine (rowItems);
            });
        }
        
        string GetNodeData(HtmlNode tdNode)
        {
            if (null == tdNode.SelectNodes (RowItemExpression))
                return string.Empty;
            var tdData = tdNode.SelectNodes (RowItemExpression).FirstOrDefault ().InnerText.Trim ();
            return "\"" + tdData + "\",";
        }
    }
}
