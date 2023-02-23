using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extension_2017.Models;
using System.Globalization;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.IO;

namespace Extension_2017.Providers
{
    public class CUserInfo
    {
        public string picUrl { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public string jobTitle { get; set; }
        public string department { get; set; }
    }

    public class CReport
    {
        public string creatorId { get; set; }
        public string creator { get; set; }
        public int id { get; set; }
        public string contactType { get; set; }
        public string year { get; set; }
        public int activityId { get; set; }
        public string userid { get; set; }
        public string title { get; set; }
        //public string county { get; set; }
        public string[] counties { get; set; }
        public int multistate { get; set; }
        //  public Gender gender {get; set;}
        //  public Age age { get; set; }

        public Rural rural { get; set; }
        public Urban urban { get; set; }

        public Rural mrural { get; set; }
        public Urban murban { get; set; }

        public string activity { get; set; }
        public string OutcomeShort { get; set; }
        public string OutcomeLong { get; set; }
        public string ExternalFactors { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public string program { get; set; }

        public List<CFileLink> fileLinks { get; set; }

        public string createdDate { get; set; }

        public CReport()
        {
            //gender = new Gender();
        }

        public int? version { get; set; }
    }

    public class Gender
    {
        public int maleR { get; set; }
        public int maleU { get; set; }
        public int femaleR { get; set; }
        public int femaleU { get; set; }
    }

    public class Age
    {
        public int adultR { get; set; }
        public int adultU { get; set; }
        public int youthR { get; set; }
        public int youthU { get; set; }
    }

    public class CFileLink
    {
        public string link { get; set; }
        public string name { get; set; }
    }

    public class Participants
    {
        public int male { get; set; }
        public int female { get; set; }
        public int adult { get; set; }
        public int youth { get; set; }
        public int white { get; set; }
        public int black { get; set; }
        public int asian { get; set; }
        public int native { get; set; }
        public int hispanic { get; set; }
        public int other { get; set; }
        public int multi { get; set; }
        public int nonhispanic { get; set; }
    }

    public class Rural : Participants
    {
    }

    public class Urban : Participants
    {
    }

    public class CActivity
    {
        public string id { get; set; }
        public string title { get; set; }
        public string[] projectID { get; set; }
        public string strStartdate { get; set; }
        public string strEnddate { get; set; }
        public string year { get; set; }
        public string isUsed { get; set; }
        public string eventtype { get; set; }
        public string recurrence { get; set; }
        public string updateMode { get; set; }
        public string creatorID { get; set; }
        public string[] participants { get; set; }
        public string team { get; set; }
        public string program { get; set; }
        public string starttime { get; set; }
        public string duration { get; set; }
        public string isPublic { get; set; }
        public string county { get; set; }
        public string isOutlook { get; set; }
        public string address { get; set; }
        public string fee { get; set; }
        public string phone { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string contactname { get; set; }
        public string contactemail { get; set; }
        public string[] announcecounty { get; set; }
        public string activityType { get; set; }
        public string createdDate { get; set; }

        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Nullable<bool> IsRegistration { get; set; }
        public Nullable<bool> IsFee { get; set; }
        public string Foap { get; set; }
        public string RegistrationURL { get; set; }
        public Nullable<bool> CourseFull { get; set; }
        public Nullable<bool> IsAcknowledged { get; set; }
        public Nullable<int> AttendeeLimit { get; set; }
        public string TaxableMaterials { get; set; }
    }


    public class CProject
    {
        public int ows_ID { get; set; }
        public string ows_UID { get; set; }
        public string ows_PlanType { get; set; }
        public string ows_Creator { get; set; }
        public string ows_CreatorName { get; set; }
        public string ows_CreatorID { get; set; }
        public string ows_Team { get; set; }
        public List<string> ows_AdditionalTeams { get; set; }
        public string ows_Program { get; set; }
        public string ows_Project { get; set; }
        public string ows_Objectives { get; set; }
        public string ows_Outputs { get; set; }
        public string ows_Outcomes { get; set; }
        public string ows_When { get; set; }
        public string ows_Where { get; set; }
        public string ows_Evaluation { get; set; }
        public string ows_IsCompleted { get; set; }
        public string ows_IsUsed { get; set; }
        public string ows_Year { get; set; }
        public string ows_ProjectType { get; set; }

        public string ows_LeadPersonID { get; set; }
        public string ows_County { get; set; }
        public string ows_Engagement { get; set; }
        public string ows_Responsibility { get; set; }
        public string ows_TeamCodes { get; set; }
        public string ows_Instructors { get; set; }
        public Nullable<System.DateTime> ows_Modified { get; set; }
        public string ows_Editor { get; set; }

        public string ows_AdditionalTeamsString
        {
            get
            {
                string s = "";
                int value;

                if (int.TryParse(ows_Year, out value))
                {
                    if (Convert.ToInt32(ows_Year) >= 2015)
                    {
                        if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                        {
                            foreach (string i in ows_AdditionalTeams)
                            {
                                if (s == "")
                                    s = i;
                                else
                                    s = s + ";" + i;
                            }
                        }
                    }
                    else
                    {
                        if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                        {
                            s = ows_AdditionalTeams[0];
                        }
                    }
                }
                else
                {
                    if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                    {
                        s = ows_AdditionalTeams[0];
                    }
                }

                return s;

            }
            set
            {

            }
        }

