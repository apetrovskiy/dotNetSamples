/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/13/2014
 * Time: 8:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Tmx;
using Tmx.Core;
using Tmx.Interfaces;

namespace testXmlImport
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            const string folder = @"E:\1111111111111111\";
            // const string filename = @"110";
            // const string filename = @"111";
            // const string filename = @"112";
            const string filename = @"113";
            // const string filename = @"1001";
            
//            var testResultsExporter = new TestResultsExporter();
//            testResultsExporter.ExportResultsToXml(
//                new ImportExportCmdletBaseDataObject {
//                    As = "XML",
//                    Path = folder + filename + ".xml",
//                    FilterAll = true
//                },
//                folder + filename + ".xml",
//                TestData.TestSuites);
            
            var testResultImporter = new TestResultsImporter();
            var dataObject = new ImportExportCmdletBaseDataObject {
                As = "XML",
                Path = folder + filename + ".xml",
                FilterAll = true
            };
            var resultList = testResultImporter.ImportResultsFromXML(dataObject, folder + filename + ".xml");
            var testResultsExporter = new TestResultsExporter();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(dataObject, resultList);
            var writer = new StreamWriter(folder + filename + "_1" + ".xml");
            writer.WriteLine(xDoc);
            writer.Flush();
            writer.Close();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}