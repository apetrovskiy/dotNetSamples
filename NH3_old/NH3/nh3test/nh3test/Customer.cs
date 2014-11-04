/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/22/2013
 * Time: 7:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nh3test
{
    using System;
    
    /// <summary>
    /// Description of Customer.
    /// </summary>
    public class Customer
    {
//        public Customer()
//        {
//        }
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
