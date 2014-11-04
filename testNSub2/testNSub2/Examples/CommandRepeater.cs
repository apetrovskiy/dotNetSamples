/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/16/2013
 * Time: 12:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub2
{
    using System;
    
    /// <summary>
    /// Description of CommandRepeater.
    /// </summary>
    public class CommandRepeater
    {
        ICommand command;
        int numberOfTimesToCall;
        public CommandRepeater(ICommand command, int numberOfTimesToCall) {
          this.command = command;
          this.numberOfTimesToCall = numberOfTimesToCall;
        }
     
        public void Execute() {
          for (var i=0; i<numberOfTimesToCall; i++) command.Execute();
        }
    }
}
