﻿/*
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
			
//<<<<<<< HEAD
//			try {
//			Category categ = new Category();
//			categ.Id = 1;
//			CategoryMap catMap = new CategoryMap();
//			catMap.Id(x => x.Id);
//			
//			Product prod = new Product();
//			prod.Id = 1;
//			ProductMap prodMap = new ProductMap();
//			prodMap.Id(x => x.Id);
//			
//			string connString =
//			    "Server=spb8638\\FIRST;Database=probe;Integrated Security=SSPI;";
//=======
//			try {
			Category categ1 = new Category();
			//categ.Id = 1;
			categ1.Name = "Category 01";
			CategoryMap catMap = new CategoryMap();
			catMap.Id(x => x.Id);
			
			Product prod1 = new Product();
			//prod.Id = 1;
			prod1.Name = "product 01";
			ProductMap prodMap = new ProductMap();
			prodMap.Id(x => x.Id);
			
			const string connString =
			    //"Server=spb8638\\FIRST;Database=probe;Integrated Security=SSPI;";
			    "Server=.\\FIRST;Database=probe;Integrated Security=SSPI;";
//>>>>>>> 41c5193d6794d452026ce2c91b1dbedf463da1de
			
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
			
			
			
//<<<<<<< HEAD
//			}
//			catch (Exception eHZ) {
//			    Console.WriteLine(eHZ.Message);
//			}
//			
//			
//=======
//			}
//			catch (Exception eHZ) {
//			    Console.WriteLine(eHZ.Message);
//			    Console.WriteLine(eHZ.InnerException.Message);
//			}
			
			var factory = Fluently.Configure()
			    .Database(MsSqlConfiguration
			              .MsSql2008
			              .ConnectionString(connString))
			    .Mappings(m =>m.FluentMappings
			              .AddFromAssemblyOf<ProductMap>())
			    .BuildSessionFactory();
			
			
			using (var session = factory.OpenSession())
            {
                // do something with the session
                
                session.Save(categ1);
                session.SaveOrUpdate(prod1);
    			
    			var category = new Category
    			{
                    Name = "Beverages",
                    Description = "Some description"
                };
    			
    			var id = session.Save(category);
    			
    			var category2 = new Category { Name = "Beverages" };
                var product = new Product { Name = "Milk", Category = category2 };
                session.Save(category2);
                session.Save(product);
                
                var category3 = new Category { Name = "Cat3", Description = "descr" };
                var product3 = new Product { Name = "prod3", Category = category3, Description = "descr prod 3" };
                session.SaveOrUpdate(category3);
                session.SaveOrUpdate(product3);
			}
//>>>>>>> 41c5193d6794d452026ce2c91b1dbedf463da1de
			
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