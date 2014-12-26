/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/24/2014
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testL2S
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using testL2S.Mapping;
    
    /// <summary>
    /// Description of MyContext.
    /// </summary>
    [Database(Name = "Netwrix_Auditor_Event_Log")]
    public class MyContext : DataContext
    {
        public MyContext(string connection) : base(connection) {}
        public Table<Events> Events;
    }
}