        public string ows_InstructorsName
        {
            get
            {
                string s = "";

                if (ows_Instructors != null && ows_Instructors != "")
                {
                    using (PowEntities context = new PowEntities())
                    {
                        string[] instructors = ows_Instructors.Split(';');

                        foreach (string i in instructors)
                        {
                            if (i.Trim() != "")
                            {
                                // s = s + (from c in context.PowUsers where c.Name == i select c.Title).FirstOrDefault() + "; ";
                                string name = ((from b in context.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault() == null) ?
                                                 (from b in context.StaffDirectories where i.ToLower().Contains(b.UserID) select b.FirstName + " " + b.LastName).FirstOrDefault()
                                                   : (from b in context.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault();

                                if (s != "") s = s + "; " + name;
                                else s = name;
                            }
                        }
                    }
                }

                return s;
            }

            set
            {

            }
        }

        public string ows_LeadPerson
        {
            get
            {
                string s = "";

                if (ows_LeadPersonID != null && ows_LeadPersonID != "")
                {
                    using (PowEntities context = new PowEntities())
                    {
                        string[] leadpersons = ows_LeadPersonID.Split(';');

                        foreach (string i in leadpersons)
                        {
                            if (i.Trim() != "")
                            {
                                string name = ((from b in context.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault() == null) ?
                                                  (from b in context.StaffDirectories where i.ToLower().Contains(b.UserID) select b.FirstName + " " + b.LastName).FirstOrDefault()
                                                    : (from b in context.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault();

                                if (s != "") s = s + "; " + name;
                                else s = name;
                            }
                        }
                    }
                }

                return s;
            }

            set
            {

            }

        }
    }

    public class ProjectActivity
    {
        public int id { get; set; }
        public int activityid { get; set; }
        public string projectid { get; set; }
        public string isUsed { get; set; }
        public string projectTitle { get; set; }
        public string year { get; set; }
    }

    public class CActivityProject
    {
        public int ows_ID { get; set; }
        public int? ows_ActivityID { get; set; }
        public int? ows_PlanID { get; set; }
        public string ows_IsUsed { get; set; }

        public string ows_PlanType { get; set; }
        public string ows_Team { get; set; }
        public List<string> ows_AdditionalTeams { get; set; }

        public string ows_Program { get; set; }
        public string ows_Project { get; set; }
        public string ows_Outcomes { get; set; }
        public string ows_UID { get; set; }
        public string ows_LeadPersonID { get; set; }

        public string ows_Creator { get; set; }
        public string ows_CreatorName
        {
            get
            {
                if (ows_Creator.Contains('#'))
                {
                    return ows_Creator.Substring(ows_Creator.IndexOf('#') + 1, ows_Creator.Length - (ows_Creator.IndexOf('#') + 1));
                }
                else
                {
                    return ows_Creator;
                }
            }
            set
            {

            }
        }
        public string ows_CreatorID { get; set; }


        public string ows_County { get; set; }
        public string ows_TeamCodes { get; set; }
        public string ows_IsCompleted { get; set; }
        public Nullable<System.DateTime> ows_Modified { get; set; }

        public string ows_Year { get; set; }

        public string ows_AdditionalTeamsString
        {
            get
            {
                string s = "";

                if (ows_Year == "2015")
                {
                    if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                    {
                        foreach (string i in ows_AdditionalTeams)
                        {
                            if (s == "")
                                s = i;
                            else
                                s = s + ";" + i;
                        }
                    }
                }
                else
                {
                    if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                    {
                        s = ows_AdditionalTeams[0];
                    }
                }

                return s;

            }
            set
            {

            }

        }

        public string ows_LeadPerson
        {
            get
            {
                string s = "";

                if (ows_LeadPersonID != null && ows_LeadPersonID != "")
                {
                    using (PowEntities entity = new PowEntities())
                    {
                        string[] leadpersons = ows_LeadPersonID.Split(';');

                        foreach (string i in leadpersons)
                        {
                            if (i.Trim() != "")
                            {
                                string name = ((from b in entity.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault() == null) ?
                                                  (from b in entity.StaffDirectories where i.ToLower().Contains(b.UserID) select b.FirstName + " " + b.LastName).FirstOrDefault()
                                                    : (from b in entity.PowUsers where b.Name.Contains(i) select b.Title).FirstOrDefault();

                                if (s != "") s = s + "; " + name;
                                else s = name;
                            }
                        }
                    }
                }

                return s;
            }

            set
            {

            }

        }
    }

    public class CMedia
    {
        public int id { get; set; }        
        public string creatorId { get; set; }
        public string creator { get; set; }
        public string program { get; set; }
        public string year { get; set; }
        public int month { get; set; }
        public string[] counties { get; set; }               
        public string modified { get; set; }
        public string isUsed { get; set; }
        public List<CFileLink> fileLinks { get; set; }
    }

    public class CMediaEvent
    {
        public int id { get; set; }
        public int mediaId { get; set; }
        public string creatorId { get; set; }
        public string mediaTypeId { get; set; }       
        public DateTime modified { get; set; }
        public string isUsed { get; set; }
        public string year { get; set; }

        public string eventTitle { get; set; }
        public string eventDate { get; set; }      

        public string eventName { get; set; } // Newspaper Name, Station Name
        public string eventTime { get; set; } // air time
        public string eventType { get; set; } // facebook, Twitter, ...
        public string recipients { get; set; }
        public string[] counties { get; set; }
    }

    public class CEvent
    {
        public int ID { get; set; }
        public string CreatorID { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string County { get; set; }
        public int? time { get; set; }
        public string Creator { get; set; }
        //public bool IsReported { get; set; }
        public int ReportID { get; set; }

    }


    public class CDb
    {
        public CDb()
        {
        }

        private string RunScript(string scriptText)
        {
            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();
            //   runspace.SessionStateProxy.SetVariable("DemoForm", this);

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.

            pipeline.Commands.Add("Out-String");

            // execute the script

            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString().Replace("\r\n", "");
        }

        public CUserInfo GetUserInfo(string userid)
        {
            try
            {
                CUserInfo u = new CUserInfo();

                /*
                string filePath = "C:\\files\\Directory\\directory.txt";
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                userid = userid.ToLower();

                bool bFind = false;
                string imagefilename = "200_261_notfound.jpg";
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Split(' ');
                    if (arr[0] == userid)
                    {
                        imagefilename = arr[1];
                        bFind = true;
                    }
                }

                u.picUrl = "https://ssl.acesag.auburn.edu/directory-pictures/versions/" + userid + "/" + imagefilename;
                */

                using (PowEntities entity = new PowEntities())
                {
                    var user = (from c in entity.StaffDirectories where c.UserID == userid select c).FirstOrDefault();
                    if (user != null)
                    {
                        u.username = user.FirstName + " " + user.LastName;
                        u.jobTitle = user.JobTitle;
                        u.picUrl = user.StaffPicture;
                        u.department = user.Department;
                    }

                }

                u.userid = userid;

                return u;

            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }


        public List<Year> GetYears()
        {
            using (PowEntities entity = new PowEntities())
            {
                return (from c in entity.Years where c.IsUsed == "Y" select c).ToList();
            }
        }


        public List<CProject> GetMyProjects(string userID, string type, string year)
        {

            using (PowEntities context = new PowEntities())
            {
                userID = (!userID.Contains('@')) ? userID.ToLower() : userID.Substring(0, userID.IndexOf('@')).ToLower();

                if (type.ToLower() == "team")
                {

                    return (from a in context.Projects
                            where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType && (a.CreatorID.ToLower().Contains(userID) || a.LeadPersonID.ToLower().Contains(userID))
                            orderby a.ID
                            select new CProject
                            {
                                ows_ID = a.ID,
                                ows_PlanType = a.PlanType,
                                ows_Project = a.ProjectTitle,
                                ows_IsCompleted = a.IsCompleted,
                                ows_Team = (from b in context.Teams where b.UID == a.Team select b.Title).FirstOrDefault(),
                                ows_Program = (from b in context.Programs where b.UID == a.Program select b.Title).FirstOrDefault(),
                                ows_Year = a.Year,
                                ows_UID = a.UID,
                                ows_LeadPersonID = a.LeadPersonID,
                                ows_LeadPerson = ""
                            }).ToList();
                }
                else
                {
                    return (from a in context.Projects
                            where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType && (a.CreatorID.ToLower().Contains(userID))
                            orderby a.ID
                            select new CProject
                            {
                                ows_ID = a.ID,
                                ows_PlanType = a.PlanType,
                                ows_Project = a.ProjectTitle,
                                ows_IsCompleted = a.IsCompleted,
                                ows_Team = (from b in context.Teams where b.UID == a.Team select b.Title).FirstOrDefault(),
                                ows_Program = (from b in context.Programs where b.UID == a.Program select b.Title).FirstOrDefault(),
                                ows_Year = a.Year,
                                ows_UID = a.UID,
                                ows_LeadPersonID = a.LeadPersonID,
                                ows_LeadPerson = ""
                            }).ToList();
                }
            }

        }



        public List<CProject> GetProjects(string year, string type, string team, string program)
        {
            string teamYear = (Convert.ToInt32(year) > 2017) ? year : "2017";

            if (type.Contains("Unplanned") && team.Contains("Unplanned") && (program == null || program == ""))
                return null;

            if (team != null && team.Contains("Unplanned"))
            {
                type = "Unplanned";
            }

            if ((team == null || team == "") && (program == null || program == ""))
                return null;

            using (PowEntities context = new PowEntities())
            {
                if (team != null && team.ToString().Length == 2)
                {
                    team = (team == null) ? "" : team;
                }
                else
                {
                    team = (team == null) ? "" : (from t in context.Teams where t.Title.Contains(team) && t.Year == teamYear select t.UID).FirstOrDefault();
                }


                if (program != null && program.ToString().Length == 2)
                {
                    program = (program == null) ? "" : program;
                }
                else
                {
                    program = (program == null) ? "" : (from p in context.Programs where p.Title == program && p.Year == teamYear select p.UID).FirstOrDefault();
                }


                return (from a in context.Projects
                        where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType && a.Program.Contains(program)
                                && (a.Team.Contains(team) || (from b in context.AdditionalTeams where b.TeamUID == team & b.IsUsed == "Yes" select b.ProjectID).Contains(a.ID))
                        select new CProject
                        {
                            ows_ID = a.ID,
                            ows_PlanType = a.PlanType,
                            ows_Project = a.ProjectTitle,
                            ows_LeadPersonID = a.LeadPersonID,
                            ows_LeadPerson = "",
                            ows_IsCompleted = a.IsCompleted,
                            ows_ProjectType = a.ProjectType,
                            ows_Team = (from b in context.Teams where b.UID == a.Team select b.Title).FirstOrDefault(),
                            ows_Program = (from b in context.Programs where b.UID == a.Program select b.Title).FirstOrDefault(),
                            ows_Year = a.Year,
                            ows_UID = a.UID
                        }).ToList();
            }

        }

        public int CreateProject(string ID, string PlanType, string Project, string Team, string AdditionalTeams, string Program,
                                  string ProjectType, string County, string Engagement, string Responsibility, string IsCompleted,
                                  string Objectives, string Outputs, string Outcomes, string When, string Where, string Evaluation,
                                  string CreatorID, string LeadPersonID, string Instructors, string UID, string year = "2015")
        {
            using (PowEntities entity = new PowEntities())
            {
                try
                {
                    year = (year == "" || year == null) ? "2015" : year;

                    string teamYear = Convert.ToInt32(year) > 2017 ? year : "2017";

                    int nID = 0;

                    #region Create
                    if (ID == null || ID == "")
                    {
                        var myteam = (Team.Length == 2) ? Team : (from b in entity.Teams where b.Title == Team && b.Year == teamYear select b.UID).FirstOrDefault();

                        if (myteam == null)
                        {
                            string t = (from b in entity.Teams where b.Title == Team select b.UID).FirstOrDefault();

                            switch (t)
                            {
                                case "4H": Team = "AH"; break;
                                case "FW": Team = "FN"; break;
                                case "AC": Team = "AG"; break;
                                case "AR": Team = "AQ"; break;
                                case "AS": Team = "AF"; break;
                                case "CH": Team = "CO"; break;
                                case "CS": Team = "FD"; break;
                                case "EC": Team = "ED"; break;
                                case "FC": Team = "FD"; break;
                                case "FM": Team = "FA"; break;
                                case "FS": Team = "FQ"; break;
                                case "HG": Team = "HO"; break;
                                case "HN": Team = "HD"; break;
                                case "PO": Team = "PS"; break;
                                case "UP": Team = "UN"; break;
                            }
                        }
                        else
                        {
                            Team = myteam;
                        }

                        Program = (Program.Length == 2) ? Program : (from b in entity.Programs where b.Title == Program && b.Year == teamYear select b.UID).FirstOrDefault();

                        if (PlanType == "Team" || PlanType == "Unplanned" || PlanType == "Impromptu")
                        {
                            var common = (from c in entity.commons select c).First();
                            int? uid = common.TeamUID + 1;
                            common.TeamUID = uid;
                            entity.SaveChanges();

                            string strUID = Team + "-" + Program + "-" + "0" + uid.ToString();
                            string leadpersonId = LeadPersonID.Replace(";;", ";");


                            Project p = new Project
                            {
                                UID = strUID,
                                PlanType = PlanType,
                                ProjectTitle = Project,
                                Team = Team,
                                Program = Program,
                                ProjectType = ProjectType,
                                County = County,
                                Engagement = Engagement,
                                Responsibility = Responsibility,
                                IsCompleted = IsCompleted,
                                Objectives = Objectives,
                                Outputs = Outputs,
                                Outcomes = Outcomes,
                                When = When,
                                Where = Where,
                                Evaluation = Evaluation,
                                CreatorID = CreatorID,
                                LeadPersonID = leadpersonId,
                                Instructors = Instructors,
                                Year = year,
                                IsUsed = "Yes",
                                Modified = DateTime.Now,
                                Modified_By = CreatorID,
                                Creator = (from u in entity.PowUsers where u.Email.ToLower().Contains(CreatorID.ToLower()) select u.ID + ";#" + u.Title).FirstOrDefault()
                            };
                            entity.Projects.Add(p);
                            entity.SaveChanges();

                            createAdditionalTeams(p.ID, AdditionalTeams, year);
                            nID = p.ID;
                        }
                        else
                        {
                            string leadpersonId = LeadPersonID.Replace(";;", ";");

                            Project p = new Project
                            {
                                UID = UID,
                                PlanType = PlanType,
                                ProjectTitle = Project,
                                Team = Team,
                                Program = Program,
                                ProjectType = ProjectType,
                                County = County,
                                Engagement = Engagement,
                                Responsibility = Responsibility,
                                IsCompleted = IsCompleted,
                                Objectives = Objectives,
                                Outputs = Outputs,
                                Outcomes = Outcomes,
                                When = When,
                                Where = Where,
                                Evaluation = Evaluation,
                                CreatorID = CreatorID,
                                LeadPersonID = leadpersonId,
                                Instructors = Instructors,
                                Year = year,
                                IsUsed = "Yes",
                                Modified = DateTime.Now,
                                Modified_By = CreatorID,
                                Creator = (from u in entity.PowUsers where u.Email.ToLower().Contains(CreatorID.ToLower()) select u.ID + ";#" + u.Title).FirstOrDefault()
                            };
                            entity.Projects.Add(p);
                            entity.SaveChanges();

                            createAdditionalTeams(p.ID, AdditionalTeams, year);
                            nID = p.ID;
                        }

                    }
                    #endregion Create
                    #region update
                    else
                    {
                        nID = Convert.ToInt32(ID);

                        string leadpersonId = LeadPersonID.Replace(";;", ";");

                        var p = (from c in entity.Projects where c.ID == nID select c).First();

                        if (PlanType == "Team" || PlanType == "Unplanned")
                        {
                            if (p != null)
                            {
                                if (p.ProjectTitle != Project) p.ProjectTitle = Project;
                                if (p.ProjectType != ProjectType) p.ProjectType = ProjectType;
                                if (p.County != County) p.County = County;
                                if (p.Engagement != Engagement) p.Engagement = Engagement;
                                if (p.Responsibility != Responsibility) p.Responsibility = Responsibility;
                                if (p.IsCompleted != IsCompleted) p.IsCompleted = IsCompleted;
                                if (p.Objectives != Objectives) p.Objectives = Objectives;
                                if (p.Outputs != Outputs) p.Outputs = Outputs;
                                if (p.Outcomes != Outcomes) p.Outcomes = Outcomes;
                                if (p.When != When) p.When = When;
                                if (p.Where != Where) p.Where = Where;
                                if (p.Evaluation != Evaluation) p.Evaluation = Evaluation;
                                if (p.LeadPersonID != LeadPersonID) p.LeadPersonID = leadpersonId;
                                if (p.Instructors != Instructors) p.Instructors = Instructors;
                                p.Modified = DateTime.Now;
                                p.Modified_By = CreatorID;

                                entity.SaveChanges();

                                updateAdditionalTeams(p.ID, AdditionalTeams);
                            }
                        }
                        else
                        {
                            if (p != null)
                            {
                                if (p.County != County) p.County = County;
                                if (p.Engagement != Engagement) p.Engagement = Engagement;
                                if (p.IsCompleted != IsCompleted) p.IsCompleted = IsCompleted;
                                if (p.When != When) p.When = When;
                                if (p.Where != Where) p.Where = Where;
                                p.Modified = DateTime.Now;
                                p.Modified_By = CreatorID;

                                entity.SaveChanges();

                                updateAdditionalTeams(p.ID, AdditionalTeams);
                            }
                        }
                    }
                    #endregion update

                    return nID;
                }
                catch (Exception e)
                {
                    CLog.WriteToEventLog(e.ToString());
                    return 0;
                }
            }
        }

        public void createAdditionalTeams(int ProjectID, string additionalTeams, string year = "2017")
        {
            using (PowEntities entity = new PowEntities())
            {
                if (additionalTeams != null && additionalTeams != "")
                {
                    string[] teams = additionalTeams.Split(';');

                    foreach (string t in teams)
                    {
                        if (t != null && t != "")
                        {
                            string team = findmyteam(t, year);
                            AdditionalTeam at = new AdditionalTeam
                            {
                                ProjectID = ProjectID,
                                //TeamUID = (from b in dc.Teams where b.Title == t && b.Year == year select b.UID).FirstOrDefault(),
                                TeamUID = team,
                                Modified = DateTime.Now,
                                IsUsed = "Yes"
                            };
                            entity.AdditionalTeams.Add(at);
                            entity.SaveChanges();
                        }

                    }
                }
            }
        }

        public string findmyteam(string Team, string year)
        {
            using (PowEntities entity = new PowEntities())
            {
                var myteam = (Team.Length == 2) ? Team : (from b in entity.Teams where b.Title == Team && b.Year == year select b.UID).FirstOrDefault();

                if (myteam == null)
                {
                    string t = (from b in entity.Teams where b.Title == Team select b.UID).FirstOrDefault();

                    switch (t)
                    {
                        case "4H": Team = "AH"; break;
                        case "FW": Team = "FN"; break;
                        case "AC": Team = "AG"; break;
                        case "AR": Team = "AQ"; break;
                        case "AS": Team = "AF"; break;
                        case "CH": Team = "CO"; break;
                        case "CS": Team = "FD"; break;
                        case "EC": Team = "ED"; break;
                        case "FC": Team = "FD"; break;
                        case "FM": Team = "FA"; break;
                        case "FS": Team = "FQ"; break;
                        case "HG": Team = "HO"; break;
                        case "HN": Team = "HD"; break;
                        case "PO": Team = "PS"; break;
                        case "UP": Team = "UN"; break;
                    }
                }
                else
                {
                    Team = myteam;
                }
                return Team;
            }
        }

        public void updateAdditionalTeams(int ProjectID, string additionalTeams)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.AdditionalTeams where c.ProjectID == ProjectID select c).ToList();

                foreach (AdditionalTeam a in p)
                {
                    a.IsUsed = "No";
                    a.Modified = DateTime.Now;
                }
                entity.SaveChanges();

                if (additionalTeams != null && additionalTeams != "")
                {
                    string[] teams = additionalTeams.Split(';');

                    foreach (string t in teams)
                    {
                        if (t != null && t != "")
                        {
                            var TeamUID = (from b in entity.Teams where b.Title == t select b.UID).FirstOrDefault();
                            var a = (from c in entity.AdditionalTeams where c.ProjectID == ProjectID && c.TeamUID == TeamUID select c).FirstOrDefault();

                            if (a == null)
                            {
                                AdditionalTeam at = new AdditionalTeam
                                {
                                    ProjectID = ProjectID,
                                    TeamUID = (from b in entity.Teams where b.Title == t select b.UID).FirstOrDefault(),
                                    Modified = DateTime.Now,
                                    IsUsed = "Yes"
                                };
                                entity.AdditionalTeams.Add(at);
                            }
                            else
                            {
                                a.IsUsed = "Yes";
                                a.Modified = DateTime.Now;
                            }
                            entity.SaveChanges();
                        }

                    }
                }
            }
        }

        public List<CEvent> GetActivities(string year, int month, int day)
        {
            using (PowEntities entity = new PowEntities())
            {  
                var p = (from a in entity.Activities
                         join e in entity.Events on a.ID equals e.ActivityID                        
                         where a.IsUsed == "Yes" & a.Year == year & e.Year == year & e.Month == month & e.Day == day & a.ProjectID != "" 
                         select e).ToList();

                List<CEvent> events = new List<CEvent>();

                foreach (Event e in p)
                {
                    CEvent e1 = new CEvent();
                    e1.ID = e.ActivityID;
                    e1.Title = e.Title;
                    e1.County = e.County;
                    e1.CreatorID = e.CreatorID;
                    e1.StartTime = e.Hour + ":" + e.Minute + ":" + e.AM;
                    e1.time = e.Time;
                    e1.Creator = e.Creator;                    

                    events.Add(e1);
                }

                return events.OrderBy(a => a.time).ToList();

              //  return p.OrderBy(a => DateTime.ParseExact(a.StartTime, "hh:mm:tt", CultureInfo.InvariantCulture)).ToList();
            }
        }

        public List<CEvent> GetActivities2(string year, int month, int day)
        {
            using (PowEntities entity = new PowEntities())
            {
                /* 1/14/2019 June Shin add IsAttandees*/
                var p = (from a in entity.Activities
                         join e in entity.Events on a.ID equals e.ActivityID
                         where a.IsUsed == "Yes" & a.Year == year & e.Year == year & e.Month == month & e.Day == day & a.ProjectID != ""
                         select e).ToList();

                List<CEvent> events = new List<CEvent>();

                foreach (Event e in p)
                {
                    CEvent e1 = new CEvent();
                    e1.ID = e.ActivityID;
                    e1.Title = e.Title;
                    e1.County = e.County;
                    e1.CreatorID = e.CreatorID;
                    e1.StartTime = e.Hour + ":" + e.Minute + ":" + e.AM;
                    e1.time = e.Time;
                    e1.Creator = e.Creator;
                    //e1.IsReported = (from c in entity.Contacts where c.IsUsed == "Yes" & c.ActivityID == e.ActivityID select c).FirstOrDefault() == null ? false : true;
                    e1.ReportID = (from c in entity.Contacts where c.IsUsed == "Yes" & c.ActivityID == e.ActivityID select c.ID).FirstOrDefault();

                    events.Add(e1);
                }

                return events.OrderBy(a => a.time).ToList();

                //  return p.OrderBy(a => DateTime.ParseExact(a.StartTime, "hh:mm:tt", CultureInfo.InvariantCulture)).ToList();
            }
        }


        public List<Activity> GetActivities(string year, int month)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from a in entity.Activities
                         join e in entity.Events on a.ID equals e.ActivityID
                         where a.IsUsed == "Yes" & e.Year == year & e.Month == month
                         orderby e.Day
                         select a).ToList();
                return p;
            }
        }

        public List<CActivity> GetMyActivities(string userid, string year)
        {
            try
            {
                using (PowEntities entity = new PowEntities())
                {
                    var activityids = (from e in entity.Events select e.ActivityID).Distinct();

                    var activities = (from a in entity.Activities.Where(a => a.ProjectID != "" && a.IsUsed == "Yes" & a.ProjectID != null && a.Year == year && a.CreatorID.Contains(userid)
                                                              && activityids.Contains(a.ID)).OrderBy(a => a.ID)
                                      select a).ToList();

                    List<CActivity> myActivities = new List<CActivity>();

                    foreach (Activity a in activities)
                    {
                        CActivity activity = new CActivity
                        {
                            id = a.ID.ToString(),
                            title = a.Title,
                            strStartdate = ((DateTime)a.StartDate).ToShortDateString(),
                            strEnddate = ((DateTime)a.EndDate).ToShortDateString(),
                            year = a.Year,
                            isUsed = a.IsUsed,
                            eventtype = a.Event,
                            recurrence = a.Recurrence,
                            updateMode = a.UpdateMode,
                            //creator = a.Creator,
                            creatorID = a.CreatorID,
                            //participants = a.Participants.Split(';'),
                            team = a.Team,
                            program = a.Program,
                            starttime = a.StartTime,
                            duration = a.Duration,
                            isPublic = a.IsPublic,
                            county = a.County,
                            isOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                            address = a.Address == null ? "" : a.Address,
                            fee = a.Fee == null ? "" : a.Fee,
                            phone = a.Phone == null ? "" : a.Phone,
                            url = a.URL == null ? "" : a.URL,
                            description = a.description == null ? "" : a.description,
                            contactname = a.ContactName == null ? "" : a.ContactName,
                            contactemail = a.ContactEmail == null ? "" : a.ContactEmail,
                            activityType = a.ProjectID.Contains("IP-") ? "Impromptu" : "Planned",
                            createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy h:mm:ss tt"),
                            
                            // 6/10/2019
                            Address2 = a.Address2,
                            State = a.State,
                            City = a.City,
                            ZipCode = a.ZipCode,
                            IsRegistration = a.IsRegistration,
                            IsFee = a.IsFee,
                            Foap = a.Foap,
                            IsAcknowledged = a.IsAcknowledged,
                            AttendeeLimit = a.AttendeeLimit,
                            TaxableMaterials = a.TaxableMaterials
                        };

                        var projectids = a.ProjectID.Split(';');
                        activity.projectID = (from c in projectids where c.Trim() != "" select c).ToArray();

                        activity.announcecounty = a.AnnounceCounty == null ? null : (from c in a.AnnounceCounty.Split(';') where c.Trim() != "" select c).ToArray();

                        /* 2018-01-31T00:00:00T11:00:AM */
                        activity.recurrence = activity.recurrence.Replace("T00:00:00T", "T");                                             

                        string[] ms = a.Participants.Split(';');
                        List<string> ms1 = new List<string>();
                        foreach (string m in ms)
                        {
                            if (m.Trim() == "") continue;
                            var m2 = getUserName(m) + " (" + m + ")";
                            ms1.Add(m2);
                        }
                        activity.participants = ms1.ToArray();
                        myActivities.Add(activity);
                    }

                    return myActivities;
                }
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }

        /* add for activity detail */
        public CActivity GetActivity(int id)
        {
            try
            {
                using (PowEntities entity = new PowEntities())
                {
                    // var activityids = (from e in entity.Events select e.ActivityID).Distinct();

                    var a = (from b in entity.Activities where b.ID == id select b).FirstOrDefault();

                    //List < CActivity > myActivities = new List<CActivity>();

                    if(a != null)
                    {
                        CActivity activity = new CActivity
                        {
                            id = a.ID.ToString(),
                            title = a.Title,
                            strStartdate = ((DateTime)a.StartDate).ToShortDateString(),
                            strEnddate = ((DateTime)a.EndDate).ToShortDateString(),
                            year = a.Year,
                            isUsed = a.IsUsed,
                            eventtype = a.Event,
                            recurrence = a.Recurrence,
                            updateMode = a.UpdateMode,
                            //creator = a.Creator,
                            creatorID = a.CreatorID,
                            //participants = a.Participants.Split(';'),
                            team = a.Team,
                            program = a.Program,
                            starttime = a.StartTime,
                            duration = a.Duration,
                            isPublic = a.IsPublic,
                            county = a.County,
                            isOutlook = (a.Appointment == "" || a.Appointment == null) ? "No" : "Yes",
                            address = a.Address == null ? "" : a.Address,
                            fee = a.Fee == null ? "" : a.Fee,
                            phone = a.Phone == null ? "" : a.Phone,
                            url = a.URL == null ? "" : a.URL,
                            description = a.description == null ? "" : a.description,
                            contactname = a.ContactName == null ? "" : a.ContactName,
                            contactemail = a.ContactEmail == null ? "" : a.ContactEmail,
                            activityType = a.ProjectID.Contains("IP-") ? "Impromptu" : "Planned",
                            createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy h:mm:ss tt"),

                            // 6/6/2019
                            Address2          = a.Address2         ,     
                            State             = a.State            ,
                            City              = a.City             ,
                            ZipCode           = a.ZipCode          ,
                            IsRegistration    = a.IsRegistration   ,
                            IsFee             = a.IsFee            ,
                            Foap              = a.Foap             ,            
                            IsAcknowledged    = a.IsAcknowledged   ,
                            AttendeeLimit     = a.AttendeeLimit    ,
                            TaxableMaterials  = a.TaxableMaterials
                        };

                        var projectids = a.ProjectID.Split(';');
                        activity.projectID = (from c in projectids where c.Trim() != "" select c).ToArray();

                        activity.announcecounty = a.AnnounceCounty == null ? null : (from c in a.AnnounceCounty.Split(';') where c.Trim() != "" select c).ToArray();

                        /* 2018-01-31T00:00:00T11:00:AM */
                        activity.recurrence = activity.recurrence.Replace("T00:00:00T", "T");

                        string[] ms = a.Participants.Split(';');
                        List<string> ms1 = new List<string>();
                        foreach (string m in ms)
                        {
                            if (m.Trim() == "") continue;
                            var m2 = getUserName(m) + " (" + m + ")";
                            ms1.Add(m2);
                        }
                        activity.participants = ms1.ToArray();

                        return activity;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }


        public string getUserName(string userid)
        {
            using (PowEntities entity = new PowEntities())
            {
                userid = userid.ToLower();
                return (from c in entity.StaffDirectories where c.UserID == userid select c.FirstName + " " + c.LastName).FirstOrDefault();
            }
        }

        public string SetActivity(string id, string title, string[] projectID, DateTime startdate, DateTime enddate, string year,
                                string isUsed, string eventtype, string recurrence, string updateMode, string creatorID, string[] participants,
                                string team, string program, string starttime, string duration, string isPublic, string county, string isOutlook,
                                string address, string fee, string phone, string url, string description, string contactname, string contactemail, string[] announcecounty,
                                string Address2, string State, string City, string ZipCode, bool? IsRegistration, bool? IsFee, string Foap, bool? IsAcknowledged, int? AttendeeLimit, string TaxableMaterials
                                )
        {
            string ActivityID = "";

            using (PowEntities entity = new PowEntities())
            {
                try
                {
                    string tempProjects = "";

                    if (projectID.Count() > 0)
                    {
                        foreach (string c in projectID)
                        {
                            tempProjects = tempProjects + c + ";";
                        }
                    }

                    string tempAnCounties = "";
                    if (isPublic == "Yes")
                    {
                        foreach (string c in announcecounty)
                        {
                            tempAnCounties = tempAnCounties + c + ";";
                        }
                    }

                    string tempParticipants = "";
                    foreach (string c in participants)
                    {
                        var d = c.Split('(', ')')[1];

                        tempParticipants = tempParticipants + d + ";";
                    }

                    // Create Activity
                    #region
                    if (id.Equals(""))
                    {
                        var users = from u in entity.PowUsers where u.Email.ToLower().Contains(creatorID.ToLower()) select u;
                        string creator_1 = "";

                        foreach (PowUser pu in users)
                        {
                            creator_1 = pu.ID.ToString() + ";#" + pu.Title;
                        }

                        if (starttime != null)
                        {
                            String[] arr = starttime.Split(':');
                            if (arr[0] != null && arr[0].Length == 1)                             
                            {
                                arr[0] = "0" + arr[0];
                                starttime = arr[0] + ":" + arr[1] + ":" + arr[2];
                            }
                        }

                        Activity activity = new Activity
                        {
                            Title = title,
                            ProjectID = tempProjects,
                            StartDate = startdate,
                            EndDate = enddate,
                            Year = year,
                            IsUsed = isUsed,
                            Event = eventtype,
                            Recurrence = recurrence,
                            UpdateMode = updateMode,
                            Creator = creator_1,
                            CreatorID = creatorID,
                            Participants = tempParticipants,
                            Team = team,
                            Program = program,
                            StartTime = starttime,
                            Duration = duration,
                            IsPublic = isPublic,
                            County = county,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            Appointment = (isOutlook == "Yes") ? "Created" : null,
                            Address = address,
                            Fee = fee,
                            Phone = phone,
                            URL = url,
                            description = description,
                            ContactName = contactname,
                            ContactEmail = contactemail,
                            AnnounceCounty = tempAnCounties,

                            Address2 = Address2,
                            State = State,
                            City = City,
                            ZipCode = ZipCode,
                            IsRegistration = IsRegistration == null ? false : IsRegistration,
                            IsFee = IsFee == null ? false : IsFee,
                            Foap = Foap,
                            IsAcknowledged = IsAcknowledged == null ? false : IsAcknowledged,
                            AttendeeLimit = AttendeeLimit == null ? 0 : AttendeeLimit,
                            TaxableMaterials = TaxableMaterials
                        };

                        entity.Activities.Add(activity);
                        entity.SaveChanges();
                        ActivityID = activity.ID.ToString();

                        DateTime dt = createEvents(activity);

                        if (eventtype == "Arbitrary")
                        {
                            //var a = from c in dc.Activities where c.ID == ActivityID select c;
                            activity.StartDate = dt;
                            activity.EndDate = dt;
                            entity.SaveChanges();
                        }

                        CreateParticipants(activity.ID, participants);

                        /*
                        CLog.WriteToEventLog("Success(Create1)" + DateTime.Now + " ID:" + id + " Title:" + title + " ProjectID:" + projectID + " StartDate: " + startdate
                                   + " EndDate:" + enddate + " Year:" + year
                                   + " IsUsed:" + isUsed + " EventType:" + eventtype + " Recurrence:" + recurrence + " UpdateMode:" + updateMode
                                   + " CreatorID:" + creatorID + " Participants:" + participants
                                   + " Team:" + team + " Program:" + program + " StartTime:" + starttime + " Duration:" + duration
                                   + " IsPublic:" + isPublic + " County:" + county + " Address:" + address + " Fee:" + fee + " Phone:" + phone + " URL:" + url + " description:" + description
                                   + " contactName:" + contactname + " contactEmail:" + contactemail + " announceCounty:" + announcecounty);
                        */
                        CLog.WriteToEventLog("Activity Created : ID " + activity.ID);
                    }
                    #endregion
                    // Update Activity
                    #region
                    else
                    {
                        int nId = Int32.Parse(id);
                        var activity = from c in entity.Activities where c.ID == nId select c;

                        // Delete Events
                        if (isUsed.ToLower().Equals("no"))
                        {
                            foreach (Activity a in activity)
                            {
                                a.IsUsed = isUsed;
                                a.Appointment = (isOutlook == "Yes") ? "Deleted" : null;
                                a.Modified = DateTime.Now;
                                deleteEvents(a.ID);
                            }
                            entity.SaveChanges();

                            DeleteParticipants(Int32.Parse(id));

                            CLog.WriteToEventLog("Activity Deleted : ID " + id);
                            /*
                            CLog.WriteToEventLog("Success(Delete)" + DateTime.Now + " ID:" + id + " Title:" + title + " ProjectID:" + projectID + " StartDate: " + startdate
                                 + " EndDate:" + enddate + " Year:" + year
                                 + " IsUsed:" + isUsed + " EventType:" + eventtype + " Recurrence:" + recurrence + " UpdateMode:" + updateMode
                                 + " CreatorID:" + creatorID + " Participants:" + participants
                                 + " Team:" + team + " Program:" + program + " StartTime:" + starttime + " Duration:" + duration + " IsOutlook:" + isOutlook
                                 + " IsPublic:" + isPublic + " County:" + county + " Address:" + address + " Fee:" + fee + " Phone:" + phone + " URL:" + url + " description:" + description
                                 + " contactName:" + contactname + " contactEmail:" + contactemail + " announceCounty:" + announcecounty);
                            */

                            return id;
                        }

                        if (updateMode.Trim().ToLower().Contains("event")) // event changed. 
                        {
                            foreach (Activity a in activity)
                            {
                                if (a.Event != eventtype || a.Recurrence != recurrence || a.StartDate != startdate || a.EndDate != enddate || a.StartTime != starttime)
                                {
                                    if (eventtype == "Arbitrary" && eventtype == a.Event && a.Recurrence != recurrence && a.Title == title && a.Participants == tempParticipants && a.Duration == duration && a.County == county)
                                        a.Appointment = (isOutlook == "Yes") ? "Updated-DateAdded" : null;
                                    else
                                        a.Appointment = (isOutlook == "Yes") ? "Updated" : null;

                                    if (a.Participants != tempParticipants)
                                        CreateParticipants(a.ID, participants);

                                    a.Event = eventtype;
                                    a.Recurrence = recurrence;
                                    a.StartDate = startdate;
                                    a.EndDate = enddate;
                                    a.Title = title;
                                    //a.ProjectID = projectID;
                                    a.ProjectID = tempProjects;
                                    a.Year = year;
                                    a.IsUsed = isUsed;
                                    a.UpdateMode = updateMode;
                                    a.CreatorID = creatorID;
                                    a.Participants = tempParticipants;
                                    a.Team = team;
                                    a.Program = program;
                                    a.StartTime = starttime;
                                    a.Duration = duration;
                                    a.IsPublic = isPublic;
                                    a.County = county;
                                    a.Modified = DateTime.Now;
                                    a.Address = address;
                                    a.Fee = fee;
                                    a.Phone = phone;
                                    a.URL = url;
                                    a.description = description;
                                    a.ContactName = contactname;
                                    a.ContactEmail = contactemail;
                                    //a.AnnounceCounty = announcecounty;                                    
                                    a.AnnounceCounty = tempAnCounties;

                                    DateTime dt = createEvents(a);
                                    if (eventtype == "Arbitrary")
                                    {
                                        a.StartDate = dt;
                                        a.EndDate = dt;
                                    }

                                    a.Address2 = Address2;
                                    a.State = State;
                                    a.City = City;
                                    a.ZipCode = ZipCode;
                                    a.IsRegistration = IsRegistration == null ? false : IsRegistration;
                                    a.IsFee = IsFee == null ? false : IsFee;
                                    a.Foap = Foap;
                                    a.IsAcknowledged = IsAcknowledged == null ? false : IsAcknowledged;
                                    a.AttendeeLimit = AttendeeLimit == null ? 0 : AttendeeLimit;
                                    a.TaxableMaterials = TaxableMaterials;
                                }
                                else
                                {
                                    if (a.Title != title || a.Participants != tempParticipants || a.County != county || a.Duration != duration || (isOutlook == "Yes" && a.Appointment == null))
                                        a.Appointment = (isOutlook == "Yes") ? "Updated" : null;

                                    if (a.Participants != tempParticipants)
                                        CreateParticipants(a.ID, participants);

                                    if (a.Title != title || a.Participants != tempParticipants || a.Duration != duration || a.County != county)
                                    {
                                        var events = from e in entity.Events where e.ActivityID == a.ID select e;
                                        foreach (Event e in events)
                                        {
                                            e.Title = title;
                                            e.ProjectID = tempProjects;
                                            e.Duration = duration;
                                            e.Participants = tempParticipants;
                                            e.County = county;
                                            e.Team = team;
                                            e.Program = program;
                                            e.Modified = DateTime.Now;
                                        }
                                    }

                                    a.Title = title;
                                    a.Participants = tempParticipants;
                                    a.County = county;
                                    a.ProjectID = tempProjects;
                                    a.Year = year;
                                    a.IsUsed = isUsed;
                                    a.UpdateMode = updateMode;
                                    a.CreatorID = creatorID;
                                    a.Team = team;
                                    a.Program = program;
                                    a.IsPublic = isPublic;
                                    a.Modified = DateTime.Now;
                                    a.Address = address;
                                    a.Fee = fee;
                                    a.Phone = phone;
                                    a.URL = url;
                                    a.description = description;
                                    a.ContactName = contactname;
                                    a.ContactEmail = contactemail;
                                    //a.AnnounceCounty = announcecounty;                                
                                    a.AnnounceCounty = tempAnCounties;


                                    a.Address2 = Address2;
                                    a.State = State;
                                    a.City = City;
                                    a.ZipCode = ZipCode;
                                    a.IsRegistration = IsRegistration == null ? false : IsRegistration;
                                    a.IsFee = IsFee == null ? false : IsFee;
                                    a.Foap = Foap;
                                    a.IsAcknowledged = IsAcknowledged == null ? false : IsAcknowledged;
                                    a.AttendeeLimit = AttendeeLimit == null ? 0 : AttendeeLimit;
                                    a.TaxableMaterials = TaxableMaterials;
                                }
                            }

                            entity.SaveChanges();
                        }
                        else // Project changed
                        {
                            foreach (Activity a in activity)
                            {
                                a.UpdateMode = updateMode;
                                a.ProjectID = tempProjects;
                                a.Team = team;
                                a.Program = program;
                                a.Modified = DateTime.Now;

                                var events = from e in entity.Events where e.ActivityID == a.ID select e;
                                foreach (Event e in events)
                                {
                                    e.ProjectID = tempProjects;
                                    e.Team = team;
                                    e.Program = program;
                                    e.Modified = DateTime.Now;
                                }
                            }
                            entity.SaveChanges();
                        }

                        CLog.WriteToEventLog("Activity Updated : ID " + id);

                        /*
                        CLog.WriteToEventLog("Success(Update)" + DateTime.Now + " ID:" + id + " Title:" + title + " ProjectID:" + projectID + " StartDate: " + startdate
                                 + " EndDate:" + enddate + " Year:" + year
                                 + " IsUsed:" + isUsed + " EventType:" + eventtype + " Recurrence:" + recurrence + " UpdateMode:" + updateMode
                                 + " CreatorID:" + creatorID + " Participants:" + participants
                                 + " Team:" + team + " Program:" + program + " StartTime:" + starttime + " Duration:" + duration + " IsOutlook:" + isOutlook
                                 + " IsPublic:" + isPublic + " County:" + county + " Address:" + address + " Fee:" + fee + " Phone:" + phone + " URL:" + url + " description:" + description
                                 + " contactName:" + contactname + " contactEmail:" + contactemail + " announceCounty:" + announcecounty);
                        */

                        ActivityID = id;
                    }
                    #endregion
                }
                catch (Exception e)
                {
                    CLog.WriteToEventLog(e.ToString() + " ID:" + id + " Title:" + title + " ProjectID:" + projectID + " StartDate: " + startdate
                                    + " EndDate:" + enddate + " Year:" + year
                                    + " IsUsed:" + isUsed + " EventType:" + eventtype + " Recurrence:" + recurrence + " UpdateMode:" + updateMode
                                    + " CreatorID:" + creatorID + " Participants:" + participants
                                    + " Team:" + team + " Program:" + program + " StartTime:" + starttime + " Duration:" + duration + " IsOutlook:" + isOutlook
                                    + " IsPublic:" + isPublic + " County:" + county + " Address:" + address + " Fee:" + fee + " Phone:" + phone + " URL:" + url + " description:" + description
                                    + " contactName:" + contactname + " contactEmail:" + contactemail + " announceCounty:" + announcecounty);

                    return "";
                }

                return ActivityID;
            }
        }

        private void deleteEvents(int activityId)
        {
            using (PowEntities entity = new PowEntities())
            {
                var events = from e in entity.Events where e.ActivityID == activityId select e;
                foreach (Event e in events)
                {
                    entity.Events.Remove(e);
                }
                entity.SaveChanges();
            }
        }

        private void DeleteParticipants(int activityid)
        {
            using (PowEntities entity = new PowEntities())
            {
                List<Participant> pList = (from c in entity.Participants where c.ActivityID == activityid select c).ToList();

                foreach (Participant p in pList)
                {
                    p.IsUsed = "N";
                    entity.SaveChanges();
                }
            }
        }

        private void CreateParticipants(int activityid, string[] particpants)
        {

            DeleteParticipants(activityid);

            // string[] strarr = particpants.Split(';');         

            using (PowEntities entity = new PowEntities())
            {
                foreach (string s in particpants)
                {
                    if (s.Trim() != "")
                    {
                        string userid = s.Replace("i:0#.w|auburn\\", "").ToLower();

                        Participant p = (from c in entity.Participants where c.ActivityID == activityid && c.UserID == userid select c).FirstOrDefault();

                        if (p == null)
                        {
                            Participant p1 = new Participant();
                            p1.IsUsed = "Y";
                            p1.IsSent = "N";
                            p1.UserID = userid;
                            p1.ActivityID = activityid;

                            entity.Participants.Add(p1);
                            entity.SaveChanges();
                        }
                        else
                        {
                            if (p.IsUsed == "N")
                            {
                                p.IsUsed = "Y";
                                entity.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        private DateTime createEvents(Activity a)
        {
            using (PowEntities entity = new PowEntities())
            {
                deleteEvents(a.ID);

                DateTime ArbitraryStartDate = new DateTime();

                DateTime st = Convert.ToDateTime(a.StartDate);
                DateTime ed = a.EndDate != null ? Convert.ToDateTime(a.EndDate) : DateTime.Now;
                String STime = a.StartTime != null ? a.StartTime.ToString() : "";
                string[] strTime = STime.Split(':');
                int nTime = 0;
                if (strTime[2] == "AM") { nTime = Convert.ToInt32(strTime[0]) * 100 + Convert.ToInt32(strTime[1]); }
                else { nTime = (Convert.ToInt32(strTime[0]) + 12) * 100 + Convert.ToInt32(strTime[1]); }

                if (a.Event == "Oneday")
                {
                    Event e = new Event
                    {
                        Title = a.Title,
                        ActivityID = a.ID,
                        Year = st.Year.ToString(),
                        Month = st.Month,
                        Day = st.Day,
                        Creator = a.Creator,
                        CreatorID = a.CreatorID,
                        ProjectID = a.ProjectID,
                        Team = a.Team,
                        Program = a.Program,
                        Participants = a.Participants,
                        County = a.County,
                        Date = Convert.ToDateTime(st.Year + "-" + st.Month + "-" + st.Day),
                        Hour = strTime[0],
                        Minute = strTime[1],
                        AM = strTime[2],
                        Time = nTime,
                        Duration = a.Duration,
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    };

                    entity.Events.Add(e);
                }
                else if (a.Event == "Daily")
                {

                    DateTime st1 = Convert.ToDateTime(st.Year + "-" + st.Month + "-" + st.Day);

                    TimeSpan ts = ed - st1;
                    int diffDay = 0;
                    diffDay = ts.Days;

                    for (int i = 0; i <= diffDay; i++)
                    {
                        Event e = new Event
                        {
                            Title = a.Title,
                            ActivityID = a.ID,
                            Year = st1.Year.ToString(),
                            Month = st1.Month,
                            Day = st1.Day,
                            Creator = a.Creator,
                            CreatorID = a.CreatorID,
                            ProjectID = a.ProjectID,
                            Team = a.Team,
                            Program = a.Program,
                            Participants = a.Participants,
                            County = a.County,
                            Date = Convert.ToDateTime(st1.Year + "-" + st1.Month + "-" + st1.Day),
                            Hour = strTime[0],
                            Minute = strTime[1],
                            AM = strTime[2],
                            Time = nTime,
                            Duration = a.Duration,
                            Created = DateTime.Now,
                            Modified = DateTime.Now
                        };

                        entity.Events.Add(e);
                        st1 = st1.AddDays(1);
                    }
                }
                else if (a.Event == "Weekly" & a.Recurrence != "")
                {
                    TimeSpan ts = ed - st; int diffDay = 0; diffDay = ts.Days + 1;
                    for (int i = 0; i < diffDay; i++)
                    {
                        if (st.DayOfWeek.ToString().ToUpper().StartsWith(a.Recurrence.ToUpper()))
                        {
                            break;
                        }
                        st = st.AddDays(1);
                    }

                    while (st <= ed)
                    {
                        Event e = new Event
                        {
                            Title = a.Title,
                            ActivityID = a.ID,
                            Year = st.Year.ToString(),
                            Month = st.Month,
                            Day = st.Day,
                            Creator = a.Creator,
                            CreatorID = a.CreatorID,
                            ProjectID = a.ProjectID,
                            Team = a.Team,
                            Program = a.Program,
                            Participants = a.Participants,
                            County = a.County,
                            Date = Convert.ToDateTime(st.Year + "-" + st.Month + "-" + st.Day),
                            Hour = strTime[0],
                            Minute = strTime[1],
                            AM = strTime[2],
                            Time = nTime,
                            Duration = a.Duration,
                            Created = DateTime.Now,
                            Modified = DateTime.Now
                        };
                        entity.Events.Add(e);
                        st = st.AddDays(7);
                    }
                }
                else if (a.Event == "Monthly" & a.Recurrence != "")
                {
                    if (a.Recurrence.Contains('|'))
                    {
                        string[] arr = a.Recurrence.Split('|');

                        DateTime newSt = new DateTime(st.Year, st.Month, 1);

                        while (newSt <= ed)
                        {
                            DateTime dt = GetNthWeekdayOfMonth(newSt, Convert.ToInt32(arr[0]), arr[1]);
                            if (dt >= st && dt <= ed)
                            {
                                Event e = new Event
                                {
                                    Title = a.Title,
                                    ActivityID = a.ID,
                                    Year = dt.Year.ToString(),
                                    Month = dt.Month,
                                    Day = dt.Day,
                                    Creator = a.Creator,
                                    CreatorID = a.CreatorID,
                                    ProjectID = a.ProjectID,
                                    Team = a.Team,
                                    Program = a.Program,
                                    Participants = a.Participants,
                                    County = a.County,
                                    Date = Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + dt.Day),
                                    Hour = strTime[0],
                                    Minute = strTime[1],
                                    AM = strTime[2],
                                    Time = nTime,
                                    Duration = a.Duration,
                                    Created = DateTime.Now,
                                    Modified = DateTime.Now
                                };
                                entity.Events.Add(e);
                            }
                            newSt = newSt.AddMonths(1);
                        }

                    }
                    else
                    {
                        int day = Convert.ToInt32(a.Recurrence); if (day < st.Day) { st = st.AddMonths(1); }
                        DateTime newSt = new DateTime(st.Year, st.Month, day);
                        while (newSt <= ed)
                        {
                            Event e = new Event
                            {
                                Title = a.Title,
                                ActivityID = a.ID,
                                Year = newSt.Year.ToString(),
                                Month = newSt.Month,
                                Day = day,
                                Creator = a.Creator,
                                CreatorID = a.CreatorID,
                                ProjectID = a.ProjectID,
                                Team = a.Team,
                                Program = a.Program,
                                Participants = a.Participants,
                                County = a.County,
                                Date = Convert.ToDateTime(newSt.Year + "-" + newSt.Month + "-" + day),
                                Hour = strTime[0],
                                Minute = strTime[1],
                                AM = strTime[2],
                                Time = nTime,
                                Duration = a.Duration,
                                Created = DateTime.Now,
                                Modified = DateTime.Now
                            };
                            entity.Events.Add(e);
                            newSt = newSt.AddMonths(1);
                        }
                    }
                }
                else if (a.Event == "Arbitrary" & a.Recurrence != "")
                {
                    string[] strDates = a.Recurrence.Split(';');

                    int cnt = 0;

                    foreach (string s in strDates)
                    {
                        if (s == "") continue;

                        string[] strDateTimes = s.Split('T');

                        if (strDateTimes[0].ToString().Trim() == "" || strDateTimes[1].ToString().Trim() == "")
                            continue;

                        string[] strTimes = strDateTimes[1].Split(':');

                        if (strDateTimes.Count() > 2)
                            strTimes = strDateTimes[2].Split(':');

                        int nArbitraryTime = 0;

                        if (strTimes[2] == "PM")
                        {
                            nArbitraryTime = (Convert.ToInt32(strTimes[0]) + 12) * 100 + Convert.ToInt32(strTimes[1]);
                        }
                        else
                        {
                            nArbitraryTime = Convert.ToInt32(strTimes[0]) * 100 + Convert.ToInt32(strTimes[1]);
                            strTimes[2] = "AM";
                        }

                        st = Convert.ToDateTime(strDateTimes[0]); if (cnt == 0) ArbitraryStartDate = st; cnt = cnt + 1;
                        try
                        {
                            Event e = new Event
                            {
                                Title = a.Title,
                                ActivityID = a.ID,
                                Year = st.Year.ToString(),
                                Month = st.Month,
                                Day = st.Day,
                                Creator = a.Creator,
                                CreatorID = a.CreatorID,
                                ProjectID = a.ProjectID,
                                Team = a.Team,
                                Program = a.Program,
                                Participants = a.Participants,
                                County = a.County,
                                Date = Convert.ToDateTime(st.Year + "-" + st.Month + "-" + st.Day),
                                Hour = strTimes[0],
                                Minute = strTimes[1],
                                AM = strTimes[2],
                                Time = nArbitraryTime,
                                Duration = a.Duration,
                                Created = DateTime.Now,
                                Modified = DateTime.Now
                            };
                            entity.Events.Add(e);
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }

                entity.SaveChanges();

                return a.Event == "Arbitrary" ? ArbitraryStartDate : st;
            }
        }

        public DateTime GetNthWeekdayOfMonth(DateTime dt, int n, string weekday)
        {
            var days = Enumerable.Range(1, DateTime.DaysInMonth(dt.Year, dt.Month)).Select(day => new DateTime(dt.Year, dt.Month, day));

            var weekdays = from day in days
                           where day.DayOfWeek.ToString().ToUpper().Contains(weekday.ToUpper())
                           orderby day.Day ascending
                           select day;

            int index = n - 1;

            if (index >= 0 && index < weekdays.Count())
                return weekdays.ElementAt(index);

            else
                throw new InvalidOperationException("The specified day does not exist in this month!");
        }

        public string setAcitivityProject(string id, string activityid, string planid, string isUsed, string projectTitle, string year)
        {
            try
            {
                using (PowEntities entity = new PowEntities())
                {
                    Activity q = null;
                    Project p = null;
                    List<AdditionalTeam> ATlist = null;

                    int nId = Convert.ToInt32(id);
                    int nActivityId = Convert.ToInt32(activityid);
                    string strPlanId = planid;

                    #region create
                    if (id.Equals("") || id.Equals("0"))
                    {
                        if (isUsed.ToLower() == "no")
                        {
                            return "0";
                        }

                        q = (from c in entity.Activities where c.ID == nActivityId && c.Year == year select c).FirstOrDefault();

                        if (strPlanId.ToLower() == "ip")
                        {
                            int pid = CreateProject("", "Impromptu", "", "**Impromptu", "", projectTitle, "", "", "", "", "Yes", "", "", "", "", "", "", q.CreatorID, "", "", "", year);
                            planid = pid.ToString();

                            CLog.WriteToEventLog("Impromptue Plan id " + planid);

                            projectTitle = (projectTitle.Length == 2) ? (from b in entity.Programs where b.UID == projectTitle select b.Title).FirstOrDefault() : projectTitle;
                        }


                        int nPlanId = Convert.ToInt32(planid);

                        p = (from c in entity.Projects where c.ID == nPlanId && c.Year == year select c).FirstOrDefault();
                        ATlist = (from c in entity.AdditionalTeams where c.ProjectID == nPlanId && c.IsUsed.Contains("Y") select c).ToList();

                        List<ActivityProject> APlist = (from c in entity.ActivityProjects
                                                        where c.ActivityID == nActivityId && c.PlanID == nPlanId && c.IsUsed == "Yes" && c.Year == year
                                                        select c).ToList();
                        if (APlist.Count > 0)
                        {
                            // return (from c in dc.Activities where c.ID == q.ID && c.Year == year select c.ProjectID).FirstOrDefault();
                            return q.ProjectID;
                        }

                        ActivityProject ap = new ActivityProject
                        {
                            ActivityID = nActivityId,
                            PlanID = nPlanId,
                            IsUsed = "Yes",
                            ProjectTitle = strPlanId.ToLower() == "ip" ? projectTitle : p.ProjectTitle,
                            Modified = DateTime.Now,
                            Year = year
                        };
                        entity.ActivityProjects.Add(ap);

                        if (q != null && p != null)
                        {
                            if (!q.ProjectID.Contains(p.UID)) q.ProjectID = q.ProjectID + p.UID + ";";
                            //if (!q.Team.Contains(p.Team)) 
                            q.Team = q.Team + p.Team + ";";
                            //if (!q.Program.Contains(p.Program)) 
                            q.Program = q.Program + p.Program + ";";

                            foreach (AdditionalTeam at in ATlist)
                            {
                                //if (!q.Team.Contains(at.TeamUID)) 
                                q.Team = q.Team + at.TeamUID + ";";
                            }
                        }

                        entity.SaveChanges();
                    }
                    #endregion create

                    #region delete
                    else
                    {
                        ActivityProject ap = (from c in entity.ActivityProjects where c.ID == nId && c.Year == year select c).FirstOrDefault();
                        q = (from c in entity.Activities where c.ID == ap.ActivityID && c.Year == year select c).FirstOrDefault();
                        p = (from c in entity.Projects where c.ID == ap.PlanID && c.Year == year select c).FirstOrDefault();
                        ATlist = (from c in entity.AdditionalTeams where c.ProjectID == ap.PlanID && c.IsUsed.Contains("Y") select c).ToList();

                        if (isUsed.ToLower() == "no")
                        {
                            int _id = nId;
                            var aps = from c in entity.ActivityProjects where c.ID == _id select c;

                            foreach (ActivityProject a in aps)
                            {
                                a.IsUsed = isUsed;
                                a.Modified = DateTime.Now;
                            }

                            if (q != null && p != null)
                            {
                                q.ProjectID = RemoveFirst(q.ProjectID, p.UID);
                                q.Team = RemoveFirst(q.Team, p.Team);
                                q.Program = RemoveFirst(q.Program, p.Program);

                                foreach (AdditionalTeam at in ATlist)
                                {
                                    q.Team = RemoveFirst(q.Team, at.TeamUID);
                                }

                            }
                            entity.SaveChanges();
                        }
                    }
                    #endregion

                    var events = from e in entity.Events where e.ActivityID == q.ID select e;
                    foreach (Event e in events)
                    {
                        e.ProjectID = q.ProjectID;
                        e.Team = q.Team;
                        e.Program = q.Program;
                        e.Modified = DateTime.Now;
                    }

                    entity.SaveChanges();

                   // return (from c in entity.Activities where c.ID == q.ID && c.Year == year select c.ProjectID).FirstOrDefault();
                    return id;
                }
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return "0";
            }
        }


        public void setAcitivityProjects(ProjectActivity[] projectactivities)
        {
            /*
            int activityid = projectactivities[0].activityid;

            using (PowEntities entity = new PowEntities())
            {
                var projects = (from c in entity.ActivityProjects where c.ActivityID == activityid & c.IsUsed == "Yes" select c).ToList();
                foreach (var p in projects)
                {
                   // p.IsUsed = "No";
                  //  p.Modified = DateTime.Now;
                }
               // entity.SaveChanges();
            }
            */

            foreach (ProjectActivity pa in projectactivities)
            {   
                setAcitivityProject(pa.id.ToString(), pa.activityid.ToString(), pa.projectid.ToString(), pa.isUsed, pa.projectTitle, pa.year);
            }
        }


        private string RemoveFirst(string source, string remove)
        {
            int index = source.IndexOf(remove);
            return (index < 0) ? source : source.Remove(index, remove.Length + 1);
        }

        public List<CFileLink> GetFileLinks(int id)
        {
            try
            {
                List<CFileLink> fileList = new List<CFileLink>();
                /*
                string pathString = "C:\\files\\Pow\\app\\" + id.ToString() + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        CFileLink f = new CFileLink();
                        f.name = s;
                        f.link = "https://msapps.acesag.auburn.edu/Files/Pow/app/" + id.ToString() + "/" + s;

                        fileList.Add(f);
                    }
                }
                */
                string pathString = "C:\\files\\Pow\\2015\\" + id.ToString() + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        CFileLink f = new CFileLink();
                        f.name = s;
                        f.link = "https://msapps.acesag.auburn.edu/Files/Pow/2015/" + id.ToString() + "/" + s;

                        fileList.Add(f);
                    }
                }

                return fileList;
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }

        public List<CFileLink> GetMediaFileLinks(int id)
        {
            try
            {
                List<CFileLink> fileList = new List<CFileLink>();
                /*
                string pathString = "C:\\files\\Media\\app\\" + id.ToString() + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        CFileLink f = new CFileLink();
                        f.name = s;
                        f.link = "https://msapps.acesag.auburn.edu/Files/Media/app/" + id.ToString() + "/" + s;

                        fileList.Add(f);
                    }
                }
                */
                string pathString = "C:\\files\\Media\\2015\\" + id.ToString() + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        CFileLink f = new CFileLink();
                        f.name = s;
                        f.link = "https://msapps.acesag.auburn.edu/Files/Media/2015/" + id.ToString() + "/" + s;

                        fileList.Add(f);
                    }
                }

                return fileList;
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }


        public List<CFileLink> deleteFile(string fileLink)
        {
             /* https://msapps.acesag.auburn.edu/Files/Media/2015/17114/200_266_bransch.jpg */

              try
              {     
                  string f = fileLink.Substring(fileLink.IndexOf("Files/") + 6, fileLink.Length - fileLink.IndexOf("Files/") - 6);

                  string[] fs = f.Split('/');

                  string domain = fs[0];
                  string year = fs[1];
                  string id = fs[2];
                  //string fileName = fs[3].ToString().Replace("%20", " ").Trim();
                  string fileName = fs[3].ToString().TrimEnd();

                  string path = @"C:\files\" + domain + @"\" + year + @"\" + id;

                  if (Directory.Exists(path))
                  {
                      string[] files = Directory.GetFiles(path);
                      Array.Sort(files, StringComparer.InvariantCulture);

                      foreach (string file in files)
                      {
                          if (File.Exists(file))
                          {
                              if (System.IO.Path.GetFileName(file) == fileName)
                              {
                                  File.SetAttributes(file, FileAttributes.Normal);
                                  File.Delete(file);
                                  
                                  if(domain.ToLower() == "media")
                                  {
                                      return GetMediaFileLinks(Convert.ToInt32(id));
                                  }
                                  else
                                  {
                                      return GetFileLinks(Convert.ToInt32(id));
                                  }
                              }
                          }
                      }
                  }
              }
              catch (Exception e)
              {
                  CLog.WriteToEventLog(e.ToString());
                  return null;
              }

              return null;              
        }

        /* Add multi state demographics */
        public int SaveReport(CReport report)
        {
            using (PowEntities entity = new PowEntities())
            {
                Contact r = (from c in entity.Contacts where c.ID == report.id select c).FirstOrDefault();

                if (r != null)
                {
                    if (r.ContactType == "Contact" || r.ContactType == "One")
                    {
                        r.Title = report.title;
                        r.StartDate = Convert.ToDateTime(report.startDate);
                        r.EndDate = Convert.ToDateTime(report.endDate);
                    }

                    //r.County = report.county;
                    string counties = "";
                    foreach (string c in report.counties)
                    {
                        counties = counties + c + ";";
                    }
                    r.County = counties;

                    r.Year = report.year;
                    r.Description = report.activity;
                    r.Outcomes = report.OutcomeShort;
                    r.Evaluation = report.OutcomeLong;
                    r.ExternalFactor = report.ExternalFactors;
                    r.Program = report.program;

                    r.rmale = report.rural.male.ToString(); // report.gender.maleR.ToString();
                    r.umale = report.urban.male.ToString();  // report.gender.maleU.ToString();
                    r.rfmale = report.rural.female.ToString(); // report.gender.femaleR.ToString();
                    r.ufmale = report.urban.female.ToString(); // report.gender.femaleU.ToString();

                    r.radult = report.rural.adult.ToString(); // report.age.adultR.ToString();
                    r.uadult = report.urban.adult.ToString(); // report.age.adultU.ToString();
                    r.ryouth = report.rural.youth.ToString(); // report.age.youthR.ToString();
                    r.uyouth = report.urban.youth.ToString(); // report.age.youthU.ToString();

                    r.rwhite = report.rural.white.ToString();
                    r.uwhite = report.urban.white.ToString();
                    r.rblack = report.rural.black.ToString();
                    r.ublack = report.urban.black.ToString();
                    r.rapi = report.rural.asian.ToString();
                    r.uapi = report.urban.asian.ToString();
                    r.raian = report.rural.native.ToString();
                    r.uaian = report.urban.native.ToString();
                    r.rhisp = report.rural.hispanic.ToString();
                    r.uhisp = report.urban.hispanic.ToString();
                    r.rother = report.rural.other.ToString();
                    r.uother = report.urban.other.ToString();
                    r.rMore = report.rural.multi.ToString();
                    r.uMore = report.urban.multi.ToString();

                    r.rNonHispanic = report.rural.nonhispanic.ToString();
                    r.uNonHispanic = report.urban.nonhispanic.ToString();

                    /* 12/13/2018 June Shin */
                    if (report.version == null || report.version == 1)
                    {                     
                        r.rnftf = report.multistate.ToString();
                        r.Attendees = report.rural.male + report.urban.male + report.rural.female + report.urban.female + report.multistate;
                    }
                    else
                    {
                        r.rnftf = "";
                        r.unftf = "";

                        r.mrmale = report.mrural.male.ToString(); // report.gender.maleR.ToString();
                        r.mumale = report.murban.male.ToString();  // report.gender.maleU.ToString();
                        r.mrfmale = report.mrural.female.ToString(); // report.gender.femaleR.ToString();
                        r.mufmale = report.murban.female.ToString(); // report.gender.femaleU.ToString();

                        r.mradult = report.mrural.adult.ToString(); // report.age.adultR.ToString();
                        r.muadult = report.murban.adult.ToString(); // report.age.adultU.ToString();
                        r.mryouth = report.mrural.youth.ToString(); // report.age.youthR.ToString();
                        r.muyouth = report.murban.youth.ToString(); // report.age.youthU.ToString();

                        r.mrwhite = report.mrural.white.ToString();
                        r.muwhite = report.murban.white.ToString();
                        r.mrblack = report.mrural.black.ToString();
                        r.mublack = report.murban.black.ToString();
                        r.mrapi = report.mrural.asian.ToString();
                        r.muapi = report.murban.asian.ToString();
                        r.mraian = report.mrural.native.ToString();
                        r.muaian = report.murban.native.ToString();
                        r.mrhisp = report.mrural.hispanic.ToString();
                        r.muhisp = report.murban.hispanic.ToString();
                        r.mrother = report.mrural.other.ToString();
                        r.muother = report.murban.other.ToString();
                        r.mrMore = report.mrural.multi.ToString();
                        r.muMore = report.murban.multi.ToString();

                        r.mrNonHispanic = report.mrural.nonhispanic.ToString();
                        r.muNonHispanic = report.murban.nonhispanic.ToString();

                        r.Attendees = report.rural.male + report.urban.male + report.rural.female + report.urban.female +
                                report.mrural.male + report.murban.male + report.mrural.female + report.murban.female;

                        r.IsMultistate = (report.mrural.male + report.murban.male + report.mrural.female + report.murban.female) == 0 ? false : true;
                    }

                    r.Modified = DateTime.Now;
                    r.IsUsed = "Yes";

                    entity.SaveChanges();

                    return r.ID;
                }
                else
                {
                    Contact a = new Contact();

                    if (report.contactType == "Contact" || report.contactType == "One")
                    {
                        a.Title = report.title;
                        a.StartDate = Convert.ToDateTime(report.startDate);
                        a.EndDate = Convert.ToDateTime(report.endDate);
                    }

                    a.ContactType = report.contactType;
                    a.ActivityID = report.activityId;
                    a.CreatorID = report.creatorId;

                    //a.County = report.county;
                    string counties = "";
                    foreach (string c in report.counties)
                    {
                        counties = counties + c + ";";
                    }
                    a.County = counties;

                    a.Year = report.year;
                    a.Description = report.activity;
                    a.Outcomes = report.OutcomeShort;
                    a.Evaluation = report.OutcomeLong;
                    a.ExternalFactor = report.ExternalFactors;
                    a.Program = report.program;

                    a.rmale = report.rural.male.ToString(); // report.gender.maleR.ToString();
                    a.umale = report.urban.male.ToString();  // report.gender.maleU.ToString();
                    a.rfmale = report.rural.female.ToString(); // report.gender.femaleR.ToString();
                    a.ufmale = report.urban.female.ToString(); // report.gender.femaleU.ToString();

                    a.radult = report.rural.adult.ToString(); // report.age.adultR.ToString();
                    a.uadult = report.urban.adult.ToString(); // report.age.adultU.ToString();
                    a.ryouth = report.rural.youth.ToString(); // report.age.youthR.ToString();
                    a.uyouth = report.urban.youth.ToString(); // report.age.youthU.ToString();

                    a.rwhite = report.rural.white.ToString();
                    a.uwhite = report.urban.white.ToString();
                    a.rblack = report.rural.black.ToString();
                    a.ublack = report.urban.black.ToString();
                    a.rapi = report.rural.asian.ToString();
                    a.uapi = report.urban.asian.ToString();
                    a.raian = report.rural.native.ToString();
                    a.uaian = report.urban.native.ToString();
                    a.rhisp = report.rural.hispanic.ToString();
                    a.uhisp = report.urban.hispanic.ToString();
                    a.rother = report.rural.other.ToString();
                    a.uother = report.urban.other.ToString();
                    a.rMore = report.rural.multi.ToString();
                    a.uMore = report.urban.multi.ToString();

                    a.rNonHispanic = report.rural.nonhispanic.ToString();
                    a.uNonHispanic = report.urban.nonhispanic.ToString();


                    /* 12/13/2018 June Shin */
                    if (report.version == null || report.version == 1)
                    {
                        a.rnftf = report.multistate.ToString();
                        a.Attendees = report.rural.male + report.urban.male + report.rural.female + report.urban.female + report.multistate;
                    }
                    else
                    {
                        a.rnftf = "";
                        a.unftf = "";

                        a.mrmale = report.mrural.male.ToString(); // report.gender.maleR.ToString();
                        a.mumale = report.murban.male.ToString();  // report.gender.maleU.ToString();
                        a.mrfmale = report.mrural.female.ToString(); // report.gender.femaleR.ToString();
                        a.mufmale = report.murban.female.ToString(); // report.gender.femaleU.ToString();

                        a.mradult = report.mrural.adult.ToString(); // report.age.adultR.ToString();
                        a.muadult = report.murban.adult.ToString(); // report.age.adultU.ToString();
                        a.mryouth = report.mrural.youth.ToString(); // report.age.youthR.ToString();
                        a.muyouth = report.murban.youth.ToString(); // report.age.youthU.ToString();

                        a.mrwhite = report.mrural.white.ToString();
                        a.muwhite = report.murban.white.ToString();
                        a.mrblack = report.mrural.black.ToString();
                        a.mublack = report.murban.black.ToString();
                        a.mrapi = report.mrural.asian.ToString();
                        a.muapi = report.murban.asian.ToString();
                        a.mraian = report.mrural.native.ToString();
                        a.muaian = report.murban.native.ToString();
                        a.mrhisp = report.mrural.hispanic.ToString();
                        a.muhisp = report.murban.hispanic.ToString();
                        a.mrother = report.mrural.other.ToString();
                        a.muother = report.murban.other.ToString();
                        a.mrMore = report.mrural.multi.ToString();
                        a.muMore = report.murban.multi.ToString();

                        a.mrNonHispanic = report.mrural.nonhispanic.ToString();
                        a.muNonHispanic = report.murban.nonhispanic.ToString();

                        a.Attendees = report.rural.male + report.urban.male + report.rural.female + report.urban.female +
                                    report.mrural.male + report.murban.male + report.mrural.female + report.murban.female;

                        a.IsMultistate = (report.mrural.male + report.murban.male + report.mrural.female + report.murban.female) == 0 ? false : true;
                    }
                                        

                    a.IsUsed = "Yes";
                    DateTime dt = DateTime.Now;
                    a.Created = dt;
                    a.Modified = dt;

                    entity.Contacts.Add(a);

                    entity.SaveChanges();

                    return a.ID;
                }
            }
        }

        public List<CReport> GetReports(int activityId, string contactType)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.Contacts
                         where c.ActivityID == activityId && c.IsUsed == "Yes" && c.ContactType == contactType
                         select c).ToList();

                List<CReport> reports = new List<CReport>();

                foreach (var a in p)
                {
                    CReport r = new CReport();

                    r.contactType = contactType;
                    r.id = a.ID;
                    r.activityId = (int)a.ActivityID;
                    r.title = a.Title;
                    r.activity = a.Description;
                    r.userid = a.CreatorID;
                    r.year = a.Year;
                    r.OutcomeShort = a.Outcomes;
                    r.OutcomeLong = a.Evaluation;
                    r.ExternalFactors = a.ExternalFactor;
                    r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                    r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                    // r.creator = a.Creator.Contains('#') ? a.Creator.Split('#')[1] : a.Creator;

                    r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                    r.creatorId = a.CreatorID;
                    //r.county = a.County;
                    r.counties = a.County.Split(';');

                    r.program = a.Program;

                    r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;                    

                    r.rural = new Rural();
                    r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                    r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                    r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                    r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                    r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                    r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                    r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                    r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                    r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                    r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                    r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;

                    r.urban = new Urban();
                    r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                    r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                    r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                    r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                    r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                    r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                    r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                    r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                    r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                    r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                    r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;
                                       

                    r.fileLinks = GetFileLinks(r.id);

                    r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy");

                    reports.Add(r);
                }

                return reports;

            }
        }

        /* Add multi state demographics */
        public List<CReport> GetReports2(int activityId, string contactType)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.Contacts
                         where c.ActivityID == activityId && c.IsUsed == "Yes" && c.ContactType == contactType
                         select c).ToList();

                List<CReport> reports = new List<CReport>();

                foreach (var a in p)
                {
                    CReport r = new CReport();

                    r.contactType = contactType;
                    r.id = a.ID;
                    r.activityId = (int)a.ActivityID;
                    r.title = a.Title;
                    r.activity = a.Description;
                    r.userid = a.CreatorID;
                    r.year = a.Year;
                    r.OutcomeShort = a.Outcomes;
                    r.OutcomeLong = a.Evaluation;
                    r.ExternalFactors = a.ExternalFactor;
                    r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                    r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                    // r.creator = a.Creator.Contains('#') ? a.Creator.Split('#')[1] : a.Creator;

                    r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                    r.creatorId = a.CreatorID;
                    //r.county = a.County;
                    r.counties = a.County.Split(';');

                    r.program = a.Program;

                    r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;                    

                    r.rural = new Rural();
                    r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                    r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                    r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                    r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                    r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                    r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                    r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                    r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                    r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                    r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                    r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;
                    r.rural.nonhispanic = a.rNonHispanic != "" ? Convert.ToInt32(a.rNonHispanic) : 0;

                    r.urban = new Urban();
                    r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                    r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                    r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                    r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                    r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                    r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                    r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                    r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                    r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                    r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                    r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;
                    r.urban.nonhispanic = a.uNonHispanic != "" ? Convert.ToInt32(a.uNonHispanic) : 0;

                    r.mrural = new Rural();
                    r.mrural.male = a.mrmale != "" ? Convert.ToInt32(a.mrmale) : 0;
                    r.mrural.female = a.mrfmale != "" ? Convert.ToInt32(a.mrfmale) : 0;
                    r.mrural.adult = a.mradult != "" ? Convert.ToInt32(a.mradult) : 0;
                    r.mrural.youth = a.mryouth != "" ? Convert.ToInt32(a.mryouth) : 0;
                    r.mrural.white = a.mrwhite != "" ? Convert.ToInt32(a.mrwhite) : 0;
                    r.mrural.black = a.mrblack != "" ? Convert.ToInt32(a.mrblack) : 0;
                    r.mrural.asian = a.mrapi != "" ? Convert.ToInt32(a.mrapi) : 0;
                    r.mrural.native = a.mraian != "" ? Convert.ToInt32(a.mraian) : 0;
                    r.mrural.hispanic = a.mrhisp != "" ? Convert.ToInt32(a.mrhisp) : 0;
                    r.mrural.other = a.mrother != "" ? Convert.ToInt32(a.mrother) : 0;
                    r.mrural.multi = a.mrMore != "" ? Convert.ToInt32(a.mrMore) : 0;
                    r.mrural.nonhispanic = a.mrNonHispanic != "" ? Convert.ToInt32(a.mrNonHispanic) : 0;

                    r.murban = new Urban();
                    r.murban.male = a.mumale != "" ? Convert.ToInt32(a.mumale) : 0;
                    r.murban.female = a.mufmale != "" ? Convert.ToInt32(a.mufmale) : 0;
                    r.murban.adult = a.muadult != "" ? Convert.ToInt32(a.muadult) : 0;
                    r.murban.youth = a.muyouth != "" ? Convert.ToInt32(a.muyouth) : 0;
                    r.murban.white = a.muwhite != "" ? Convert.ToInt32(a.muwhite) : 0;
                    r.murban.black = a.mublack != "" ? Convert.ToInt32(a.mublack) : 0;
                    r.murban.asian = a.muapi != "" ? Convert.ToInt32(a.muapi) : 0;
                    r.murban.native = a.muaian != "" ? Convert.ToInt32(a.muaian) : 0;
                    r.murban.hispanic = a.muhisp != "" ? Convert.ToInt32(a.muhisp) : 0;
                    r.murban.other = a.muother != "" ? Convert.ToInt32(a.muother) : 0;
                    r.murban.multi = a.muMore != "" ? Convert.ToInt32(a.muMore) : 0;
                    r.murban.nonhispanic = a.muNonHispanic != "" ? Convert.ToInt32(a.muNonHispanic) : 0;


                    r.fileLinks = GetFileLinks(r.id);

                    r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy");

                    r.version = 2;

                    reports.Add(r);
                }

                return reports;

            }
        }

        public List<CReport> GetReports(string userid, string contactType, string year)
        {
            userid = userid.ToLower();
            contactType = contactType.ToLower();

            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.Contacts
                         where c.CreatorID.ToLower() == userid && c.IsUsed == "Yes" && c.ContactType.ToLower() == contactType && c.Year == year
                         select c).ToList();

                List<CReport> reports = new List<CReport>();

                foreach (var a in p)
                {
                    CReport r = new CReport();

                    r.contactType = contactType;
                    r.id = a.ID;
                    r.activityId = (int)a.ActivityID;
                    r.title = a.Title;
                    r.activity = a.Description;
                    r.userid = a.CreatorID;
                    r.year = a.Year;
                    r.OutcomeShort = a.Outcomes;
                    r.OutcomeLong = a.Evaluation;
                    r.ExternalFactors = a.ExternalFactor;
                    r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                    r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                    r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                    r.creatorId = a.CreatorID;
                    //r.county = a.County;
                    r.counties = a.County.Split(';');

                    r.program = a.Program;

                    r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;


                    r.rural = new Rural();
                    r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                    r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                    r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                    r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                    r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                    r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                    r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                    r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                    r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                    r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                    r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;

                    r.urban = new Urban();
                    r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                    r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                    r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                    r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                    r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                    r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                    r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                    r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                    r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                    r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                    r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;


                    r.fileLinks = GetFileLinks(r.id);

                    r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy h:mm:ss tt");

                    reports.Add(r);
                }

                return reports;

            }
        }

        /* Add multi state demographics */
        public List<CReport> GetReports2(string userid, string contactType, string year)
        {
            userid = userid.ToLower();
            contactType = contactType.ToLower();

            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.Contacts
                         where c.CreatorID.ToLower() == userid && c.IsUsed == "Yes" && c.ContactType.ToLower() == contactType && c.Year == year
                         select c).ToList();

                List<CReport> reports = new List<CReport>();

                foreach (var a in p)
                {
                    CReport r = new CReport();

                    r.contactType = contactType;
                    r.id = a.ID;
                    r.activityId = (int)a.ActivityID;
                    r.title = a.Title;
                    r.activity = a.Description;
                    r.userid = a.CreatorID;
                    r.year = a.Year;
                    r.OutcomeShort = a.Outcomes;
                    r.OutcomeLong = a.Evaluation;
                    r.ExternalFactors = a.ExternalFactor;
                    r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                    r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                    r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                    r.creatorId = a.CreatorID;
                    //r.county = a.County;
                    r.counties = a.County.Split(';');

                    r.program = a.Program;

                    r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;
                    
                    r.rural = new Rural();
                    r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                    r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                    r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                    r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                    r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                    r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                    r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                    r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                    r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                    r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                    r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;

                    r.urban = new Urban();
                    r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                    r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                    r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                    r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                    r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                    r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                    r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                    r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                    r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                    r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                    r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;

                    r.mrural = new Rural();
                    r.mrural.male = a.mrmale != "" ? Convert.ToInt32(a.mrmale) : 0;
                    r.mrural.female = a.mrfmale != "" ? Convert.ToInt32(a.mrfmale) : 0;
                    r.mrural.adult = a.mradult != "" ? Convert.ToInt32(a.mradult) : 0;
                    r.mrural.youth = a.mryouth != "" ? Convert.ToInt32(a.mryouth) : 0;
                    r.mrural.white = a.mrwhite != "" ? Convert.ToInt32(a.mrwhite) : 0;
                    r.mrural.black = a.mrblack != "" ? Convert.ToInt32(a.mrblack) : 0;
                    r.mrural.asian = a.mrapi != "" ? Convert.ToInt32(a.mrapi) : 0;
                    r.mrural.native = a.mraian != "" ? Convert.ToInt32(a.mraian) : 0;
                    r.mrural.hispanic = a.mrhisp != "" ? Convert.ToInt32(a.mrhisp) : 0;
                    r.mrural.other = a.mrother != "" ? Convert.ToInt32(a.mrother) : 0;
                    r.mrural.multi = a.mrMore != "" ? Convert.ToInt32(a.mrMore) : 0;

                    r.murban = new Urban();
                    r.murban.male = a.mumale != "" ? Convert.ToInt32(a.mumale) : 0;
                    r.murban.female = a.mufmale != "" ? Convert.ToInt32(a.mufmale) : 0;
                    r.murban.adult = a.muadult != "" ? Convert.ToInt32(a.muadult) : 0;
                    r.murban.youth = a.muyouth != "" ? Convert.ToInt32(a.muyouth) : 0;
                    r.murban.white = a.muwhite != "" ? Convert.ToInt32(a.muwhite) : 0;
                    r.murban.black = a.mublack != "" ? Convert.ToInt32(a.mublack) : 0;
                    r.murban.asian = a.muapi != "" ? Convert.ToInt32(a.muapi) : 0;
                    r.murban.native = a.muaian != "" ? Convert.ToInt32(a.muaian) : 0;
                    r.murban.hispanic = a.muhisp != "" ? Convert.ToInt32(a.muhisp) : 0;
                    r.murban.other = a.muother != "" ? Convert.ToInt32(a.muother) : 0;
                    r.murban.multi = a.muMore != "" ? Convert.ToInt32(a.muMore) : 0;
                                       
                    r.fileLinks = GetFileLinks(r.id);

                    r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy h:mm:ss tt");

                    r.version = 2;

                    reports.Add(r);
                }

                return reports;

            }
        }


