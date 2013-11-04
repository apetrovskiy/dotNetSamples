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
	/// Description of Class1.
	/// </summary>
	public class Class1 : Interface1
	{
		Interface2 internalObject;
		
		public Class1(Interface2 obj1)
		{
			this.internalObject = obj1;
		}
		
		public Interface2 GetInternalObject()
		{
			return this.internalObject;
		}
	}
}
