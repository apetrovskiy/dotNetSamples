/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/17/2014
 * Time: 9:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSqLiteLinq.Interfaces
{
    using System;
    
    /// <summary>
    /// Description of ILowLevel.
    /// </summary>
    public interface ILowLevel
    {
        Guid UniquiId { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        Guid TopLevelUniqueId { get; set; }
        Guid MidLevelUniqueId { get; set; }
    }
}
