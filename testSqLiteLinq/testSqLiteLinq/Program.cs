/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/17/2014
 * Time: 8:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.Linq;
using System.Data.SQLite;

namespace testSqLiteLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            var connection = new SQLiteConnection(@"Data Source=E:\SQLite\db01.s3db");
            connection.Open();
            var context = new DataContext(connection);
            // context.CreateDatabase();
            // context.ExecuteCommand("create table aaa (col1 int, col2 varchar(255));");
            // Console.WriteLine("is database exists? {0}", context.DatabaseExists());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}