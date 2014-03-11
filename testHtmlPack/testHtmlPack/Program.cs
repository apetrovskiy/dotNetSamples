/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/11/2014
 * Time: 2:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHtmlPack
{
	using System;
	using System.Linq;
	using HtmlAgilityPack;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			/*
			var doc0 = new HtmlDocument();
			doc0.Load(@"D:\HTML\TPAMmenu.htm");
			// doc.Load(@"D:\HTML\TPAMmenu_wrong.htm");
			
			if (null != doc0.ParseErrors || doc0.ParseErrors.Any()) {
				Console.WriteLine("there are errors:");
				
				foreach (var htmlParseError in doc0.ParseErrors) {
					Console.WriteLine(htmlParseError.Code);
					Console.WriteLine(htmlParseError.SourceText);
				}
			}
			
			foreach (HtmlNode link in doc0.DocumentNode.SelectNodes("//a[@href]")) {
				// var attribute = link["href"];
				// attribute.valu
				Console.WriteLine(link.Name);
				Console.WriteLine(link.Id);
				Console.WriteLine(link.InnerHtml);
				Console.WriteLine(link.InnerText);
			}
			
			
			
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(@"<html><body><p><table id=""foo""><tr><th>hello</th></tr><tr><td>world</td></tr></table></body></html>");
			foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table")) {
			    Console.WriteLine("Found: " + table.Id);
			    foreach (HtmlNode row in table.SelectNodes("tr")) {
			        Console.WriteLine("row");
			        foreach (HtmlNode cell in row.SelectNodes("th|td")) {
			            Console.WriteLine("cell: " + cell.InnerText);
			        }
			    }
			}
			
//			var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
//			            from row in table.SelectNodes("tr").Cast<HtmlNode>()
//			            from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
//			            select new {Table = table.Id, CellText = cell.InnerText};
			
			var query = from table in doc.DocumentNode.SelectNodes("//table")
			            from row in table.SelectNodes("tr")
			            from cell in row.SelectNodes("th|td")
			            select new {Table = table.Id, CellText = cell.InnerText};
			
			foreach(var cell in query) {
			    Console.WriteLine("{0}: {1}", cell.Table, cell.CellText);
			}
			
			*/
			
			
			var letter = new HtmlAgilityPack.HtmlDocument();
			letter.Load(@"D:\20140311\0943.htm");
			
			// letter.ge
			
			Console.WriteLine("========================================================================================================================");
			
			var tables = letter.DocumentNode.SelectNodes("//table[@id='changes']");
			if (null == tables) {
				Console.WriteLine("null == tables");
			} else {
				Console.WriteLine("null != tables");
				if (0 == tables.Count) {
					Console.WriteLine("0 == tables.Count");
				} else {
					Console.WriteLine("0 != tables.Count, {0}", tables.Count);
					foreach (var table in tables) {
						Console.WriteLine("name = {0}", table.Name);
						Console.WriteLine("id = {0}", table.Id);
					}
				}
			}
			
			Console.WriteLine("========================================================================================================================");
			
			try {
				foreach (HtmlNode tableNode in letter.DocumentNode.SelectNodes("//table[@id='changes']")) {
					Console.WriteLine(tableNode.Name);
					Console.WriteLine(tableNode.Id);
					
					foreach (var tableRow1 in tableNode.ChildNodes) {
						Console.WriteLine("===========================================================");
						
						foreach (var tableCell in tableRow1.ChildNodes) {
							Console.WriteLine(tableCell.InnerText);
						}
						
					}
				}
			}
			catch (Exception eParsing) {
				Console.WriteLine(eParsing.Message);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}