﻿/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 1:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStatic
{
    /// <summary>
    /// Description of Class2.
    /// </summary>
    public class Class2
    {
        public Class2()
        {
        }
        
        internal static bool On;
        
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