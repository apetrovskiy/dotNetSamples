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
    using WindowsInput.Native;
    
    /// <summary>
    /// Description of GetInputSimulatorCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "InputSimulator")]
    public class NewInputSimulatorCommand : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject(new InputSimulator());
            var sim = new InputSimulator();
            // sim.Mouse.LeftButtonDoubleClick();
            // sim.Mouse.LeftButtonClick();
            // sim.Mouse.MoveMouseTo(double, double);
            // sim.Mouse.MoveMouseToPositionOnVirtualDesktop(double, double);
            sim.Mouse.HorizontalScroll(int scrollAmountInClicks);
            sim.Mouse.LeftButtonClick();
            sim.Mouse.LeftButtonDoubleClick();
            sim.Mouse.LeftButtonDown();
            sim.Mouse.LeftButtonUp();
            sim.Mouse.MoveMouseBy(int, int);
            sim.Mouse.MoveMouseTo(double, double);
            sim.Mouse.MoveMouseToPositionOnVirtualDesktop(double, double);
            sim.Mouse.RightButtonClick();
            sim.Mouse.RightButtonDoubleClick();
            sim.Mouse.RightButtonDown();
            sim.Mouse.RightButtonUp();
            sim.Mouse.Sleep(int);
            sim.Mouse.Sleep(TimeSpan);
            sim.Mouse.VerticalScroll(int);
            sim.Mouse.XButtonClick(int buttonId);
            sim.Mouse.XButtonDoubleClick(int buttonId);
            sim.Mouse.XButtonDown(int buttonId);
            sim.Mouse.XButtonUp(int buttonId);
            
            // sim.Keyboard.TextEntry(string)
            sim.Keyboard.KeyDown(VirtualKeyCode.VK_G);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_G);
            sim.Keyboard.KeyPress(VirtualKeyCode.VK_A, VirtualKeyCode.VK_B, VirtualKeyCode.VK_C);
            sim.Keyboard.KeyUp(VirtualKeyCode.VK_G);
            sim.Keyboard.ModifiedKeyStroke(new [] { VirtualKeyCode.SHIFT, VirtualKeyCode.CONTROL }, new [] { VirtualKeyCode.VK_G, VirtualKeyCode.VK_F });
            sim.Keyboard.ModifiedKeyStroke(new [] { VirtualKeyCode.SHIFT, VirtualKeyCode.CONTROL }, VirtualKeyCode.VK_F);
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, new [] { VirtualKeyCode.VK_G, VirtualKeyCode.VK_F });
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_F);
            sim.Keyboard.Sleep(1000);
            // sim.Keyboard.Sleep(timespan);
            sim.Keyboard.TextEntry("aaaaaaaaaaaa");
            sim.Keyboard.TextEntry('b');
        }
    }
}