        public CReport GetReport(int reportId)
        {
            using (PowEntities entity = new PowEntities())
            {
                var a = (from c in entity.Contacts where c.ID == reportId select c).FirstOrDefault();

                CReport r = new CReport();

                r.contactType = a.ContactType;
                r.id = a.ID;
                r.activityId = (int)a.ActivityID;
                r.title = a.Title;
                r.activity = a.Description;
                r.userid = a.CreatorID;
                r.year = a.Year;
                r.OutcomeShort = a.Outcomes;
                r.OutcomeLong = a.Evaluation;
                r.ExternalFactors = a.ExternalFactor;
                r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                // r.creator = a.Creator.Contains('#') ? a.Creator.Split('#')[1] : a.Creator;

                r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                r.creatorId = a.CreatorID;
                //r.county = a.County;
                r.counties = a.County.Split(';');

                r.program = a.Program;

                r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;

                r.rural = new Rural();
                r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;

                r.urban = new Urban();
                r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;            


                r.fileLinks = GetFileLinks(r.id);

                r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy");

                r.version = 1;

                return r;

            }
        }

        /* 1/23/2019 Add multi state demographics */
        public CReport GetReport2(int reportId)
        {
            using (PowEntities entity = new PowEntities())
            {
                var a = (from c in entity.Contacts where c.ID == reportId select c).FirstOrDefault();

                CReport r = new CReport();

                r.contactType = a.ContactType;
                r.id = a.ID;
                r.activityId = (int)a.ActivityID;
                r.title = a.Title;
                r.activity = a.Description;
                r.userid = a.CreatorID;
                r.year = a.Year;
                r.OutcomeShort = a.Outcomes;
                r.OutcomeLong = a.Evaluation;
                r.ExternalFactors = a.ExternalFactor;
                r.startDate = (a.StartDate == null) ? "" : ((DateTime)a.StartDate).ToString("MM/dd/yyyy");
                r.endDate = (a.EndDate == null) ? "" : ((DateTime)a.EndDate).ToString("MM/dd/yyyy");
                // r.creator = a.Creator.Contains('#') ? a.Creator.Split('#')[1] : a.Creator;

                r.creator = (from c in entity.StaffDirectories where c.UserID == a.CreatorID select c.FirstName + " " + c.LastName).FirstOrDefault();

                r.creatorId = a.CreatorID;
                //r.county = a.County;
                r.counties = a.County.Split(';');

                r.program = a.Program;

                r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;

                r.rural = new Rural();
                r.rural.male = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                r.rural.female = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                r.rural.adult = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                r.rural.youth = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                r.rural.white = a.rwhite != "" ? Convert.ToInt32(a.rwhite) : 0;
                r.rural.black = a.rblack != "" ? Convert.ToInt32(a.rblack) : 0;
                r.rural.asian = a.rapi != "" ? Convert.ToInt32(a.rapi) : 0;
                r.rural.native = a.raian != "" ? Convert.ToInt32(a.raian) : 0;
                r.rural.hispanic = a.rhisp != "" ? Convert.ToInt32(a.rhisp) : 0;
                r.rural.other = a.rother != "" ? Convert.ToInt32(a.rother) : 0;
                r.rural.multi = a.rMore != "" ? Convert.ToInt32(a.rMore) : 0;

                r.urban = new Urban();
                r.urban.male = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                r.urban.female = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;
                r.urban.adult = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                r.urban.youth = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;
                r.urban.white = a.uwhite != "" ? Convert.ToInt32(a.uwhite) : 0;
                r.urban.black = a.ublack != "" ? Convert.ToInt32(a.ublack) : 0;
                r.urban.asian = a.uapi != "" ? Convert.ToInt32(a.uapi) : 0;
                r.urban.native = a.uaian != "" ? Convert.ToInt32(a.uaian) : 0;
                r.urban.hispanic = a.uhisp != "" ? Convert.ToInt32(a.uhisp) : 0;
                r.urban.other = a.uother != "" ? Convert.ToInt32(a.uother) : 0;
                r.urban.multi = a.uMore != "" ? Convert.ToInt32(a.uMore) : 0;

                r.mrural = new Rural();
                r.mrural.male = a.mrmale != "" ? Convert.ToInt32(a.mrmale) : 0;
                r.mrural.female = a.mrfmale != "" ? Convert.ToInt32(a.mrfmale) : 0;
                r.mrural.adult = a.mradult != "" ? Convert.ToInt32(a.mradult) : 0;
                r.mrural.youth = a.mryouth != "" ? Convert.ToInt32(a.mryouth) : 0;
                r.mrural.white = a.mrwhite != "" ? Convert.ToInt32(a.mrwhite) : 0;
                r.mrural.black = a.mrblack != "" ? Convert.ToInt32(a.mrblack) : 0;
                r.mrural.asian = a.mrapi != "" ? Convert.ToInt32(a.mrapi) : 0;
                r.mrural.native = a.mraian != "" ? Convert.ToInt32(a.mraian) : 0;
                r.mrural.hispanic = a.mrhisp != "" ? Convert.ToInt32(a.mrhisp) : 0;
                r.mrural.other = a.mrother != "" ? Convert.ToInt32(a.mrother) : 0;
                r.mrural.multi = a.mrMore != "" ? Convert.ToInt32(a.mrMore) : 0;

                r.murban = new Urban();
                r.murban.male = a.mumale != "" ? Convert.ToInt32(a.mumale) : 0;
                r.murban.female = a.mufmale != "" ? Convert.ToInt32(a.mufmale) : 0;
                r.murban.adult = a.muadult != "" ? Convert.ToInt32(a.muadult) : 0;
                r.murban.youth = a.muyouth != "" ? Convert.ToInt32(a.muyouth) : 0;
                r.murban.white = a.muwhite != "" ? Convert.ToInt32(a.muwhite) : 0;
                r.murban.black = a.mublack != "" ? Convert.ToInt32(a.mublack) : 0;
                r.murban.asian = a.muapi != "" ? Convert.ToInt32(a.muapi) : 0;
                r.murban.native = a.muaian != "" ? Convert.ToInt32(a.muaian) : 0;
                r.murban.hispanic = a.muhisp != "" ? Convert.ToInt32(a.muhisp) : 0;
                r.murban.other = a.muother != "" ? Convert.ToInt32(a.muother) : 0;
                r.murban.multi = a.muMore != "" ? Convert.ToInt32(a.muMore) : 0;


                r.fileLinks = GetFileLinks(r.id);

                r.createdDate = ((DateTime)a.Created).ToString("MM/dd/yyyy");

                r.version = 2;

                return r;

            }
        }

