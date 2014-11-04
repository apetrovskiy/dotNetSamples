/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/11/2014
 * Time: 2:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using testInterfaces;
	
	/// <summary>
	/// Description of SmthModule.
	/// </summary>
	public class SmthModule : NancyModule
	{
		public SmthModule() : base("/v1/somethings")
		{
            Get["/{id}"] = parameters => {
                var smth = this.Bind<Something>();
				var smthInStorage = SmthStorage.Somethings.First(s => s.Id == smth.Id);
				smthInStorage.Name += " added (get)";
				return Response.AsJson<ISomething>(smthInStorage, HttpStatusCode.OK);
            };
            
            Post["/"] = _ => {
            	try { 
					var smth = this.Bind<Something>();
					smth.Name += " created (post)";
					SmthStorage.Somethings.Add(smth);
					return Response.AsJson<ISomething>(smth, HttpStatusCode.OK);
				} 
				catch (Exception e) {
					throw new Exception("getting the smth supplied. " + e.Message);
				}
			};
			
            Put["/{id}"] = parameters => {
				var smth = this.Bind<Something>();
				smth.Name += " replaced (put)";
				var smthInStorage = SmthStorage.Somethings.First(s => s.Id == smth.Id);
				if (null != smthInStorage) {
					SmthStorage.Somethings.Remove(smthInStorage);
					SmthStorage.Somethings.Add(smth);
				}
				return Response.AsJson<ISomething>(SmthStorage.Somethings.First(s => s.Id == smth.Id), HttpStatusCode.OK);
			};
		}
	}
}
