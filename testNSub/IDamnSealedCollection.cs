/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 10:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace testNSub
{
	public interface IDamnSealedCollection
	{
		void CopyTo(Array array, int index);
		void CopyTo(DamnSealedClass[] array, int index);
		IEnumerator GetEnumerator();
		DamnSealedClass Item { get; }
		int Count { get; }
		object SyncRoot { get; }
		bool IsSynchronized { get; }
	}
}
