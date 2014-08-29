/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 8/29/2014
 * Time: 12:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRestSharp
{
    using System;
	using System.IO;
	using System.Xml.Linq;
	using RestSharp;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            try {
                var client = new RestClient(@"http://localhost:12340/");
                var request = new RestRequest("probe2/", Method.POST);
                // request.AddFile("file", @"c:\1\test.txt");
                // var file = new StreamReader(@"c:\1\test.txt");
                var xDoc = XDocument.Load(@"E:\20140828\imported_rdp_SPLab-2008R2.SPALab.at.local_170.xml");
                // var fileContent = xDoc.Root.Value;
                // var fileContent = xDoc.Root;
                var fileContent = xDoc;
Console.WriteLine(fileContent);
                // request.AddObject(fileContent);
                // request.AddParameter(new Parameter(
                var p = new Parameter();
                p.Name = "content";
                p.Value = fileContent;
                request.AddParameter(p);
                request.AddBody(fileContent);
Console.WriteLine("000000000000000000001");
                var response = client.Execute(request);
Console.WriteLine("000000000000000000002");
                Console.WriteLine(response);
            }
            catch (Exception eeeee) {
                Console.WriteLine(eeeee.Message);
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}