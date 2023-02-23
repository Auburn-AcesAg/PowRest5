using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.SqlClient;


namespace POW_REST_2015.Services
{
    public class ActivityRepository
    {
        private CommonRepository commonRepository = new CommonRepository();

        public List<CActivity> getActivity(int id)
        {
            var context = new Models.PowEntities2();

            var q = from a in context.Activities.Where(a => a.ID == id)
                    select new CActivity
                    {
                        ows_ID = a.ID,
                        ows_Title = a.Title,
                        ows_ProjectID = a.ProjectID,
                        ows_StartDate = a.StartDate,
                        ows_EndDate = a.EndDate,
                        ows_Year = a.Year,
                        ows_IsUsed = a.IsUsed,
                        ows_Event = a.Event,
                        ows_Recurrence = a.Recurrence,
                        ows_UpdateMode = a.UpdateMode,
                        ows_Creator = a.Creator,
                        ows_CreatorID = a.CreatorID,
                        ows_Participants = a.Participants,
                        ows_Team = a.Team,
                        ows_Program = a.Program,
                        ows_StartTime = a.StartTime,
                        ows_Duration = a.Duration,
                        ows_IsPublic = a.IsPublic,
                        ows_County = a.County,
                        ows_IsOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                        ows_Address = a.Address == null ? "" : a.Address,
                        ows_Fee = a.Fee == null ? "" : a.Fee,
                        ows_Phone = a.Phone == null ? "" : a.Phone,
                        ows_Url = a.URL == null ? "" : a.URL,
                        ows_Description = a.description == null ? "" : a.description,
                        ows_ContactName = a.ContactName == null ? "" : a.ContactName,
                        ows_ContactEmail = a.ContactEmail == null ? "" : a.ContactEmail,
                        ows_AnnounceCounty = a.AnnounceCounty == null ? "" : a.AnnounceCounty,

                        ows_Address2 = a.Address2 == null ? "" : a.Address2,
                        ows_State = a.State == null ? "" : a.State,
                        ows_City = a.City == null ? "" : a.City,
                        ows_Zipcode = a.ZipCode == null ? "" : a.ZipCode,
                        ows_IsRegistration = a.IsRegistration == null ? false : a.IsRegistration,
                        ows_IsFee = a.IsFee == null ? false : a.IsFee,
                        ows_Foap = a.Foap == null ? "" : a.Foap,
                        ows_RegistrationURL = a.RegistrationURL == null ? "" : a.RegistrationURL,
                        ows_CourseFull = a.CourseFull == null ? false : a.CourseFull,

                        ows_IsAcknowledged = a.IsAcknowledged == null ? false : a.IsAcknowledged,
                        ows_AttendeeLimit = a.AttendeeLimit == null ? 0 : a.AttendeeLimit,
                        ows_TaxableMaterials = a.TaxableMaterials == null ? "" : a.TaxableMaterials,

                        ows_IsRegistration2 = a.IsRegistration2 == null ? "" : a.IsRegistration2,

                        ows_SocialType = a.SocialType == null ? "" : a.SocialType,
                        ows_SocialURL = a.SocialURL == null ? "" : a.SocialURL,

                        ows_IsZoomAuto = a.IsZoomAuto == null ? false : a.IsZoomAuto
                    };

            return q.ToList();
        }

        public List<CActivity> getActivities()
        {
            var context = new Models.PowEntities2();

            /*select * from Activity a where a.isused = 'Yes' and a.ProjectID != '' and a.id in ( select distinct(activityid) from Events )*/

            var activityids = (from e in context.Events select e.ActivityID).Distinct();

            var q = from a in context.Activities.Where(a => a.ProjectID != "" && a.IsUsed == "Yes" & a.ProjectID != null
                                                      && activityids.Contains(a.ID)).OrderBy(a => a.ID)
                    //var q = from a in context.Activities.Where(a => a.ProjectID != "" && a.IsUsed == "Yes").OrderBy(a => a.ID)
                    select new CActivity
                    {
                        ows_ID = a.ID,
                        ows_Title = a.Title,
                        ows_ProjectID = a.ProjectID,
                        ows_StartDate = a.StartDate,
                        ows_EndDate = a.EndDate,
                        ows_Year = a.Year,
                        ows_IsUsed = a.IsUsed,
                        ows_Event = a.Event,
                        ows_Recurrence = a.Recurrence,
                        ows_UpdateMode = a.UpdateMode,
                        ows_Creator = a.Creator,
                        ows_CreatorID = a.CreatorID,
                        ows_Participants = a.Participants,
                        ows_Team = a.Team,
                        ows_Program = a.Program,
                        ows_StartTime = a.StartTime,
                        ows_Duration = a.Duration,
                        ows_IsPublic = a.IsPublic,
                        ows_County = a.County,
                        ows_Modified = a.Modified,
                        ows_IsOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                        ows_Address = a.Address == null ? "" : a.Address,
                        ows_Fee = a.Fee == null ? "" : a.Fee,
                        ows_Phone = a.Phone == null ? "" : a.Phone,
                        ows_Url = a.URL == null ? "" : a.URL,
                        ows_Description = a.description == null ? "" : a.description,
                        ows_ContactName = a.ContactName == null ? "" : a.ContactName,
                        ows_ContactEmail = a.ContactEmail == null ? "" : a.ContactEmail,
                        ows_AnnounceCounty = a.AnnounceCounty == null ? "" : a.AnnounceCounty,

                        ows_Address2 = a.Address2 == null ? "" : a.Address2,
                        ows_State = a.State == null ? "" : a.State,
                        ows_City = a.City == null ? "" : a.City,
                        ows_Zipcode = a.ZipCode == null ? "" : a.ZipCode,
                        ows_IsRegistration = a.IsRegistration == null ? false : a.IsRegistration,
                        ows_IsFee = a.IsFee == null ? false : a.IsFee,
                        ows_Foap = a.Foap == null ? "" : a.Foap,
                        ows_RegistrationURL = a.RegistrationURL == null ? "" : a.RegistrationURL,
                        ows_CourseFull = a.CourseFull == null ? false : a.CourseFull,

                        ows_IsRegistration2 = a.IsRegistration2 == null ? "" : a.IsRegistration2,

                        ows_SocialType = a.SocialType == null ? "" : a.SocialType,
                        ows_SocialURL = a.SocialURL == null ? "" : a.SocialURL
                    };

            return q.ToList();
        }

