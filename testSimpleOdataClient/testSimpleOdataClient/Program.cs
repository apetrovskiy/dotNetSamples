/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/21/2014
 * Time: 3:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSimpleOdataClient
{
    using System;
	using System.Net;
    using Simple.OData.Client;
    //using Simple.OData.Client.Extensions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            // var client = new ODataClient("http://packages.nuget.org/v1/FeedService.svc/");
            try {
                // string url = @"http://vl-w8x86-client/ReportServer?%2FNetwrix%20Auditor%20for%20SharePoint%2FAll%20Changes%2FAll%20SharePoint%20Changes&amp;Interval=0&amp;Sort_By=When&amp;Date_From=02%2F12%2F2014%2022%3A27%3A02&amp;Date_To=02%2F13%2F2014%2022%3A27%3A02&amp;Domain_Param=%25&amp;Action=1&amp;Action=2&amp;Action=3&amp;Action=14&amp;Action=15&amp;Action=16&amp;Action=10&amp;Group_Names=%25&amp;ReportName=All%20SharePoint%20Changes&amp;ProductName=Netwrix%20Auditor&amp;ReportDescription=Shows%20changes%20to%20farms%2C%20site%20collections%2C%20web%20applications%2C%20policies%2C%20permissions%2C%20lists%2C%20documents%2C%20etc.&amp;What_Changed=%25&amp;Where_Changed=%25&amp;Who_Changed=%25&amp;Object_Type=%25&amp;Workstation=%25&amp;HideRunningValues=True&amp;rs%3AParameterLanguage=&amp;rs%3ACommand=Render&amp;rs%3AFormat=ATOM&amp;rc%3AItemPath=MainTable";
                // string url = @"http://vl-w8x86-client/ReportServer/Reserved.ReportViewerWebControl.axd";
                // http://<server name>/ReportServer?%2f<ReportName>rs%3aCommand=Render&rs%3aFormat=ATOM&rc%3aDataFeed=<Identifier>
                string url = @"http://vl-w8x86-client/ReportServer?%2FNetwrix%20Auditor%20for%20SharePoint%2FAll%20Changes%2FAll%20SharePoint%20Changes&amp;rs%3ACommand=Render&amp;rs%3AFormat=ATOM&amp;rc%3AItemPath=MainTable";
                // ;rs%3AParameterLanguage=&amp;rs%3ACommand=Render&amp;rs%3AFormat=ATOM&amp;rc%3AItemPath=MainTable";
                // rs%3AParameterLanguage=&amp;rs%3ACommand=Render&amp;rs%3AFormat=ATOM&amp;rc%3AItemPath=MainTable";
                
                // var clientSettings = new ODataClientSettings("http://10.0.1.214/ReportServer", new NetworkCredential(@"outcast\spmgmtaccount", "Lock12Lock"));
                // var clientSettings = new ODataClientSettings(url, new NetworkCredential(@"outcast\spmgmtaccount", "Lock12Lock"));
                // var clientSettings = new ODataClientSettings(url, new NetworkCredential(@"spmgmtaccount", "Lock12Lock"));
                // var clientSettings = new ODataClientSettings(url, new NetworkCredential("spmgmtaccount", "Lock12Lock"));
                // var client = new ODataClient("http://10.0.1.214/ReportServer");
                // var clientSettings = new ODataClientSettings(url, new NetworkCredential(@"outcast\administrator", "Lock12Lock"));
                var clientSettings = new ODataClientSettings(url, new NetworkCredential("administrator", "Lock12Lock"));
                var client = new ODataClient(clientSettings);
            }
            catch (Exception eee) {
                Console.WriteLine(eee.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}