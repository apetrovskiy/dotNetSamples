using System;

namespace testHtmlLetterParter.Tests
{
    public class Page
    {
        public const string TableWithThNodes = @"
        <html>
            <body>
                <table>
                    <th>Col1</th><th>Col2</th>
                    <tr>
                        <td>row1col1</td><td>row1col2</td>
                    </tr>
                </table>
            </body>
        </html>
        ";
        
        public const string TableWithTdNodesAsHeaders = @"
        <html>
            <body>
                <table>
                    <tr>
                        <td>row1col1</td><td>row1col2</td>
                    </tr>
                    <tr>
                        <td>row2col1</td><td>row2col2</td>
                    </tr>
                </table>
            </body>
        </html>
        ";
        
        public const string TableWithoutHeaders = @"
        <html>
            <body>
                <table>
                    <tr>
                        <td>row1col1</td><td>row1col2</td>
                    </tr>
                </table>
            </body>
        </html>
        ";
        
        public const string TableWithoutHeadersAndWithVariantNumberOfColumns = @"
        <html>
            <body>
                <table>
                    <tr>
                        <td>row1col1</td><td>row1col2</td>
                    </tr>
                    <tr>
                        <td>row2col1</td><td>row2col2</td><td>row2col3</td>
                    </tr>
                    <tr>
                        <td>row3col1</td><td>row3col2</td><td>row3col3</td><td>row3col4</td>
                    </tr>
                    <tr>
                        <td>row4col1</td><td>row4col2</td>
                    </tr>
                </table>
            </body>
        </html>
        ";
        
        public const string TableThatIsEmpty = @"
        <html>
            <body>
                <table />
            </body>
        </html>
        ";
    }
}

