/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/18/2014
 * Time: 10:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub3
{
    using System.Management.Automation;
    using System.Windows.Automation;
    using UIAutomation;
    using NSubstitute;
    
    /// <summary>
    /// Description of NewNSubCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "NSub")]
    public class NewNSubCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            var element = Substitute.For<IUiElement>();
            element.Current.Name.Returns("nnn");
            element.Current.AutomationId.Returns("auId");
            element.Current.ControlType.Returns(ControlType.Button);
            element.GetSupportedPatterns().Returns(new object[] { typeof(IInvokePattern), typeof(IValuePattern), typeof(ITableItemPattern) });
            WriteObject(element);
        }
    }
}
