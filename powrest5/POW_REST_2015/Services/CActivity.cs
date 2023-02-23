using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CActivity
    {
        public int ows_ID { get; set; }
        public string ows_Title { get; set; }
        public string ows_ProjectID { get; set; }
        public Nullable<System.DateTime> ows_StartDate { get; set; }
        public Nullable<System.DateTime> ows_EndDate { get; set; }
        public string ows_Year { get; set; }
        public string ows_IsUsed { get; set; }
        public string ows_Event { get; set; }
        public string ows_Recurrence { get; set; }
        public string ows_UpdateMode { get; set; }
        public string ows_Creator { get; set; }
        public string ows_CreatorID { get; set; }
        public string ows_Participants { get; set; }
        public string ows_Team { get; set; }
        public string ows_Program { get; set; }
        public string ows_StartTime { get; set; }
        public string ows_Duration { get; set; }
        public string ows_IsPublic { get; set; }
        public string ows_County { get; set; }
        public string ows_IsOutlook { get; set; }
        public string ows_Address { get; set; }
        public string ows_Fee { get; set; }
        public string ows_Phone { get; set; }
        public string ows_Url { get; set; }
        public string ows_Description { get; set; }
        public string ows_ContactName { get; set; }
        public string ows_ContactEmail { get; set; }
        public string ows_AnnounceCounty { get; set; }

        public string ows_Address2        { get; set; }
	    public string ows_State           { get; set; }
	    public string ows_City            { get; set; }
	    public string ows_Zipcode         { get; set; }
	    public bool?  ows_IsRegistration  { get; set; }
	    public bool?  ows_IsFee           { get; set; }
        public string ows_Foap            { get; set; }
        public string ows_RegistrationURL { get; set; }
        public bool?  ows_CourseFull      { get; set; }

        public bool? ows_IsAcknowledged { get; set; }
        public Nullable<int> ows_AttendeeLimit { get; set; }
        public string ows_TaxableMaterials { get; set; }

        public Nullable<System.DateTime> ows_Modified { get; set; }

        // 11/22/2019
        public string ows_IsRegistration2 { get; set; }

        // 4/1/2020
        public string ows_SocialType { get; set; }
        public string ows_SocialURL { get; set; }
        
        // 7/12/2021
        public bool? ows_IsZoomAuto { get; set; } 
    }

    public class CActivity2
    {
        public int ID { get; set; }
        public string Title { get; set; }   
        public string CreatorID { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public bool IsAttandance { get; set; }
        public string ProjectID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Participants { get; set; }

    }
}