//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Extension_2017.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityProject
    {
        public int ID { get; set; }
        public Nullable<int> ActivityID { get; set; }
        public Nullable<int> PlanID { get; set; }
        public string IsUsed { get; set; }
        public string ProjectTitle { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string Year { get; set; }
    }
}