        public List<CActivity> getActivities(string year)
        {
            var context = new Models.PowEntities2();

            /*select * from Activity a where a.isused = 'Yes' and a.ProjectID != '' and a.id in ( select distinct(activityid) from Events )*/

            var activityids = (from e in context.Events select e.ActivityID).Distinct();

            var q = (from a in context.Activities
                     where a.ProjectID != "" && a.IsUsed == "Yes" & a.ProjectID != null && a.Year == year
                         && activityids.Contains(a.ID)
                     select a).OrderBy(a => a.ID).ToList();

            List < CActivity > activities = new List<CActivity>();
            foreach(var a in q)
            {
                var activity = new CActivity
                {
                    ows_ID = a.ID,
                    ows_Title = a.Title,
                    ows_ProjectID = a.ProjectID,
                    ows_StartDate = a.StartDate,
                    ows_EndDate = a.EndDate,
                    ows_Year = a.Year,
                    ows_IsUsed = a.IsUsed,
                    ows_Event = a.Event,
                    ows_Recurrence = a.Recurrence,
                    ows_UpdateMode = a.UpdateMode,
                    ows_Creator = a.Creator,
                    ows_CreatorID = a.CreatorID,
                    ows_Participants = a.Participants,
                    ows_Team = a.Team,
                    ows_Program = a.Program,
                    ows_StartTime = a.StartTime,
                    ows_Duration = a.Duration,
                    ows_IsPublic = a.IsPublic,
                    ows_County = a.County,
                    ows_Modified = a.Modified,
                    ows_IsOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                    ows_Address = a.Address == null ? "" : a.Address,
                    ows_Fee = a.Fee == null ? "" : a.Fee,
                    ows_Phone = a.Phone == null ? "" : a.Phone,
                    ows_Url = a.URL == null ? "" : a.URL,
                    ows_Description = a.description == null ? "" : a.description,
                    ows_ContactName = a.ContactName == null ? "" : a.ContactName,
                    ows_ContactEmail = a.ContactEmail == null ? "" : a.ContactEmail,
                    ows_AnnounceCounty = a.AnnounceCounty == null ? "" : commonRepository.ConvertSetCounty(a.AnnounceCounty),

                    ows_Address2 = a.Address2 == null ? "" : a.Address2,
                    ows_State = a.State == null ? "" : a.State,
                    ows_City = a.City == null ? "" : a.City,
                    ows_Zipcode = a.ZipCode == null ? "" : a.ZipCode,
                    ows_IsRegistration = a.IsRegistration == null ? false : a.IsRegistration,
                    ows_IsFee = a.IsFee == null ? false : a.IsFee,
                    ows_Foap = a.Foap == null ? "" : a.Foap,
                    ows_RegistrationURL = a.RegistrationURL == null ? "" : a.RegistrationURL,
                    ows_CourseFull = a.CourseFull == null ? false : a.CourseFull,

                    ows_IsRegistration2 = a.IsRegistration2 == null ? "" : a.IsRegistration2,

                    ows_SocialType = a.SocialType == null ? "" : a.SocialType,
                    ows_SocialURL = a.SocialURL == null ? "" : a.SocialURL


                };

                activities.Add(activity);
            }
             
            return activities.ToList();
        }

