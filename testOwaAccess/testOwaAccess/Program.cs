/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 18/08/2015
 * Time: 10:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testOwaAccess
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var worker = new OwaWorker();
            worker.Connect("SPLab-Exchange.SPALab.at.local", "report_reader@SPALab.at.local", "suite_admin", "Lock12Lock");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}