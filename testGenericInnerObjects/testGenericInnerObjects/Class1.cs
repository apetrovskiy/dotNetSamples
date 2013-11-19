/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/18/2013
 * Time: 10:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenericInnerObjects
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class Class1//<T> where T : class
    {
        private T innerObject;
        
        public Class1(T innerObject)
        {
            this.innerObject = innerObject;
        }
        
        public int GetNumber<T>()
        {
            return this.innerObject.GetNumber();
        }
    }
}