        public List<CActivity> getActivities(string year, int limit, int page)
        {
            var context = new Models.PowEntities2();

            /*select * from Activity a where a.isused = 'Yes' and a.ProjectID != '' and a.id in ( select distinct(activityid) from Events )*/

            var activityids = (from e in context.Events select e.ActivityID).Distinct();

            // Block test activities 
            var q = (from a in context.Activities where a.ProjectID != "" && a.IsUsed == "Yes" & a.ProjectID != null && a.Year == year && a.CreatorID != "jzs0015"
                                                       && activityids.Contains(a.ID) select a).OrderBy(a => a.ID).ToList();

            List<CActivity> activities = new List<CActivity>();
            foreach (var a in q)
            {
                var activity = new CActivity
                {
                    ows_ID = a.ID,
                    ows_Title = a.Title,
                    ows_ProjectID = a.ProjectID,
                    ows_StartDate = a.StartDate,
                    ows_EndDate = a.EndDate,
                    ows_Year = a.Year,
                    ows_IsUsed = a.IsUsed,
                    ows_Event = a.Event,
                    ows_Recurrence = a.Recurrence,
                    ows_UpdateMode = a.UpdateMode,
                    ows_Creator = a.Creator,
                    ows_CreatorID = a.CreatorID,
                    ows_Participants = a.Participants,
                    ows_Team = a.Team,
                    ows_Program = a.Program,
                    ows_StartTime = a.StartTime,
                    ows_Duration = a.Duration,
                    ows_IsPublic = a.IsPublic,
                    ows_County = a.County,
                    ows_Modified = a.Modified,
                    ows_IsOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                    ows_Address = a.Address == null ? "" : a.Address,
                    ows_Fee = a.Fee == null ? "" : a.Fee,
                    ows_Phone = a.Phone == null ? "" : a.Phone,
                    ows_Url = a.URL == null ? "" : a.URL,
                    ows_Description = a.description == null ? "" : a.description,
                    ows_ContactName = a.ContactName == null ? "" : a.ContactName,
                    ows_ContactEmail = a.ContactEmail == null ? "" : a.ContactEmail,
                    ows_AnnounceCounty = a.AnnounceCounty == null ? "" : commonRepository.ConvertSetCounty(a.AnnounceCounty),

                    ows_Address2 = a.Address2 == null ? "" : a.Address2,
                    ows_State = a.State == null ? "" : a.State,
                    ows_City = a.City == null ? "" : a.City,
                    ows_Zipcode = a.ZipCode == null ? "" : a.ZipCode,
                    ows_IsRegistration = a.IsRegistration == null ? false : a.IsRegistration,
                    ows_IsFee = a.IsFee == null ? false : a.IsFee,
                    ows_Foap = a.Foap == null ? "" : a.Foap,
                    ows_RegistrationURL = a.RegistrationURL == null ? "" : a.RegistrationURL,
                    ows_CourseFull = a.CourseFull == null ? false : a.CourseFull,

                    ows_IsRegistration2 = a.IsRegistration2 == null ? "" : a.IsRegistration2,

                    ows_SocialType = a.SocialType == null ? "" : a.SocialType,
                    ows_SocialURL = a.SocialURL == null ? "" : a.SocialURL
                };

                activities.Add(activity);
            }

            return activities.Skip(limit * (page - 1)).Take(limit).ToList();     
        }

        public CActivity2 getRecentActivity(string year, string userid)
        {
            var context = new Models.PowEntities2();

            userid = userid.ToLower();

            var q = (from c in context.TransactionLogs where c.UserID.ToLower() == userid 
                     && c.Year == year
                     orderby c.Modified descending select c).ToList();

            int? eventid = q.First().EventID;

            if( 1 >= eventid)
            {
                CActivity2 a = new CActivity2();
                a.ID = 0;
                a.Title = "";
                a.ProjectID = (eventid == 0) ? "" : "IP-";
                a.CreatorID = "";
                a.UserName = (from c in context.PowUsers where c.Name.Contains(userid) select c.Title).FirstOrDefault();
                a.Participants = "";

                return a;
            }
            else
            {
                int activityid = (from c in context.Events where c.ID == eventid select c.ActivityID).FirstOrDefault();

                var d = from a in context.Activities.Where(a => a.ID == activityid)
                        select new CActivity2
                        {
                            ID = a.ID,
                            CreatorID = a.CreatorID.ToLower(),
                            Title = a.Title,
                            ProjectID = a.ProjectID,
                            Modified = a.Modified,
                            IsAttandance = (from c in context.Contacts
                                            where c.IsUsed == "Yes" && c.Year == year && c.ContactType.ToLower() == "Activity" && c.ActivityID == activityid
                                            select c).ToList().Count > 0 ? true : false,
                            UserName = (from c in context.PowUsers where c.Name.Contains(userid) select c.Title).FirstOrDefault(),
                            StartDate = a.StartDate,
                            Participants = a.Participants
                        };

                return d.FirstOrDefault();
            }           
        }
    }
}