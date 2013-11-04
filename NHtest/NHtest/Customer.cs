/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/4/2013
 * Time: 4:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NHtest
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of Customer.
    /// </summary>
    public class Customer
    {
        public Customer()
        {
        }
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
