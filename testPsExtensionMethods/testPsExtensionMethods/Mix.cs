/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 12:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testPsExtensionMethods
{
    /// <summary>
    /// Description of Mix.
    /// </summary>
    public class Mix : IUpper, ILower
    {
        public int Number()
        {
            Console.WriteLine("Mix");
            return 3;
        }
        
        public void OutputString()
        {
            Console.WriteLine("Mix");
        }
    }
}