        public int DeleteReport(int id, string type)
        {
            using (PowEntities entity = new PowEntities())
            {
                if (type.ToLower() == "media")
                {
                    var p = (from c in entity.Media where c.ID == id select c).FirstOrDefault();
                    if (p != null)
                    {
                        p.IsUsed = "No";
                        p.Modified = DateTime.Now;
                        entity.SaveChanges();
                    }
                }
                else
                {
                    var p = (from c in entity.Contacts where c.ID == id select c).FirstOrDefault();

                    if (p != null)
                    {
                        p.IsUsed = "No";
                        p.Modified = DateTime.Now;
                        entity.SaveChanges();
                    }
                }

                return id;
            }
        }

        public List<CActivityProject> getActivityProjects(int activityid, string year)
        {
            using (PowEntities context = new PowEntities())
            {
                var q = from ap in context.ActivityProjects.Where(ap => ap.IsUsed == "Yes" && ap.ActivityID == activityid && ap.Year == year)
                        join a in context.Activities on ap.ActivityID equals a.ID
                        join p in context.Projects on ap.PlanID equals p.ID into apo
                        from x in apo.DefaultIfEmpty()
                        select new CActivityProject
                        {
                            ows_Project = (x.ProjectTitle == null) ? ap.ProjectTitle : x.ProjectTitle,
                            ows_Program = (x.Program == null) ? ap.ProjectTitle : (from b in context.Programs where b.UID == x.Program select b.Title).FirstOrDefault(),
                            ows_ID = ap.ID,
                            ows_ActivityID = ap.ActivityID,
                            ows_PlanID = ap.PlanID,
                            ows_IsUsed = ap.IsUsed,
                            ows_PlanType = x.PlanType,
                            ows_Year = a.Year,
                            ows_Team = (from b in context.Teams where b.UID == x.Team select b.Title).FirstOrDefault(),
                            ows_AdditionalTeams = (from c in context.AdditionalTeams
                                                   join d in context.Teams on c.TeamUID equals d.UID
                                                   where c.ProjectID == x.ID && c.IsUsed == "Yes"
                                                   orderby d.Order
                                                   select d.Title).ToList(),
                            ows_UID = x.UID,
                            ows_LeadPersonID = x.LeadPersonID,
                            ows_LeadPerson = "",
                            ows_County = x.County,
                            ows_Modified = (ap.Modified == null) ? a.Modified : ap.Modified,
                            ows_Creator = x.Creator,
                            ows_CreatorName = "", //(from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                            ows_CreatorID = x.CreatorID,
                            ows_Outcomes = x.Outcomes
                        };

                return q.ToList();
            }
        }
        
