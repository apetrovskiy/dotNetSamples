/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/12/2015
 * Time: 1:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace allLettersParser
{
    using System;
    using HtmlAgilityPack;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            
            doc.OptionCheckSyntax = false;
            doc.OptionFixNestedTags = true;
            // doc.Load(@"../../../letters/7.0.113.0/mail_dumper.html");
            doc.Load(@"../../../letters/1.1.1.457/1.htm");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}