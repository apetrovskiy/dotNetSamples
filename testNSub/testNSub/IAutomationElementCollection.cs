/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/5/2013
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
namespace System.Windows.Automation
{
    public interface IAutomationElementCollection : ICollection, IEnumerable
	{
		//void CopyTo(Array array, int index);
		void CopyTo(AutomationElement[] array, int index);
		//IEnumerator GetEnumerator();
		AutomationElement Item { get; }
		//int Count { get; }
		//object SyncRoot { get; }
		//bool IsSynchronized { get; }
	}
}