        public string getMonth(int m)
        {
            string Title = "January";

            switch (m)
            {
                case 1: Title = "January"; break;
                case 2: Title = "Febrary"; break;
                case 3: Title = "March"; break;
                case 4: Title = "April"; break;
                case 5: Title = "May"; break;
                case 6: Title = "June"; break;
                case 7: Title = "July"; break;
                case 8: Title = "August"; break;
                case 9: Title = "September"; break;
                case 10: Title = "October"; break;
                case 11: Title = "November"; break;
                case 12: Title = "December"; break;
            }

            return Title;
        }

        public int getMonth(string m)
        {
            int nMonth = 1;

            switch (m)
            {
                case "January" : nMonth = 1; break;
                case "Febrary" : nMonth = 2; break;
                case "March" : nMonth = 3; break;
                case "April": nMonth = 4; break;
                case "June" : nMonth = 5; break;
                case "July": nMonth = 6; break;
                case "August" : nMonth = 7; break;
                case "May" : nMonth = 8; break;
                case "September" : nMonth = 9; break;
                case "October" :  nMonth= 10; break;
                case "November" : nMonth= 11; break;
                case "December": nMonth= 12; break;
            }

            return nMonth;
        }
        
        public List<MediaType> getMediaTypes(string year)
        {
            using (PowEntities entity = new PowEntities())
            {
                return (from c in entity.MediaTypes where c.Year == year && c.IsUsed == "Y" select c).ToList();
            }
        }

