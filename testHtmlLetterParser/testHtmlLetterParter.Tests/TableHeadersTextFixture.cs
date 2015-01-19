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
            var tableProcessor = new TableProcessor (doc.DocumentNode, "//table");
            Assert.AreEqual (2, tableProcessor.ColumnHeaders.Count ());
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual ("Col1", tableProcessor.ColumnHeaderNames.First ());
            Assert.AreEqual ("Col2", tableProcessor.ColumnHeaderNames.Last ());
        }

        [Test]
        public void HeadersFromFirstRow()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithTdNodesAsHeaders);
            var tableProcessor = new TableProcessor (doc.DocumentNode, "//table");
            Assert.AreEqual (2, tableProcessor.ColumnHeaders.Count ());
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
            Assert.AreEqual ("Col1", tableProcessor.ColumnHeaderNames.First ());
            Assert.AreEqual ("Col2", tableProcessor.ColumnHeaderNames.Last ());
        }

        [Test]
        public void GeneratedHeaders()
        {
            var doc = GIVEN_HtmlDocument (Page.TableWithoutHeaders);
            var tableProcessor = new TableProcessor (doc.DocumentNode, "//table", "", ".");
            Assert.AreEqual (2, tableProcessor.ColumnHeaderNames.Count ());
        }

        [Test]
        public void HeadersNumberFromColumnsNumber()
        {

        }

        HtmlDocument GIVEN_HtmlDocument(string htmlDocument)
        {
            var document = new HtmlDocument ();
            document.LoadHtml (htmlDocument);
            return document;
        }
    }
}

