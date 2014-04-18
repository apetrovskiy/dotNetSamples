/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/14/2014
 * Time: 3:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testClient
{
    using System;
    // using Simple.OData.Client;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            var client = new Simple.OData.Client.ODataClient(@"http://vl-w8x86-client.castaway.at.local/ReportServer?%2FNetwrix%20Auditor%20for%20SharePoint%2FAll%20Changes%2FAll%20SharePoint%20Changes&amp;Interval=0&amp;Sort_By=When&amp;Date_From=04%2F13%2F2014%2015%3A20%3A58&amp;Date_To=04%2F14%2F2014%2015%3A20%3A58&amp;Domain_Param=%25&amp;Action=1&amp;Action=2&amp;Action=3&amp;Action=14&amp;Action=15&amp;Action=16&amp;Action=10&amp;Group_Names=%25&amp;ReportName=All%20SharePoint%20Changes&amp;ProductName=Netwrix%20Auditor&amp;ReportDescription=Shows%20changes%20to%20farms%2C%20site%20collections%2C%20web%20applications%2C%20policies%2C%20permissions%2C%20lists%2C%20documents%2C%20etc.&amp;What_Changed=%25&amp;Where_Changed=%25&amp;Who_Changed=%25&amp;Object_Type=%25&amp;Workstation=%25&amp;HideRunningValues=True&amp;rs%3AParameterLanguage=&amp;rs%3ACommand=Render&amp;rs%3AFormat=ATOM&amp;rc%3AItemPath=MainTable");
            
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}