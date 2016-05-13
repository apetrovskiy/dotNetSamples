namespace testSqlDataAdapterForOneRow
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "172.28.1.172",
                InitialCatalog = "db01",
                IntegratedSecurity = false,
                UserID = "admin",
                Password = "111"
            };
            var commandText = "select * from dbo.t1";
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(commandText, connection);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                var columnNames = dataSet.Tables[0].Columns.Cast<DataColumn>().ToList().Select(column => column.ColumnName);
                var dataRow = dataSet.Tables[0].Rows[0];
                columnNames.ToList().ForEach(name => Console.WriteLine("{0} {1}", name, dataRow[name]));
            }

            Console.ReadKey();
        }
    }
}