        public int createMedia(CMedia media)
        {
            using (PowEntities entity = new PowEntities())
            {
                if (media.id ==  0 || media.id.ToString() == "")
                {
                    Medium m = new Medium
                    {
                        CreatorID = media.creatorId,                        
                        Program = media.program,
                        Year = media.year,                                           
                        IsUsed = "Yes",
                        Modified = DateTime.Now,
                        Title = "",
                        Impact = "",
                        Feedback = ""
                    };

                    m.Month = getMonth(media.month);

                    string counties = "";
                    foreach (string c in media.counties)
                    {
                        counties = counties + c + ";";
                    }
                    m.County = counties;

                    entity.Media.Add(m);
                    entity.SaveChanges();
                    return m.ID;
                }
                else
                {
                    var p = (from c in entity.Media where c.ID == media.id select c).FirstOrDefault();

                    if (p != null)
                    {
                        p.Program = media.program;
                        p.Year = media.year;                                   
                        p.IsUsed = media.isUsed;
                        p.Modified = DateTime.Now;
                        p.Month = getMonth(media.month);

                        string counties = "";
                        foreach (string c in media.counties)
                        {
                            counties = counties + c + ";";
                        }
                        p.County = counties;

                        entity.SaveChanges();
                        return p.ID;
                    }
                }

                return 0;
            }

        }

