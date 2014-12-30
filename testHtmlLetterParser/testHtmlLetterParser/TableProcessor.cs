
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
        bool _useFirstRowAsHeaders;
        
        public TableProcessor (HtmlNode tableNode)
        {
            _tableNode = tableNode;

            Console.WriteLine (_tableNode.Id);
            Console.WriteLine (_tableNode.Name);
            Console.WriteLine ("tables number = {0}", _tableNode.SelectNodes ("//table[@id='ChangesTable']").Count ());
            var table = _tableNode.SelectNodes ("//table[@id='ChangesTable']").First();
            // Console.WriteLine (table.SelectNodes ("//table[@id='ChangesTable']/tr").Count ());
            Console.WriteLine ("rows number = {0}", table.SelectNodes ("./tr").Count ());
            foreach (var rowNode in table.SelectNodes ("./tr")) {
                Console.WriteLine ("columns number = {0}", rowNode.SelectNodes ("./td").Count ());
                rowNode.SelectNodes ("./td").ToList ().ForEach (node => Console.WriteLine (node.InnerText));

                Console.ReadKey ();
            }
        }
        
        public TableProcessor (HtmlNode tableNode, bool useFirstRowAsHeaders) : this(tableNode)
        {
            _useFirstRowAsHeaders = useFirstRowAsHeaders;
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

                var headerItems = string.Empty;
                ColumnHeaders.ToList ().ForEach (node => {
                    headerItems += node.InnerText.Trim();
                    headerItems += ",";
                });
                writer.WriteLine (headerItems);

                Console.WriteLine ("rows.count = {0}", Rows.Count ());

                Rows.ToList ().ForEach (node => {
                    string rowItems = string.Empty;
                    node.SelectNodes ("//self::tr/descendant::td").ToList ().ForEach (tdNode => {
                        rowItems += tdNode.InnerText.Trim ();
                        rowItems += ",";
                    });
                    writer.WriteLine(rowItems);
                });
                writer.Flush ();
                writer.Close ();
            }
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

