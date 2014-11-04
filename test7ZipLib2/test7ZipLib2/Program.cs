/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/17/2014
 * Time: 2:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace test7ZipLib2
{
    using System;
	using SevenZip;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            // SevenZipBase.SetLibraryPath(@"C:\Portable\7-ZipPortable\App\7-Zip64\7-zip.dll");
            SevenZipBase.SetLibraryPath(@"C:\Portable\7-ZipPortable\App\7-Zip64\7z.dll");
            // SevenZipBase.SetLibraryPath(@"C:\Portable\7-ZipPortable\App\7-Zip\7-zip.dll");
            // SevenZipBase.SetLibraryPath(@"C:\Portable\7-ZipPortable\App\7-Zip\7z.dll");
            
            try {
                var extractor = new SevenZipExtractor(@"D:\20140416\2228\Netwrix_Auditor.exe");
                // var extractor = new SevenZipExtractor(@"D:\20140416\2228\Netwrix_Auditor.rar");
                // Console.WriteLine(extractor.Format);
                // extractor
                extractor.ExtractArchive(@"D:\20140416\extracted");
            }
            catch (Exception eOnUnzip) {
                Console.WriteLine(eOnUnzip.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}