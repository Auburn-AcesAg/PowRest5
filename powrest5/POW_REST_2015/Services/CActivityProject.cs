using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CActivityProject
    {
        Models.PowEntities2 context = new Models.PowEntities2();
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
      //  public string ows_LeadPersonID { get; set; }

        public string ows_Creator { get; set; }
        public string ows_CreatorName { 
                get {
                    if(ows_Creator.Contains('#'))
                    {
                        return ows_Creator.Substring(ows_Creator.IndexOf('#') + 1, ows_Creator.Length - (ows_Creator.IndexOf('#') + 1));
                    }
                    else
                    {
                        return ows_Creator;
                    }
                } 
                set{ 

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

                //if (ows_Year == "2015")
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
                /*
                else
                {
                    if (ows_AdditionalTeams != null && ows_AdditionalTeams.Count > 0)
                    {
                        s = ows_AdditionalTeams[0];
                    }
                }
                */

                return s;

            }
            set
            {

            }

        }

        private string leadPersonID;
        public string ows_LeadPersonID
        {
            get
            {
                var leads = (from c in context.ProjectLeadPersons where c.ProjectID == ows_PlanID && c.IsUsed == true select c).ToList();
                if (leads.Count > 0)
                {
                    string s = "";
                    foreach (var l in leads)
                    {
                        if (s == "") s = l.UserID;
                        else s = s + ";" + l.UserID;
                    }
                    return s;
                }
                else
                {
                    return this.leadPersonID;
                }
            }

            set
            {
                leadPersonID = value;
            }
        }

        public string ows_LeadPerson
        {
            get
            {
                string s = "";
                if (ows_LeadPersonID != null && ows_LeadPersonID != "")
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

                return s;
            }

            set
            {

            }

        }
    }
}