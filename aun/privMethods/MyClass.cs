/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 7/3/2013
 * Time: 9:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace privMethods
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public class MyClass
    {
        public MyClass()
        {
            
        }
            
        public void PubMethod()
        {
            Console.WriteLine("pub");
        }
        
        private void PrivMethod()
        {
            Console.WriteLine("priv");
        }
    }
}