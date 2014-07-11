/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/4/2014
 * Time: 11:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
    using System;
	using Nancy;
    
    /// <summary>
    /// Description of HomeModule.
    /// </summary>
    public class HomeModule : NancyModule
    {
        const string indexPage = @"
        <html><body>
        <h1>Yep. The server is running</h1>
        </body></html>
        ";
        
        public HomeModule()
        {
            Get["/"] = parameter => { return indexPage; };
        }
    }
}
