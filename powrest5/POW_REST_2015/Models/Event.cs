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
    
    public partial class Event
    {
        public int ID { get; set; }
        public int ActivityID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public Nullable<int> Month { get; set; }
        public Nullable<int> Day { get; set; }
        public string ProjectID { get; set; }
        public string Creator { get; set; }
        public string Created_By { get; set; }
        public string Team { get; set; }
        public string Program { get; set; }
        public string CreatorID { get; set; }
        public string Participants { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string AM { get; set; }
        public Nullable<int> Time { get; set; }
        public string Duration { get; set; }
        public string County { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string appointment { get; set; }
    }
}
