using System.Reflection;
using NHibernate.Dialect;
using NHibernate.Driver;

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
    using NHibernate.Cfg;
    
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			Category categ = new Category();
			categ.Id = 1;
			CategoryMap catMap = new CategoryMap();
			catMap.Id(x => x.Id);
			
			var cfg = new Configuration();
			cfg.DataBaseIntegration(x => {
			                            x.ConnectionString = "Server=localhost;Database=probe;Integrated Security=SSPI;";
			                            x.Driver<SqlClientDriver>();
			                            x.Dialect<MsSql2008Dialect>();
			                        });
			cfg.AddAssembly(Assembly.GetExecutingAssembly());
			var sessionFactory = cfg.BuildSessionFactory();
			using (var session = sessionFactory.OpenSession())
		    using (var tx = session.BeginTransaction()) {
		        // perform database logic
		        tx.Commit();
		    }
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}