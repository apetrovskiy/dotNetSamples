/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/20/2014
 * Time: 6:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInheritanceWithIfaces
{
	using System;
	
	/// <summary>
	/// Description of BaseClass.
	/// </summary>
	public class BaseClass : ITest
	{
		public void InterfaceMethod()
		{
			Console.WriteLine("interface method");
		}
		
		public int InterfaceProperty { get; set; }
	}
}
