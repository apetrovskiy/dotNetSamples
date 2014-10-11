/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/12/2014
 * Time: 1:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TfsAutomation.Core
{
	using System;

	public static class ObjectFactory
	{
		static ObjectFactory ()
		{
		}

		public static T Resolve<T>(T type)
		{
			return default(T);
		}
	}
}

