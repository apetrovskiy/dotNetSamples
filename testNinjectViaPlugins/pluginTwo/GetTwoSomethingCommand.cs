/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/10/2014
 * Time: 11:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pluginTwo
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTwoSomethingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TwoSomething")]
    public class GetTwoSomethingCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            var testTwo = centralLib.ObjectsFactory.Resolve<ITestTwo>();
            WriteObject(testTwo);
        }
    }
}
