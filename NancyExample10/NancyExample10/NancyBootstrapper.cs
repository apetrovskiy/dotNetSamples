/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10
{
	using System;
	using System.Text;
	using Nancy;
	using Nancy.Bootstrappers.StructureMap;
	
	/// <summary>
	/// Description of NancyBootstrapper.
	/// </summary>
	public class NancyBootstrapper : StructureMapNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer(StructureMap.IContainer existingContainer)
		{
			StructureMapContainer.Configure(existingContainer);
		}
		
		protected override void ApplicationStartup(StructureMap.IContainer container, Nancy.Bootstrapper.IPipelines pipelines)
		{
			pipelines.OnError += (context, exception) =>
			{
				if (exception is CarNotFoundException)
					return new Response
				{
					StatusCode = HttpStatusCode.NotFound,
					ContentType = "text/html",
					Contents = (stream) =>
					{
						var errorMessage =
							Encoding.UTF8.GetBytes(
								exception.Message);
						stream.Write(errorMessage, 0, errorMessage.Length);
					}
				};
				
				return HttpStatusCode.InternalServerError;
			};
		}
	}
	
//	public class NancyBootstrapper : DefaultNancyBootstrapper
//	{
//		protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
//		{
//			pipelines.OnError += (context, exception) =>
//			{
//				if (exception is CarNotFoundException)
//					return new Response()
//				{
//					StatusCode = HttpStatusCode.NotFound,
//					ContentType = "text/html",
//					Contents = (stream) =>
//					{
//						var errorMessage =
//							Encoding.UTF8.GetBytes(
//								exception.Message);
//						stream.Write(errorMessage, 0, errorMessage.Length);
//					}
//				};
//				
//				return HttpStatusCode.InternalServerError;
//			};
//		}
//	}
}
