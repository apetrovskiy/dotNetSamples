/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/16/2013
 * Time: 11:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub2
{
    using System;
    
    /// <summary>
    /// Description of ICommand.
    /// </summary>
    public interface ICommand {
        void Execute();
        event EventHandler Executed;
    }
}
