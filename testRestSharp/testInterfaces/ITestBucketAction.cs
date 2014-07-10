/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 6:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	using System.Collections.Generic;
	
	/// <summary>
	/// Description of ITestBucketAction.
	/// </summary>
	public interface ITestBucketAction
	{
		string Code { get; set; }
		Dictionary<string, object> Parameters { get; set; }
	}
}
