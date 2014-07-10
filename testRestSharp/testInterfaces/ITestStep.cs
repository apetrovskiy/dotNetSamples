/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 6:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	/// <summary>
	/// Description of ITestStep.
	/// </summary>
	public interface ITestStep
	{
		int Id { get; set; }
		string Name { get; set; }
		ITestStepAction[] Action { get; set; }
		string[] ExpectedResult { get; set; }
		int ExecutionType { get; set; }
		bool Active { get; set; }
		string HostId { get; set; }
		int Status { get; set; }
		bool Accepted { get; set; }
	}
}
