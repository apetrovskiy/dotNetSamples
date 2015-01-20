/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/24/2014
 * Time: 3:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testL2S.Mapping
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    
    /// <summary>
    /// Description of Changes.
    /// </summary>
    [Table]
    public class Changes
    {
        [Column]
        public int ProductId { get; set; }
        [Column]
        public int SessionId { get; set; }
        [Column]
        public string ObjectPath { get; set; }
    }
}
