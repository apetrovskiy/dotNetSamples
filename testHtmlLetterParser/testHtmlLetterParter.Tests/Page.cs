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
                        <td>a</td><td>b</td>
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
                        <td>Col1</td><td>Col2</td>
                    </tr>
                    <tr>
                        <td>a</td><td>b</td>
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
                        <td>a</td><td>b</td>
                    </tr>
                </table>
            </body>
        </html>
        ";
    }
}

