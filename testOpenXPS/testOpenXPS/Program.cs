/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/20/2013
 * Time: 8:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Xps;
using System.Threading;
using System.Windows.Xps.Packaging;
using System.Windows.Documents;
using System.Collections.Generic;

namespace testOpenXPS
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
//            System.Windows.Xps.Packaging.XpsDocument doc =
//                new System.Windows.Xps.Packaging.XpsDocument(@"D:\20131120\report001.oxps", System.IO.FileAccess.Read);
//            var seq = doc.GetFixedDocumentSequence();
//            seq.
            
        //private void StepOne()
        //{
            List<string> lData = new List<string>();
            using (XpsDocument xpsDoc = new XpsDocument(@"D:\20131120\report001.oxps", System.IO.FileAccess.Read))
            {
                FixedDocumentSequence docSeq = xpsDoc.GetFixedDocumentSequence();
                Dictionary<string, string> docPageText = new Dictionary<string, string>();
                for (int pageNum = 0; pageNum < docSeq.DocumentPaginator.PageCount; pageNum++)
                {
                    DocumentPage docPage = docSeq.DocumentPaginator.GetPage(pageNum);
                    foreach (System.Windows.UIElement uie in ((FixedPage)docPage.Visual).Children)
                    {
                        if (uie is System.Windows.Documents.Glyphs)
                        {
                            lData.Add(((System.Windows.Documents.Glyphs)uie).UnicodeString);
                        }
                    }
                }
            }

            string strText = string.Empty;
            foreach (string strItem in lData)
            {
                if (string.IsNullOrEmpty(strItem))
                    continue;

                strText += strItem;
            }
        //}
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}