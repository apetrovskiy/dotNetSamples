/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/10/2013
 * Time: 4:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace sqlAdoNetTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection("");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd..ExecuteNonQuery()
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}