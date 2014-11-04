/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/17/2013
 * Time: 6:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ITextTest
{
    using System;
    using iTextSharp;
    using iTextSharp.text.html;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using PdfSharp;
    using PdfSharp.Pdf; //.Advanced.
    using PdfSharp.Pdf.Actions;
    using PdfSharp.Pdf.Advanced;
    using PdfSharp.Pdf.Content;
    using PdfSharp.Pdf.IO;
    
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            //string urlFileName1 = @"\\10.0.0.237\C$\eeee (Enabled User Accounts).pdf"; //"pdf_link";
            //string urlFileName1 = @"\\10.0.0.237\C$\fgyu (Shares Changes).pdf";
            //string urlFileName1 = @"\\10.0.0.237\C$\rft (Overview).pdf";
            //string urlFileName1 = @"D:\Products\reports\Address List Changes.pdf";
            string urlFileName1 = @"D:\Products\reports\All MS Exchange Changes.pdf";
            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(urlFileName1);
            PdfSharp.Pdf.PdfDocument doc = PdfSharp.Pdf.IO.PdfReader.Open(urlFileName1); //, PdfDocumentOpenMode.ReadOnly);
            string text = string.Empty;
            string text2 = string.Empty;
            string text3 = string.Empty;
            ITextExtractionStrategy strategySimple = new SimpleTextExtractionStrategy();
            //strategySimple.
            ITextExtractionStrategy strategyLocation = new LocationTextExtractionStrategy();
            //strategyLocation.
            
//            //PdfSharp.Pdf.PdfDocument
//            foreach (PdfSharp.Pdf.PdfPage page0 in doc.Pages) {
//                //page0.GetAsString
//                //Console.WriteLine(page0.Contents);
//                Console.WriteLine(page0.Contents);
//                foreach (var element in page0.Contents) {
//                    Console.WriteLine(element);
//                }
//            }
            
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
                text += "\r\n-------------------------------------------------------\r\n";
                text2 += PdfTextExtractor.GetTextFromPage(reader, page, strategySimple);
                text2 += "\r\n-------------------------------------------------------\r\n";
                text3 += PdfTextExtractor.GetTextFromPage(reader, page, strategyLocation);
                text3 += "\r\n-------------------------------------------------------\r\n";
            }
            reader.Close();
            //candidate3.Text = text.ToString();
            Console.WriteLine(text.ToString());
            Console.WriteLine("=========================================================");
            Console.WriteLine(text2.ToString());
            Console.WriteLine("=========================================================");
            Console.WriteLine(text3.ToString());
            Console.WriteLine("=========================================================");
            
            
            
            //String page = PdfTextExtractor.getTextFromPage(reader, 2);
            //String s1[]=page.split("\n");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}