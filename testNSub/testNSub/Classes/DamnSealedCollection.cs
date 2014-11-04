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
	/// <summary>
	/// Description of DamnSealedCollection.
	/// </summary>
	//public class DamnSealedCollection : ICollection, IEnumerable, IDamnSealedCollection
	public class DamnSealedCollection : IDamnSealedCollection
	{
		//public DamnSealedClass Item { get; set; }
		internal DamnSealedCollection()
		{

		}
		private DamnSealedClass[] _elements;
		//public DamnSealedClass this[int index] {
		public DamnSealedClass this[int index] {
			get { return this._elements[index]; }
			private set { ; }
		}
		
//		public DamnSealedClass Item {
//			get { return this._elements[index]; }
//		}
		//public DamnSealedClass Item { get; set; }
		
		public int Count {
			get { return this._elements.Length; }
		}
		public virtual object SyncRoot {
			get { return this; }
		}
		public virtual bool IsSynchronized {
			get { return false; }
		}
		internal DamnSealedCollection(DamnSealedClass[] elements)
		{
			this._elements = elements;
		}
		public virtual void CopyTo(Array array, int index)
		{
			this._elements.CopyTo(array, index);
		}
		public void CopyTo(DamnSealedClass[] array, int index)
		{
			((ICollection)this).CopyTo(array, index);
		}
		public IEnumerator GetEnumerator()
		{
			return this._elements.GetEnumerator();
		}
		////////////////////////////////////////////////
		/*
		private IEnumerator<string> Enumerator() {
            // ...
        }
    
        public IEnumerator<string> GetEnumerator() {
            return Enumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return Enumerator();
        }
		*/
	}
}
