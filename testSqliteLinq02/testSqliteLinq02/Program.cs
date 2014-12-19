
namespace testSqliteLinq02
{
    using System;
    using System.Data.Linq;
    using System.Data.SQLite;

    class MainClass
    {
        public static void Main (string[] args)
        {
            var connection = new SQLiteConnection ("/home/alexander/db02.sqlite");
            connection.Open ();
            // var context = new DataContext (connection);
            // var aaa = context.DatabaseExists ();
            var cmd = connection.CreateCommand ();
            cmd.CommandText = "select * from test01";
            var reader = cmd.ExecuteReader ();
            reader.Close ();
            reader = null;
            cmd.Dispose ();
            connection.Close ();
            connection = null;

            Console.WriteLine ("=====");

            /*
            string connectionString = "URI=file:SqliteTest.db";
            IDbConnection dbcon;
            dbcon = (IDbConnection) new SqliteConnection(connectionString);
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            // requires a table to be created named employee
            // with columns firstname and lastname
            // such as,
            //        CREATE TABLE employee (
            //           firstname varchar(32),
            //           lastname varchar(32));
            string sql =
                "SELECT firstname, lastname " +
                "FROM employee";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            while(reader.Read()) {
                string FirstName = reader.GetString (0);
                string LastName = reader.GetString (1);
                Console.WriteLine("Name: " +
                    FirstName + " " + LastName);
            }
            // clean up
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;
            */
            Console.ReadKey ();
        }
    }
}
