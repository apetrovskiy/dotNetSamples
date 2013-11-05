/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/24/2013
 * Time: 8:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace listsSvc
{
    using System;
    using System.Web.Services.Configuration;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            WS_Lists.Lists myservice = new WS_Lists.Lists();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}