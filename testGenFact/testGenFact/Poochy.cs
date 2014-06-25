/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/20/2014
 * Time: 9:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenFact
{
    /// <summary>
    /// Description of Poochy.
    /// </summary>
    public class Poochy : IBrand
    {
        public int Price { get { return new Gucci().Price / 3; } }
        public string Material { get { return "Plastic"; } }
    }
}
