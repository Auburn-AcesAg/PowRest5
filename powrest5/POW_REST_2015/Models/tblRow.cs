//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POW_REST_2015.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRow
    {
        public int ID { get; set; }
        public Nullable<int> SectionID { get; set; }
        public string LeadPerson { get; set; }
        public string Instructors { get; set; }
        public Nullable<System.DateTime> ProposedDate { get; set; }
        public string ProposedLoc { get; set; }
        public string ActualDate { get; set; }
        public string ActualLoc { get; set; }
        public string County { get; set; }
        public string IsUsed { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
    
        public virtual tblSection tblSection { get; set; }
    }
}
