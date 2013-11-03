/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 11:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testNSub
{
	/// <summary>
	/// Description of MyFactory.
	/// </summary>
	public static class MyFactory
	{
		public static DamnSealedClass GetElement()
		{
			return new DamnSealedClass();
		}
	}
}
