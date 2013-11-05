/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 7/23/2013
 * Time: 3:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testzip
{
    using System;
    using Ionic.Zip;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            using (ZipFile zip = ZipFile.Read(@"D:\Products\FSCR\File_Server_Accesses_0005.zip")) {
                foreach (ZipEntry entry in zip) {
                    entry.Extract(@"D:\Products\FSCR\unpacked\", ExtractExistingFileAction.OverwriteSilently);
                }
            }
            
            PSObject pso = new PSObject();
            pso.Members.Add((new PSNoteProperty("prop1", "1")));
            pso.Members.Add((new PSNoteProperty("prop2", "asdfasdfasdf")));
            pso.Members.Add((new PSNoteProperty("prop3", "dfgds dfsges sdfg dsfg dsf")));
            //pso.Members.Add((new PSScriptProperty("prop4", (new ScriptBlock("return 3;")))));
            //ScriptBlock sb = new ScriptBlock(
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}