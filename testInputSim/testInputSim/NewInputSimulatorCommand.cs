/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/17/2014
 * Time: 1:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInputSim
{
    using System;
    using System.Management.Automation;
    using WindowsInput;
    
    /// <summary>
    /// Description of GetInputSimulatorCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "InputSimulator")]
    public class NewInputSimulatorCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject(new InputSimulator());
        }
    }
}
