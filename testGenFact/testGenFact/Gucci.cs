/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/20/2014
 * Time: 9:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenFact
{
    /// <summary>
    /// Description of Gucci.
    /// </summary>
    public class Gucci : IBrand
    {
        public int Price { get { return 1000; } }
        public string Material { get { return "Crocodile skin"; } }
    }
}
