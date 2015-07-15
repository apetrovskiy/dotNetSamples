namespace HtmlConverter.Tests
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using NUnit.Framework;
    using Xunit;

    [TestFixture]
    public class TableHeadersTextFixture
    {
        TableProcessor _tableProcessor;
        HtmlDocument _document;
        
        public TableHeadersTextFixture()
        {
            SetUp ();
        }
        
        [SetUp]
        public void SetUp()
        {
            _tableProcessor = null;
            _document = null;
        }
        
        [TearDown]
        public void TearDown()
        {
            _tableProcessor = null;
            _document = null;
        }
        
        [Test][Fact]
        public void HeadersFromThNodes()
        {
            GIVEN_HtmlDocument (Page.TableWithThNodes);
            WHEN_creating_tableProcessor("//table");
            THEN_tableProcessor_is_ready ();
            THEN_there_are_N_columns (2);
            THEN_column_number_N_is (1, "Col1");
            THEN_column_number_N_is (2, "Col2");
            THEN_there_are_N_rows (1);
        }
        
        [Test][Fact]
        public void HeadersFromFirstRow()
        {
            GIVEN_HtmlDocument (Page.TableWithTdNodesAsHeaders);
            WHEN_creating_tableProcessor("//table");
            THEN_tableProcessor_is_ready ();
            THEN_there_are_N_columns (2);
            THEN_column_number_N_is (1, "row1col1");
            THEN_column_number_N_is (2, "row1col2");
            THEN_there_are_N_rows (1);
        }
        
        [Test][Fact]
        public void GeneratedHeaders()
        {
            GIVEN_HtmlDocument (Page.TableWithoutHeaders);
            WHEN_creating_tableProcessor ("//table", false, string.Empty, ".");
            THEN_tableProcessor_is_ready ();
            THEN_there_are_N_columns (2);
            THEN_column_number_N_is (1, "1");
            THEN_column_number_N_is (2, "2");
            THEN_there_are_N_rows (1);
        }
        
        [Test][Fact]
        public void HeadersNumberFromColumnsNumber()
        {
            GIVEN_HtmlDocument (Page.TableWithoutHeadersAndWithVariantNumberOfColumns);
            WHEN_creating_tableProcessor ("//table", false, string.Empty, "./td");
            THEN_tableProcessor_is_ready ();
            THEN_there_are_N_columns (4);
            THEN_column_number_N_is (1, "1");
            THEN_column_number_N_is (2, "2");
            THEN_column_number_N_is (3, "3");
            THEN_column_number_N_is (4, "4");
            THEN_there_are_N_rows (4);
        }
        

        [Test][Fact] // TODO: move it out here
        public void EmptyTable()
        {
            GIVEN_HtmlDocument (Page.TableThatIsEmpty);
            Xunit.Assert.Throws<Exception>(() => WHEN_creating_tableProcessor ("//table", false, string.Empty, "."));
            Xunit.Assert.Null(_tableProcessor);
        }
        
        void GIVEN_HtmlDocument(string htmlDocument)
        {
            _document = new HtmlDocument ();
            _document.LoadHtml (htmlDocument);
        }
        
        void WHEN_creating_tableProcessor(string tableExpression, bool useFirstRowAsHeaders, string columnExpression, string rowItemExpression)
        {
            _tableProcessor = new TableProcessor(_document.DocumentNode.SelectNodes(tableExpression).First(), useFirstRowAsHeaders) { ColumnHeaderExpression = columnExpression, RowItemExpression = rowItemExpression };
        }
        
        void WHEN_creating_tableProcessor(string tableExpression)
        {
            _tableProcessor = new TableProcessor(_document.DocumentNode.SelectNodes(tableExpression).First());
        }
        
        void THEN_tableProcessor_is_ready()
        {
            Xunit.Assert.Equal(true, _tableProcessor.Ready);
        }
        
        void THEN_there_are_N_columns(int columnsNumber)
        {
            Xunit.Assert.Equal(columnsNumber, _tableProcessor.ColumnHeaders.Count ());
            Xunit.Assert.Equal(columnsNumber, _tableProcessor.ColumnHeaderNames.Count ());
        }
        
        void THEN_column_number_N_is(int columnNumber, string columnName)
        {
            Xunit.Assert.Equal(columnName, _tableProcessor.ColumnHeaderNames.Skip(columnNumber - 1).First ());
        }
        
        void THEN_there_are_N_rows(int rowsNumber)
        {
            Xunit.Assert.Equal(rowsNumber, _tableProcessor.Rows.Count());
        }
    }
}