        public void createMediaEvents(CMediaEvent[] events)
        {
            if (events.Length > 0)
            {
                int mid = events[0].mediaId;

                Medium media = null;

                using (PowEntities entity = new PowEntities())
                {
                     media = (from c in entity.Media where c.ID == mid select c).FirstOrDefault();
                }

                if (media != null)
                { 
                    using (PowEntities entity = new PowEntities()){
                        var meList = (from c in entity.MediaEvents where c.MediaID == media.ID select c).ToList();
                        foreach (MediaEvent e in meList)
                        {
                            e.IsUsed = "No";
                        }
                        entity.SaveChanges();
                    }

                    foreach (CMediaEvent e in events)
                    {
                        createMediaEvent(e, media);
                    }
                }
            }
        }

        public void createMediaEvent(CMediaEvent mEvent, Medium media)
        {
            using (PowEntities entity = new PowEntities())
            {
                if(mEvent.id == 0 || mEvent.id.ToString() == "")
                {
                    MediaEvent e = new MediaEvent();
                    e.MediaID = mEvent.mediaId;
                    e.MediaType = (from c in entity.MediaTypes where c.ID.ToString() == mEvent.mediaTypeId select c.Name).FirstOrDefault();
                    e.EventTitle = mEvent.eventTitle;

                    string[] d = mEvent.eventDate.Split('T')[0].Split('-');

                    e.EventDate = new DateTime(Convert.ToInt32(d[0]), Convert.ToInt32(d[1]), Convert.ToInt32(d[2]) );
                    e.Modified = DateTime.Now;
                    e.IsUsed = "Yes";
                    e.CreatorID = media.CreatorID;
                    e.Year = media.Year;

                    if(mEvent.mediaTypeId == "1")
                    {
                        e.Option2 = mEvent.eventName;
                    }
                    else if (mEvent.mediaTypeId == "2" || mEvent.mediaTypeId == "3")
                    {
                        e.Option2 = mEvent.eventName;
                        e.Option1 = mEvent.eventTime;
                    }                 
                    else if (mEvent.mediaTypeId == "4")
                    {
                        e.Option1 = mEvent.recipients;
                        e.Option2 = mEvent.eventType;
                        e.Option3 = "";
                        foreach(var c in mEvent.counties)
                        {
                            e.Option3 += (c + ";");
                        }                        
                    }
                    else if (mEvent.mediaTypeId == "5")
                    {
                        e.Option1 = mEvent.recipients;
                        e.Option2 = mEvent.eventType;                        
                    }

                    entity.MediaEvents.Add(e);
                    entity.SaveChanges();
                }
                else
                {
                    int nID = mEvent.id;
                    MediaEvent m = (from c in entity.MediaEvents where c.ID == nID select c).FirstOrDefault();

                    //if (isUsed.ToLower() == "no")
                    //{
                    //    m.IsUsed = isUsed;
                    //    m.Modified = DateTime.Now;
                    //}
                    //else
                    //{
                        //m.Year = year;
                        m.MediaType = (from c in entity.MediaTypes where c.ID.ToString() == mEvent.mediaTypeId select c.Name).FirstOrDefault();
                        m.EventTitle = mEvent.eventTitle;
                        string[] d = mEvent.eventDate.Split('T')[0].Split('-');
                        m.EventDate = new DateTime(Convert.ToInt32(d[0]), Convert.ToInt32(d[1]), Convert.ToInt32(d[2]));
                        m.Modified = DateTime.Now;
                        m.IsUsed = "Yes";

                        if (mEvent.mediaTypeId == "1")
                        {
                            m.Option2 = mEvent.eventName;
                        }
                        else if (mEvent.mediaTypeId == "2" || mEvent.mediaTypeId == "3")
                        {
                            m.Option2 = mEvent.eventName;
                            m.Option1 = mEvent.eventTime;
                        }
                        else if (mEvent.mediaTypeId == "4")
                        {
                            m.Option1 = mEvent.recipients;
                            m.Option2 = mEvent.eventType;
                            m.Option3 = "";
                            foreach (var c in mEvent.counties)
                            {
                                m.Option3 += (c + ";");
                            }
                        }
                        else if (mEvent.mediaTypeId == "5")
                        {
                            m.Option1 = mEvent.recipients;
                            m.Option2 = mEvent.eventType;
                        }
                    //}

                    entity.SaveChanges();
                }
            }
        }
        
