﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/5/2013
 * Time: 12:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace System.Windows.Automation
{
    using System;
    using System.Collections;
    using System.Windows.Automation;
    
	//public class AutomationElementCollection : ICollection, IEnumerable, IAutomationElementCollection
	public class AutomationElementCollectionAdapter : IAutomationElementCollection
	{
	    private AutomationElementCollection collectionHolder;
	    
		//private AutomationElement[] _elements;
		public AutomationElement this[int index] {
		    get { return this.collectionHolder[index]; } //return this._elements[index]; }
		}
		public int Count {
		    get { return this.collectionHolder.Count; } //return this._elements.Length; }
		}
		public virtual object SyncRoot {
		    get { return this.collectionHolder; } //return this; }
		}
		public virtual bool IsSynchronized {
			get { return false; }
		}
		//internal AutomationElementCollectionAdapter(AutomationElement[] elements)
		internal AutomationElementCollectionAdapter(AutomationElementCollection elements)
		{
		    //this._elements = elements as AutomationElement[];
		    this.collectionHolder = elements;
		}
		public virtual void CopyTo(Array array, int index)
		{
			//this._elements.CopyTo(array, index);
			this.collectionHolder.CopyTo(array, index);
		}
		public void CopyTo(AutomationElement[] array, int index)
		{
			//((ICollection)this).CopyTo(array, index);
			this.collectionHolder.CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			//return this._elements.GetEnumerator();
			return this.collectionHolder.GetEnumerator();
		}
		
		public AutomationElementCollection SourceCollection
		{
		    get { return this.collectionHolder; }
		}
	}
}

