/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/2/2013
 * Time: 12:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testNSub
{
	/// <summary>
	/// Description of Class2.
	/// </summary>
	public class Class2 : Interface2
	{
		private bool registrationStatus;
		
		public Class2()
		{
		}
		
		public void Register()
		{
			this.registrationStatus = true;
		}
		
		public void Deregister()
		{
			this.registrationStatus = false;
		}
		
		public bool IsRegistered
		{
			get { return this.registrationStatus; }
		}
		
		public bool GetRegistrationStatus()
		{
			return this.registrationStatus;
		}
	}
}
