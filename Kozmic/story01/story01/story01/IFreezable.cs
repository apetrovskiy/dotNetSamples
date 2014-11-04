/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace story01
{
    /// <summary>
    /// Description of IFreezable.
    /// </summary>
    internal interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
    }
}
