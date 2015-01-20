using System;
using System.Linq;
using HtmlAgilityPack;
using NUnit.Framework;
using testHtmlLetterParser;

namespace testHtmlLetterParter.Tests
{
    [TestFixture]
    public class TableHeadersTextFixture
    {
        public TableHeadersTextFixture ()
        {
        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void HeadersFromThNodes()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithThNodes);
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First());
            Assert.AreEqual(true, tableProcessor.Ready);
            Assert.AreEqual (2, tableProcessor.ColumnHeaders.Count ());
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual ("Col1", tableProcessor.ColumnHeaderNames.First ());
            Assert.AreEqual ("Col2", tableProcessor.ColumnHeaderNames.Last ());
            Assert.AreEqual(1, tableProcessor.Rows.Count());
            
            Console.WriteLine("======================================= HeadersFromThNodes =======================================");
            foreach(var headerName in tableProcessor.ColumnHeaderNames) {
                Console.WriteLine(headerName);
            }
            Console.WriteLine("===================================================================================================");
        }

        [Test]
        public void HeadersFromFirstRow()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithTdNodesAsHeaders);
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First());
            Assert.AreEqual(true, tableProcessor.Ready);
            Assert.AreEqual (2, tableProcessor.ColumnHeaders.Count ());
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual ("row1col1", tableProcessor.ColumnHeaderNames.First ());
            Assert.AreEqual ("row1col2", tableProcessor.ColumnHeaderNames.Last ());
            Assert.AreEqual(1, tableProcessor.Rows.Count());
            
            Console.WriteLine("======================================= HeadersFromFirstRow =======================================");
            foreach(var headerName in tableProcessor.ColumnHeaderNames) {
                Console.WriteLine(headerName);
            }
            Console.WriteLine("===================================================================================================");
        }

        [Test]
        public void GeneratedHeaders()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithoutHeaders);
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First(), false) { RowItemExpression = "." };
            Assert.AreEqual(true, tableProcessor.Ready);
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual("1", tableProcessor.ColumnHeaderNames.First());
            Assert.AreEqual("2", tableProcessor.ColumnHeaderNames.Last());
            Assert.AreEqual(1, tableProcessor.Rows.Count());
            
            Console.WriteLine("======================================= GeneratedHeaders =======================================");
            foreach(var headerName in tableProcessor.ColumnHeaderNames) {
                Console.WriteLine(headerName);
            }
            Console.WriteLine("===================================================================================================");
        }
        
        [Test]
        public void HeadersNumberFromColumnsNumber()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithoutHeadersAndWithVariantNumberOfColumns);
            // var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First()) { NoColumnHeaders = true, RowItemExpression = "." };
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First(), false) { RowItemExpression = "./td" };
            Assert.AreEqual(true, tableProcessor.Ready);
            Assert.AreEqual (4, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual("1", tableProcessor.ColumnHeaderNames.First());
            Assert.AreEqual("2", tableProcessor.ColumnHeaderNames.Skip(1).First());
            Assert.AreEqual("3", tableProcessor.ColumnHeaderNames.Skip(2).First());
            Assert.AreEqual("4", tableProcessor.ColumnHeaderNames.Last());
            Assert.AreEqual(4, tableProcessor.Rows.Count());
            
            Console.WriteLine("======================================= HeadersNumberFromColumnsNumber =======================================");
            foreach(var headerName in tableProcessor.ColumnHeaderNames) {
                Console.WriteLine(headerName);
            }
            Console.WriteLine("===================================================================================================");
        }
        
        HtmlDocument GIVEN_HtmlDocument(string htmlDocument)
        {
            var document = new HtmlDocument ();
            document.LoadHtml (htmlDocument);
            return document;
        }
    }
}

