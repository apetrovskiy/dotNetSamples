/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/4/2014
 * Time: 11:15 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
    using System;
	using Nancy;
    
    /// <summary>
    /// Description of BadgeModule.
    /// </summary>
    public class BadgeModule : NancyModule
    {
        public BadgeModule() : base("/Badges")
        {
            // http://localhost:12345/Badges/99
            Get["/{id}"] = parameter => { return GetById(parameter.id); };
        }
        
        private object GetById(int id)
        {
            // fake a return
            return new { Id = id, Title = "Site Admin", Level = 2 };
        }
    }
}
