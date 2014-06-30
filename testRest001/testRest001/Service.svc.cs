/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 9:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace testRest001
{
	[ServiceContract]
	public interface IService
	{
	   [OperationContract]
	   [WebGet(UriTemplate = "operation/{name}")]
	   string MyOperation(string name);
	}
	
	public class Service : IService
	{
	   public string MyOperation(string name)
	   {
		  // implement the operation
		  return string.Format("Operation name: {0}", name);
	   }
	} 
}
