/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/5/2014
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDeserialization
{
    using System;
	using System.IO;
    using System.Linq;
	using System.Text;
	using Nancy;
	using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of Module4.
    /// </summary>
    public class Module4 : NancyModule
    {
        public Module4() : base("/")
        {
            Post["probe4/"] = _ => {
                
                // this.Context.Request.
                
                Console.WriteLine("========================= this.Context.Parameters: ===========================");
                foreach (var prm in this.Context.Parameters) {
                    Console.WriteLine(prm);
                }
                
                Console.WriteLine("========================= this.Context.Items: ===========================");
                foreach (var it in this.Context.Items) {
                    Console.WriteLine(it.Key);
                    Console.WriteLine(it.Value);
                }
                
                Console.WriteLine("========================= Request.Query['path']: ===========================");
                string path = Request.Query["path"];
                Console.WriteLine(path);
                
                Console.WriteLine("========================= Request.Headers.Values: ===========================");
                foreach (var val in Request.Headers.Values) {
                    Console.WriteLine(val);
                    var fffff = val as string[];
                    try {
                        foreach (var vvvv in fffff) {
                            Console.WriteLine(vvvv);
                        }
                    }
                    catch {}
                }
                
                Console.WriteLine("========================= Request.Files: ===========================");
                foreach (var fil in Request.Files) {
                    Console.WriteLine(fil.Key);
                    Console.WriteLine(fil.Name);
                }
                
                var fileValue = Request.Files.First().Value;
                var fileName = Request.Files.First().Name;
                var actualBytes = new byte[fileValue.Length];
                fileValue.Read(actualBytes, 0, (int)fileValue.Length);
                using (var writer = new BinaryWriter(File.Open(@"E:\20140905\dst\" + fileName, FileMode.Create))) {
                    writer.Write(actualBytes);
                }
                return HttpStatusCode.NoContent;
            };
        }
    }
}
