/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 12:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testPsExtensionMethods
{
    /// <summary>
    /// Description of Upper.
    /// </summary>
    public class Upper : IUpper
    {
        public int Number()
        {
            Console.WriteLine("Upper");
            return 3;
        }
    }
}
