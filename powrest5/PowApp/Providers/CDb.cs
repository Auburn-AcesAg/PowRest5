using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PowApp.Models;
using System.Globalization;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace PowApp.Providers
{
    public class CActivity : Activity
    {

    }

    public class CUserInfo
    {
        public string picUrl { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public string jobTitle { get; set; }
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
        public string county { get; set; }
        public int multistate { get; set; }
        public Gender gender {get; set;}
        public Age age { get; set; }
        public string activity { get; set; }
        public string OutcomeShort { get; set; }
        public string OutcomeLong { get; set; }
        public string ExternalFactors { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public List<CFileLink> fileLinks { get; set; }



        public CReport()
        {
            //gender = new Gender();
        }
    }

    public class Gender
    {
        public int maleR  { get; set; }
        public int maleU   { get; set; }
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

            CLog.WriteToEventLog(scriptText);

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
         

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.

            pipeline.Commands.Add("Out-String");
          //  pipeline.

            // execute the script

            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                CLog.WriteToEventLog(obj.ToString());
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString().Replace("\r\n", "").Replace(" ", "");
        }

        public CUserInfo GetUserInfo1(string userid)
        {
            try
            {
                CUserInfo u = new CUserInfo();
                /*
         //       userid = "fishegs";
                var scriptText = "$path = '\\\\ACESAGSMB\\Shared\\ctu\\ssl-data\\directory-pictures\\versions\\" + userid + "'; " +
                       " get-childitem -Path $path | where-object { $_.Name -like '200_*' } | select Name | Format-Table -HideTableHeaders;";
              //  var scriptText = "get-process";
                string result = RunScript(scriptText);

                CLog.WriteToEventLog(result);
                */
                //string pathString = "C:\\files\\AWW\\" + i.ID.ToString() + "\\";
              
                string filePath = "C:\\files\\Directory\\directory.txt";
                System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                userid = userid.ToLower();

                bool bFind = false;
                string imagefilename = "200_261_notfound.jpg"; 
                string line;
                while((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Split(' ');
                    if( arr[0] == userid ){
                        imagefilename = arr[1];
                        bFind = true;
                    }
                }

                /*
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        if (s.StartsWith("200"))
                               u.picUrl = "https://ssl.acesag.auburn.edu/directory-pictures/versions/" + userid + "/" + s;
                            //u.picUrl = ConfigurationManager.AppSettings["UserPicBaseURL"].ToString() + userid + "/" + s;
                    }
                }
                */


                u.picUrl = "https://ssl.acesag.auburn.edu/directory-pictures/versions/" + userid + "/" + imagefilename;

                using (PowEntities entity = new PowEntities())
                {
                    var user = (from c in entity.StaffDirectories where c.UserID == userid select c).FirstOrDefault();
                    if (user != null)
                    {
                        u.username = user.FirstName + " " + user.LastName;
                        u.jobTitle = user.JobTitle;
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

        public CUserInfo GetUserInfo(string userid)
        {
            try
            {
                CUserInfo u = new CUserInfo();

                //string pathString = "C:\\files\\AWW\\" + i.ID.ToString() + "\\";
                string pathString = "C:\\files\\Directory\\" + userid + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    foreach (string s in strFiles)
                    {
                        if (s.StartsWith("200"))
                            u.picUrl = "https://ssl.acesag.auburn.edu/directory-pictures/versions/" + userid + "/" + s;
                    }
                }

                using (PowEntities entity = new PowEntities())
                {
                    var user = (from c in entity.StaffDirectories where c.UserID == userid select c).FirstOrDefault();
                    if (user != null)
                    {
                        u.username = user.FirstName + " " + user.LastName;
                        u.jobTitle = user.JobTitle;
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

        public List<Activity> GetActivities(string year,int month, int day)
        {
            using(PowEntities entity = new PowEntities())
            {
                var p = (from a in entity.Activities
                         join e in entity.Events on a.ID equals e.ActivityID
                         where a.IsUsed == "Yes" & e.Year == year & e.Month == month & e.Day == day
                         select a ).ToList();

                return p.OrderBy(a => DateTime.ParseExact(a.StartTime, "hh:mm:tt", CultureInfo.InvariantCulture)).ToList();


            }
        }


        public List<CFileLink> GetFileLinks(int id)
        {
            try
            {
                string pathString = "C:\\files\\PowApp\\" + id.ToString() + "\\";
                if (System.IO.Directory.Exists(pathString))
                {
                    string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                    List<CFileLink> fileList = new List<CFileLink>();
                    foreach (string s in strFiles)
                    {
                        CFileLink f = new CFileLink();
                        f.name = s;
                        f.link = "https://msapps.acesag.auburn.edu/Files/PowApp/" + id.ToString() + "/" + s;

                        fileList.Add(f);                        
                    }
                    return fileList;
                }

                return null;

            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                return null;
            }
        }


        public void SaveReport(CReport report)
        {
            using(PowEntities entity = new PowEntities())
            {
                ContactApp r = (from c in entity.ContactApps where c.ID == report.id select c).FirstOrDefault();

                if( r != null)
                {
                    if( r.ContactType == "Contact")
                    {
                        r.Title = report.title;
                        r.StartDate = Convert.ToDateTime(report.startDate);
                        r.EndDate = Convert.ToDateTime(report.endDate);
                    }

                    r.County = report.county;
                    r.Description = report.activity;
                    r.Outcomes = report.OutcomeShort;
                    r.Evaluation = report.OutcomeLong;
                    r.ExternalFactor = report.ExternalFactors;

                    r.rmale = report.gender.maleR.ToString();
                    r.umale = report.gender.maleU.ToString();
                    r.rfmale = report.gender.femaleR.ToString();
                    r.ufmale = report.gender.femaleU.ToString();

                    r.radult = report.age.adultR.ToString();
                    r.uadult = report.age.adultU.ToString();
                    r.ryouth = report.age.youthR.ToString();
                    r.uyouth = report.age.youthU.ToString();

                    r.rnftf = report.multistate.ToString();

                    r.Attendees = report.gender.maleR + report.gender.maleU + report.gender.femaleR + report.gender.femaleU + report.multistate;

                    entity.SaveChanges();
                }
                else
                {
                    ContactApp a = new ContactApp();

                  
                    if (report.contactType == "Contact")
                    {
                        a.Title = report.title;
                        a.StartDate = Convert.ToDateTime(report.startDate);
                        a.EndDate = Convert.ToDateTime(report.endDate);
                    }

                   
                    a.ContactType = report.contactType;                  
                    a.ActivityID = report.activityId;
                    a.CreatorID = report.creatorId;
                    a.County = report.county;
                    a.Description = report.activity;
                    a.Outcomes = report.OutcomeShort;
                    a.Evaluation = report.OutcomeLong;
                    a.ExternalFactor = report.ExternalFactors;
                 
                    a.rmale = report.gender.maleR.ToString();
                    a.umale = report.gender.maleU.ToString();
                    a.rfmale = report.gender.femaleR.ToString();
                    a.ufmale = report.gender.femaleU.ToString();
              
                    a.radult = report.age.adultR.ToString();
                    a.uadult = report.age.adultU.ToString();
                    a.ryouth = report.age.youthR.ToString();
                    a.uyouth = report.age.youthU.ToString();
               
                    a.rnftf = report.multistate.ToString();
                 
                    a.Attendees = report.gender.maleR + report.gender.maleU + report.gender.femaleR + report.gender.femaleU + report.multistate;


                    a.IsUsed = "Yes";

                    entity.ContactApps.Add(a);

                    entity.SaveChanges();
                }
            }
        }

        public List<CReport> GetReports(int activityId, string contactType)
        {
            using (PowEntities entity = new PowEntities())
            {
                var p = (from c in entity.ContactApps
                         where c.ActivityID == activityId && c.IsUsed == "Yes" && c.ContactType == contactType select c).ToList();

                List<CReport> reports = new List<CReport>();

                foreach(var a in p){
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
                     r.creator = a.Creator;
                     r.creatorId = a.CreatorID;
                     r.county = a.County;
                     r.multistate = a.rnftf != "" ? Convert.ToInt32(a.rnftf) : 0;

                     r.gender =  new Gender();
                     r.gender.maleR = a.rmale != "" ? Convert.ToInt32(a.rmale) : 0;
                     r.gender.maleU = a.umale != "" ? Convert.ToInt32(a.umale) : 0;
                     r.gender.femaleR = a.rfmale != "" ? Convert.ToInt32(a.rfmale) : 0;
                     r.gender.femaleU = a.ufmale != "" ? Convert.ToInt32(a.ufmale) : 0;

                     r.age = new Age();
                     r.age.adultR = a.radult != "" ? Convert.ToInt32(a.radult) : 0;
                     r.age.adultU = a.uadult != "" ? Convert.ToInt32(a.uadult) : 0;
                     r.age.youthR = a.ryouth != "" ? Convert.ToInt32(a.ryouth) : 0;
                     r.age.youthU = a.uyouth != "" ? Convert.ToInt32(a.uyouth) : 0;



                     

                     r.fileLinks = GetFileLinks(r.id);
                                        

                     reports.Add(r);
                }

                return reports;

            }
        }


       
    }

}