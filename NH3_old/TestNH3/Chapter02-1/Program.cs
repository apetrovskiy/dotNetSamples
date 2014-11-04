
namespace TestNH3
{
    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    class MainClass
    {
        public static void Main (string[] args)
        {
            var drivers = DriverUsed.MySql | DriverUsed.Sqlite;

            const string connString01 = "Data Source=:memory:;Version=3;New=True;";
            const string connString02 = "Server=localhost;Port=3306;Database=shuran_schema;Uid=root;Pwd=;";

			if (DriverUsed.MySql | drivers)
	            Fluently.Configure ()
	                .Database (MySQLConfiguration.Standard.ConnectionString (connString02))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();

			if (DriverUsed.Sqlite | drivers)
	            Fluently.Configure ()
	                .Database (SQLiteConfiguration.Standard
					           .ConnectionString(connString01).Driver<SQLite20Driver>()
					           .InMemory()
					           // .Dialect("NHibernate.Dialect.SQLiteDialect"))
					           .Dialect(typeof(SQLiteDialect).FullName))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();
			
			
            Console.ReadKey ();
        }

        static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport (cfg);
            schemaExport.Drop (false, true);
            schemaExport.Create (false, true);
        }

        ISessionFactory CreateSessionFactory(DriverUsed drivers)
        {
            // if (DriverUsed.MySql | drivers)
                // return Fluently.
        }
    }
}
