/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/8/2013
 * Time: 6:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nh3test
{
    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using System.Reflection;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			try {
			Category categ = new Category();
			categ.Id = 1;
			CategoryMap catMap = new CategoryMap();
			catMap.Id(x => x.Id);
			
			Product prod = new Product();
			prod.Id = 1;
			ProductMap prodMap = new ProductMap();
			prodMap.Id(x => x.Id);
			
			string connString =
			    "Server=spb8638\\FIRST;Database=probe;Integrated Security=SSPI;";
			
//			var cfg = new Configuration();
//			cfg.DataBaseIntegration(x => {
//			                            x.ConnectionString = "Server=spb8638\\FIRST;Database=probe;Integrated Security=SSPI;";
//			                            x.Driver<SqlClientDriver>();
//			                            x.Dialect<MsSql2008Dialect>();
//			                        });
//			cfg.AddAssembly(Assembly.GetExecutingAssembly());
//			var sessionFactory = cfg.BuildSessionFactory();
//			using (var session = sessionFactory.OpenSession())
//		    using (var tx = session.BeginTransaction()) {
//		        // perform database logic
//		        var customers = session.CreateCriteria<Customer>()
//		                               .List<Customer>();
//		        foreach (var customer in customers) {
//		            Console.WriteLine("{0} {1}", customer.FirstName, customer.LastName);
//		        }
//		        tx.Commit();
//		    }
//			Console.WriteLine("Press <ENTER> to exit...");
//			Console.ReadLine();
			
			Fluently.Configure()
			    .Database(MsSqlConfiguration
			              .MsSql2008
			              .ConnectionString(connString))
			    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
			    .ExposeConfiguration(CreateSchema)
			    .BuildConfiguration();
			
			
			
			}
			catch (Exception eHZ) {
			    Console.WriteLine(eHZ.Message);
			}
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		private static void CreateSchema(Configuration cfg)
		{
		    var schemaExport = new SchemaExport(cfg);
		    schemaExport.Drop(false, true);
		    schemaExport.Create(false, true);
		}
	}
}