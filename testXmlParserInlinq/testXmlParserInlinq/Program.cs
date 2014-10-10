/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/10/2014
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Tmx.Server;

namespace testXmlParserInlinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var workflowLoader = new WorkflowLoader();
            workflowLoader.LoadWorkflow(@"C:\Projects\NW\NwxTestReporting\NwxTestReporting\data\Workflow.xml");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}