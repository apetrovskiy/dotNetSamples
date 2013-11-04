/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 11:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testNSub
{
	/// <summary>
	/// Description of Class3.
	/// </summary>
	public class Class3
	{
		public Class3()
		{
		}
		
		public DamnSealedClass GetOneElement()
		{
			DamnSealedClass dc = MyFactory.GetElement();
			DamnSealedCollection coll = dc.ManyElements();
			if (null != coll && 0 < coll.Count) {
				return coll[0];
			} else {
				return coll;
			}
		}
	}
}
