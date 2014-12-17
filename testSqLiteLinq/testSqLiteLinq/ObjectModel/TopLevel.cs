/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/17/2014
 * Time: 9:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSqLiteLinq
{
    using System;
    using System.Data.Linq.Mapping;
    using testSqLiteLinq.Interfaces;
    
    /// <summary>
    /// Description of TopLevel.
    /// </summary>
    [Table(Name = "TopLevels")]
    public class TopLevel : ITopLevel
    {
        [Column(IsPrimaryKey = true)]
        public Guid UniquiId { get; set; }
        [Column]
        public string Id { get; set; }
        [Column]
        public string Name { get; set; }
    }
}
