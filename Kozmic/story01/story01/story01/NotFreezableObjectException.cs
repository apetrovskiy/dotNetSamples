/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 6:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace story01
{
    /// <summary>
    /// Description of NotFreezableObjectException.
    /// </summary>
    public class NotFreezableObjectException : Exception
    {
        public NotFreezableObjectException(object obj)
        {
            // base.Message += obj.ToString();
        }
    }
}
