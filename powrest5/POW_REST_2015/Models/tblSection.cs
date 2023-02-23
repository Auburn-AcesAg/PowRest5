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
    
    public partial class tblSection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSection()
        {
            this.tblRows = new HashSet<tblRow>();
        }
    
        public int ID { get; set; }
        public Nullable<int> SummaryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Audience { get; set; }
        public string IsUsed { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string Type { get; set; }
        public string LeadPerson { get; set; }
        public string Instructors { get; set; }
        public string ProposedDate { get; set; }
        public string ProposedLoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRow> tblRows { get; set; }
        public virtual tblSummary tblSummary { get; set; }
    }
}
