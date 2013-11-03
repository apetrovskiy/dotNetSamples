/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 10:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testNSub
{
	/// <summary>
	/// Description of Class3.
	/// </summary>
	public sealed class DamnSealedClass : IDamnSealedClass
	{
		internal DamnSealedClass()
		{
		}

		public DamnSealedCollection ManyElements()
		{
			return new DamnSealedCollection();
		}
	}
}
