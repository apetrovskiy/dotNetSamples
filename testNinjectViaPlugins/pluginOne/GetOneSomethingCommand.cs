/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/10/2014
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pluginOne
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetOneSomethingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "OneSomething")]
    public class GetOneSomethingCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            var testOne = centralLib.ObjectsFactory.Resolve<ITestOne>();
            WriteObject(testOne);
        }
    }
}
