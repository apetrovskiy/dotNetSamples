/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/24/2014
 * Time: 3:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testL2S.Mapping
{
    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    
    /// <summary>
    /// Description of Events.
    /// </summary>
    [Table(Name = "Events")]
    public class Events
    {
        [Column(IsPrimaryKey = true, Name = "Event_PK")]
        public int Event_Pk { get; set; }
        [Column(Name = "Session_Ref")]
        public int Session_Ref { get; set; }
        
        [Column(Name = "Computer_Name_Current")]
        public string Computer_Name_Current { get; set; }
        [Column(Name = "OS_Type")]
        public int OS_Type { get; set; }
        [Column(Name = "OS_VersionMajor")]
        public int OS_VersionMajor { get; set; }
        [Column(Name = "OS_VersionMinor")]
        public int OS_VersionMinor { get; set; }
        [Column(Name = "Log_Name")]
        public string Log_Name { get; set; }
        [Column(Name = "Record_ID")]
        public int Record_ID { get; set; }
        [Column(Name = "Computer_Name")]
        public string Computer_Name { get; set; }
        [Column(Name = "User_Name")]
        public string User_Name { get; set; }
        [Column(Name = "User_Domain")]
        public string User_Domain { get; set; }
        [Column(Name = "Event_Level")]
        public int Event_Level { get; set; }
        [Column(Name = "Event_Source")]
        public string Event_Source { get; set; }
        [Column(Name = "Event_ID")]
        public int Event_ID { get; set; }
        [Column(Name = "Event_Category")]
        public string Event_Category { get; set; }
        [Column(Name = "UTC_Time")]
        public DateTime UTC_Time { get; set; }
        [Column(Name = "Local_Time")]
        public DateTime Local_Time { get; set; }
        [Column(Name = "Opcode")]
        public int Opcode { get; set; }
        [Column(Name = "Keywords")]
        public string Keywords { get; set; }
        [Column(Name = "Version")]
        public int Version { get; set; }
        [Column(Name = "Qualifiers")]
        public int Qualifiers { get; set; }
        [Column(Name = "ActivityID")]
        public string ActivityID { get; set; }
        [Column(Name = "Level")]
        public int Level { get; set; }
        [Column(Name = "RelatedActivityID")]
        public string RelatedActivityID { get; set; }
    }
}
