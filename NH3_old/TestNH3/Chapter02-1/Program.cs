
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
        const string connStringSqlite = "Data Source=:memory:;Version=3;New=True;";
        const string connStringMySql = "Server=localhost;Port=3306;Database=shuran_schema;Uid=root;Pwd=;";

        public static void Main (string[] args)
        {
            var drivers = DriverUsed.MySql; // | DriverUsed.Sqlite;
            // var drivers = DriverUsed.Sqlite;

            if (DriverUsed.MySql == (drivers |= DriverUsed.MySql)) {
	            Fluently.Configure ()
	                .Database (MySQLConfiguration.Standard.ConnectionString (connStringMySql))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();

	            SaveObjects(drivers);
            }
            if (DriverUsed.Sqlite == (drivers |= DriverUsed.Sqlite)) {
	            Fluently.Configure ()
	                .Database (SQLiteConfiguration.Standard
					           .ConnectionString(connStringSqlite).Driver<SQLite20Driver>()
					           .InMemory()
					           // .Dialect("NHibernate.Dialect.SQLiteDialect"))
					           .Dialect(typeof(SQLiteDialect).FullName))
	                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
	                    .ExposeConfiguration (CreateSchema)
	                    .BuildConfiguration ();
			
	            SaveObjects(drivers);
            }
            
            Console.WriteLine("Sehr gut!");
            Console.ReadKey ();
        }
        
		static void SaveObjects(DriverUsed drivers)
		{
            if (DriverUsed.MySql == (drivers |= DriverUsed.MySql)) {
                var factoryMySql = CreateSessionFactory (drivers);
                using (var sessionMySql = factoryMySql.OpenSession()) {
                    var categoryMySql = new Category { Name = "Beverages" };
                    var productMySql = new Product { Name = "Milk", Category = categoryMySql };
                    sessionMySql.Save (categoryMySql);
                    sessionMySql.Save (productMySql);
                }
            }
			
			if (DriverUsed.Sqlite == (drivers |= DriverUsed.Sqlite)) {
				var factorySqlite = CreateSessionFactory(drivers);
				using (var sessionSqlite = factorySqlite.OpenSession()) {
					var category = new Category { Name = "Beverages", Description = "aaa" };
					var product = new Product { Name = "Milk", Category = category };
					sessionSqlite.Save(category);
					sessionSqlite.Save(product);
					
					sessionSqlite.Delete(category);
				}
			}
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
                              .ConnectionString (connStringMySql))
                    .Mappings (m => m.FluentMappings
                              .AddFromAssemblyOf<ProductMap> ())
                    .BuildSessionFactory ();

            if (DriverUsed.Sqlite == (drivers |= DriverUsed.Sqlite))
                return Fluently.Configure ()
                    .Database (SQLiteConfiguration
            		           .Standard.ConnectionString (connStringSqlite).Driver<SQLite20Driver>()
					           .InMemory()
					           // .Dialect("NHibernate.Dialect.SQLiteDialect"))
					           .Dialect(typeof(SQLiteDialect).FullName))
                    .Mappings (m => m.FluentMappings
                              .AddFromAssemblyOf<ProductMap> ())
                    .BuildSessionFactory ();

            return null;
        }
    }
}
