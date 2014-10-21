
namespace TestNH3
{
    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Hello World!");

            const string connString = "Data Source=:memory:;Version=3;New=True;";

            Fluently.Configure ()
                .Database (SQLiteConfiguration.Standard.ConnectionString (connString))
                    .Mappings (m => m.FluentMappings.AddFromAssemblyOf<ProductMap> ())
                    .ExposeConfiguration (CreateSchema)
                    .BuildConfiguration ();
        }

        static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport (cfg);
            schemaExport.Drop (false, true);
            schemaExport.Create (false, true);
        }
    }
}
