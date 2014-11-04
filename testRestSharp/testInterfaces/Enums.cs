/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/10/2014
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	using System;
	
	public enum TestActivityStatuses
	{
		New = 0,
		Accepted = 1,
		CompletedSuccessfully = 2,
		Failed = 3
	}
	
	public enum TestActivityTypes
	{
	    Inline = 0,
	    RemoteApp = 1,
	    PsRemoting = 2,
	    Ssh = 10
	}
}