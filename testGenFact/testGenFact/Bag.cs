/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/20/2014
 * Time: 9:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenFact
{
    /// <summary>
    /// Description of Bag.
    /// </summary>
    public class Bag<Brand> : IBag
        where Brand : IBrand, new()
    {
        private readonly Brand myBrand;
        
        public Bag()
        {
            myBrand = new Brand();
        }
        
        public string Material { get { return myBrand.Price; } }
    }
}