        public List<MediaEventType> getEventTypes(string mediaTypeId)
        {
            using (PowEntities entity = new PowEntities())
            {
                return (from c in entity.MediaEventTypes where c.MediaTypeId.ToString() == mediaTypeId && c.IsUsed == "Y" select c).ToList();
            }
        }
        
        public List<CMedia> getMediaReports(string userid, string year)
        {
            using (PowEntities entity = new PowEntities())
            {
                 List<Medium> media = (from c in entity.Media
                        where c.Year == year && c.CreatorID == userid && c.IsUsed == "Yes"
                        select c).ToList();

                 List<CMedia> myMediaList = new List<CMedia>();

                 foreach (Medium m in media)
                 {
                     CMedia m1 = new CMedia();

                     m1.id = m.ID;
                     m1.program = m.Program;
                     m1.month =  getMonth(m.Month);
                     m1.isUsed = m.IsUsed;
                     m1.modified = ((DateTime)m.Modified).ToString("MM/dd/yyyy");
                     m1.year = m.Year;
                     m1.creatorId = m.CreatorID;
                     m1.creator = getUserName(m.CreatorID);
                     m1.counties = m.County.Split(';').Where(i=>i != "").ToArray();
                     m1.fileLinks = GetMediaFileLinks(m.ID);

                     myMediaList.Add(m1);
                 }

                 return myMediaList;
            }

        }

        public List<CMediaEvent> getMediaEvents(int id)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.MediaEvents where c.MediaID == id && c.IsUsed == "Yes" select c).ToList();

                List<CMediaEvent> myEventList = new List<CMediaEvent>();

                foreach (MediaEvent m in p)
                {
                    CMediaEvent e = new CMediaEvent();

                    e.id = m.ID;
                    e.mediaId = (int)m.MediaID;

                    e.mediaTypeId = (from c in entity.MediaTypes where c.Name == m.MediaType && c.Year == m.Year && c.IsUsed == "Y" select c.UID ).FirstOrDefault();
                    e.eventTitle = m.EventTitle;
                    e.eventDate = ((DateTime)m.EventDate).ToString("MM/dd/yyyy");
                    
                    if (e.mediaTypeId == "1")
                    {
                        e.eventName = m.Option2;
                    }
                    else if (e.mediaTypeId == "2" || e.mediaTypeId == "3")
                    {
                        e.eventName = m.Option2;
                        e.eventTime = m.Option1;
                    }
                    else if (e.mediaTypeId == "4")
                    {
                        e.recipients = m.Option1;
                        e.eventType = m.Option2;
                        e.counties = m.Option3.Split(';').Where(i => i != "").ToArray();
                    }
                    else if (e.mediaTypeId == "5")
                    {
                        e.recipients = m.Option1;
                        e.eventType = m.Option2;
                    }

                    myEventList.Add(e);
                }

                return myEventList;
            }
        }

    }
}


