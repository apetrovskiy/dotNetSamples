/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 5:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace story01
{
    /// <summary>
    /// Description of Pet.
    /// </summary>
    public class Pet
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual bool Deceased { get; set; }
      
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, Deceased: {2}", Name, Age, Deceased);
        }
    }
}
