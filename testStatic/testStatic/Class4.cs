/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 1:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStatic
{
    /// <summary>
    /// Description of Class4.
    /// </summary>
    public class Class4
    {
        public Class4()
        {
        }
        
        public static bool On { get; set; }
        
        public static void SetOn(bool booleanValue)
        {
            On = booleanValue;
        }
        
        public int GetValue()
        {
            if (On) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}
