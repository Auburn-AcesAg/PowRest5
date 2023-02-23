using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CEvent
    {
        private string creatorID;
        private string participants; 

        public int ows_ID { get; set; }
        public string ows_Title { get; set; }
        public Nullable<int> ows_ActivityID { get; set; }
        public string ows_Year { get; set; }
        public Nullable<int> ows_Month { get; set; }
        public Nullable<int> ows_Day { get; set; }
        public string ows_CreatorID { get { return creatorID.ToLower(); } set { creatorID = value; } }
        public string ows_Creator { get; set; }
        public string ows_Hour { get; set; }
        public string ows_Minute { get; set; }
        public string ows_AM { get; set; }
        public Nullable<int> ows_Time { get; set; }
        public string ows_Duration { get; set; }
        public string ows_County { get; set; }
        public string ows_Participants { get { return participants == null ?  participants : participants.ToLower(); } set { participants = value; } }
        public string ows_ProjectID { get; set; }
    }

    public class CEventDate
    {
        public string ows_AM { get; set; }
        public Nullable<System.DateTime> ows_Date { get; set; }
        public string ows_Hour { get; set; }
        public Nullable<int> ows_ID { get; set; }
        public string ows_Minute { get; set; }        
    }
}