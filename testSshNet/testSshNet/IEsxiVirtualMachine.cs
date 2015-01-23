/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/23/2015
 * Time: 4:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSshNet
{
    using System;
    
    /// <summary>
    /// Description of IEsxiVirtualMachine.
    /// </summary>
    public interface IEsxiVirtualMachine
    {
        int Id { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        string GuestOperatingSystem { get; set; }
        string Version { get; set; }
        string Annotation { get; set; }
    }
}
