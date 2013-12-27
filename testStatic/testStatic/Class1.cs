/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 1:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace testStatic
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class Class1
    {
        public Class1()
        {
        }
        
        private static bool _on;
        
        public static void SetOn(bool booleanValue)
        {
            _on = booleanValue;
        }
        
        public int GetValue()
        {
            if (_on) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}
