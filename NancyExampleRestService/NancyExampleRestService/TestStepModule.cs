/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 5:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using Nancy;
	using Nancy.ModelBinding;
	using testInterfaces;
	
	/// <summary>
	/// Description of TestStepModule.
	/// </summary>
	public class TestStepModule : NancyModule
	{
		public TestStepModule() : base("/v1")
		{
			Get["/TestSteps/{currentStep}"] = parameter => {
                var testStep = this.Bind<TestStep>();
				testStep.Name += "presented";
				testStep.HostId = parameter.hostid;
				return Response.AsJson<ITestStep>(testStep, HttpStatusCode.OK);
			};
			
			Put["/TestSteps/{id}"] = parameter => {
                var testStep = this.Bind<TestStep>();
				testStep.Name += " put 01";
				testStep.HostId = parameter.hostid;
				return Response.AsJson<ITestStep>(testStep, HttpStatusCode.OK);
			};
		}
	}
}
