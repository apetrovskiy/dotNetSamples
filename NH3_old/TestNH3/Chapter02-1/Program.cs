
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
//    using System.Data.SQLite;
//    using NHibernate.SqlTypes;
//    using NHibernate.Driver;
//    using NHibernate.Bytecode.CodeDom;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Hello World!");
            
            bool sqlite = true;
            bool mysql = false;
            
            const string connString01 = "Data Source=:memory:;Version=3;New=True;";
            const string connString02 = "Server=localhost;Port=3306;Database=shuran_schema;Uid=root;Pwd=;";
            /*
            Fluently.Configure ()
                .Database (SQLiteConfiguration.Standard.ConnectionString (connString01))
                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
                    .ExposeConfiguration (CreateSchema)
                    .BuildConfiguration ();
            */
//			if (mysql)
//	            Fluently.Configure ()
//	                .Database (MySQLConfiguration.Standard.ConnectionString (connString02))
//	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
//	                    .ExposeConfiguration (CreateSchema)
//	                    .BuildConfiguration ();
			if (sqlite)
	            Fluently.Configure ()
	                .Database (SQLiteConfiguration.Standard
					           .ConnectionString(connString01).Driver<SQLite20Driver>()
					           .InMemory()
					           // .Dialect("NHibernate.Dialect.SQLiteDialect"))
					           .Dialect(typeof(SQLiteDialect).FullName))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();
			
//			Fluently.Configure()
//				.Database(SQLiteConfiguration.Standard.ConnectionString(connString01).Driver<sqli
			
			Console.ReadKey();
        }

        static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport (cfg);
            schemaExport.Drop (false, true);
            schemaExport.Create (false, true);
        }
        
        ISessionFactory
    }
}
