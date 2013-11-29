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
    /// Description of SomethingThatNeedsACommand.
    /// </summary>
    public class SomethingThatNeedsACommand {
        ICommand command;
        public SomethingThatNeedsACommand(ICommand command) {
            this.command = command;
        }
        public void DoSomething() { command.Execute(); }
        public void DontDoAnything() { }
    }
}
