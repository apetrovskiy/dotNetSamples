/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/13/2014
 * Time: 10:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testNSubProxyExtensionMethods
{
    /// <summary>
    /// Description of Class01.
    /// </summary>
    public class Class01 : IIface01, IIface02
    {
        public virtual int GetNumber()
        {
            return 3;
        }
        
        public virtual IChild ChildObject { get; set; }
    }
}
