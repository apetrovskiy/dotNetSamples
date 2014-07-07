/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/4/2014
 * Time: 11:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
    using System;
	using System.IO;
	using System.Windows.Forms;
	using Nancy;
	using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of TestResultModule.
    /// </summary>
    public class TestResultModule : NancyModule
    {
        public TestResultModule() : base("/TestResults")
        {
            // Get["/{id}/{name}/{status}"] = parameter => { return GetTestResult(parameter.id, parameter.name, parameter.status); };
            Get["/{id}/{name}/{status}"] = parameter => {
                var result = new { Id = parameter.id, Name = parameter.name, Status = parameter.status };
                return Response.AsJson(result).WithStatusCode(HttpStatusCode.OK);
            };
            
            Post["/{id}/{name}/{status}"] = parameter => {
                var result = new { Id = parameter.id, Name = parameter.name, Status = parameter.status };
                return Response.AsJson(result).WithStatusCode(HttpStatusCode.OK); 
            };
            
            // Post["/"] = pa
            // this.Request.Body
            //             Post["/rel"] = parameters => new StreamReader(this.Request.Body).ReadToEnd();
            // Request.Body.
            
			Post["/"] = _ => {
				// Request.Body
				// Response.
				var model = this.Bind();
				var loadedData = new StreamReader(Request.Body).ReadToEnd();
				// Console.WriteLine(loadedData);
				// MessageBox.Show(loadedData);
				// var myObj = Response.AsJson<string>(
				// return Response.AsJson<int[]>(new int[]{1,2,3}, HttpStatusCode.OK);
				return Response.AsJson<string>(loadedData, HttpStatusCode.OK);
				// return Response.AsJson<string>(model, HttpStatusCode.OK);
			};
            
//			Post["/"] = _ => {
//            	
//			};
        }
//        
//        private object GetTestResult(int id, string name, int status)
//        {
//            // fake a return
//            return new { Id = id, Name = name, Status = status };
//        }
    }
}
