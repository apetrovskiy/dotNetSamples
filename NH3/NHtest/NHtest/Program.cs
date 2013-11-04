/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/4/2013
 * Time: 3:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NHtest
{
    using System;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using System.Reflection;
    
    using System.Collections.ObjectModel;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
//            var cfg = new Configuration();
//            cfg.DataBaseIntegration(x => {
//                                        x.ConnectionString = "Server=localhost;Database=NHibernateDemo;Integrated Security=SSPI;";
//                                        x.Driver<SqlClientDriver>();
//                                        x.Dialect<MsSql2008Dialect>();
//                                    });
//            cfg.AddAssembly(Assembly.GetExecutingAssembly());
//            var sessionFactory = cfg.BuildSessionFactory();
//            using (var tx = session.BeginTransaction()) {
//                // perform database logic
//                tx.Commit();
//            }
            
            var a = new System.Collections.ObjectModel.Collection<string>();
            
            Assembly[] assms =
                System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assm in assms) {
                Console.WriteLine(assm.FullName);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}