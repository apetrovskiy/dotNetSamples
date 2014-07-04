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
	using Nancy;
    
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
        }
//        
//        private object GetTestResult(int id, string name, int status)
//        {
//            // fake a return
//            return new { Id = id, Name = name, Status = status };
//        }
    }
}
