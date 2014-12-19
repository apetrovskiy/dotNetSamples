
namespace testSqLiteLinq
{
    using System;
    using System.Data.Linq;
    using System.Data.SQLite;

    class MainClass
    {
        public static void Main (string[] args)
        {
            var connection = new SQLiteConnection ("Data Source=~/Downloads/1");
            var context = new DataContext (connection);
            // context.CreateDatabase ();
            Console.WriteLine ("created? {0}", context.DatabaseExists ());

            Console.ReadKey ();
        }
    }
}
