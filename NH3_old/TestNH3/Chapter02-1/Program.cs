
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
        const string connString01 = "Data Source=:memory:;Version=3;New=True;";
        const string connString02 = "Server=localhost;Port=3306;Database=shuran_schema;Uid=root;Pwd=;";

        public static void Main (string[] args)
        {
            var drivers = DriverUsed.MySql; // | DriverUsed.Sqlite;

			if (DriverUsed.MySql == (drivers |= DriverUsed.MySql))
	            Fluently.Configure ()
	                .Database (MySQLConfiguration.Standard.ConnectionString (connString02))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();

            CreateSessionFactory (drivers);

			if (DriverUsed.Sqlite == (drivers |= DriverUsed.Sqlite))
	            Fluently.Configure ()
	                .Database (SQLiteConfiguration.Standard
					           .ConnectionString(connString01).Driver<SQLite20Driver>()
					           .InMemory()
					           // .Dialect("NHibernate.Dialect.SQLiteDialect"))
					           .Dialect(typeof(SQLiteDialect).FullName))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();
			
            CreateSessionFactory (drivers);


            Console.ReadKey ();
        }

        static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport (cfg);
            schemaExport.Drop (false, true);
            schemaExport.Create (false, true);
        }

        static ISessionFactory CreateSessionFactory(DriverUsed drivers)
        {
            if (DriverUsed.MySql == (drivers |= DriverUsed.MySql))
                return Fluently.Configure ()
                    .Database (MySQLConfiguration.Standard
                              .ConnectionString (connString01))
                    .Mappings (m => m.FluentMappings
                              .AddFromAssemblyOf<ProductMap> ())
                    .BuildSessionFactory ();

            if (DriverUsed.Sqlite == (drivers |= DriverUsed.Sqlite))
                return Fluently.Configure ()
                    .Database (SQLiteConfiguration
                              .Standard.ConnectionString (connString02))
                    .Mappings (m => m.FluentMappings
                              .AddFromAssemblyOf<ProductMap> ())
                    .BuildSessionFactory ();

            return null;
        }
    }
}
