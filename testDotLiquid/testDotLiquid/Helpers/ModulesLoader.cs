/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/14/2014
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDotLiquid.Helpers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of ModulesLoader.
    /// </summary>
//    public class ModulesLoader
//    {
//        string _path;
//        
//        public ModulesLoader(string path)
//        {
//            _path = path;
//        }
//        
//        public void Load()
//        {
//            if (!Directory.Exists(_path)) return;
//            try {
//                var dir = new DirectoryInfo(_path);
//                var files = dir.GetFiles("*.dll");
//                if (null == files || !files.Any()) return;
//                foreach (var probablyAssembly in files) {
//                    try {
//                        Assembly.LoadFrom(probablyAssembly.FullName);
//                    }
//                    catch (Exception e) {
//                        Console.WriteLine(e.Message);
//                    }
//                }
//                
//            }
//            catch (Exception eee) {
//                Console.WriteLine(eee.Message);
//            }
//            
//            try {
//                Assembly.LoadFrom(Environment.CurrentDirectory + @"\it\DotLiquid.resources.dll");
//            }
//            catch (Exception eeee) {
//                Console.WriteLine(eeee.Message);
//            }
//        }
//    }
}
