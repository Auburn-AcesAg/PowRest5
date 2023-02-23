using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class ProjectRepository
    {
        private CommonRepository commonRepository = new CommonRepository();
        
        public List<CProject> getIndividualProjectsbyUID(string year, string UID)
        {
            if(year != "")
            {
                var context = new Models.PowEntities2();

                return (from a in context.Projects
                        where a.IsUsed.StartsWith("y") && year == a.Year && a.PlanType == "Individual" && a.UID == UID
                        orderby a.ID
                        select new CProject
                        {
                            ows_ID = a.ID,                           
                            ows_CreatorName = (from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                            ows_IsCompleted = a.IsCompleted,                     
                            ows_Year = a.Year,
                            ows_UID = a.UID,
                            ows_PlanType = a.PlanType
                        }).ToList();
            }
            else
                return null;
        }

        public List<CProject> getProjects(string year, string type, string team, string program)
        {
            string teamYear = (Convert.ToInt32(year) > 2017) ? year : "2017";

            if (type.Contains("Unplanned") && team.Contains("Unplanned") && (program == null || program == ""))
                return null;

            if( team != null && team.Contains("Unplanned"))
            {
                type = "Unplanned";
            }

            if ( (team == null || team == "") && (program == null || program == "") )
                return null;           

            var context = new Models.PowEntities2();

            if (team != null && team.ToString().Length == 2)
            {
                team = (team == null) ? "" : team;
            }
            else
            {
                team = (team == null) ? "" : (from t in context.Teams where t.Title.Contains(team) && t.Year == teamYear select t.UID).FirstOrDefault();
            }

            
            if(program != null && program.ToString().Length == 2)
            {
                program = (program == null) ? "" : program;
            }
            else
            {
                program = (program == null) ? "" : (from p in context.Programs where p.Title == program  && p.Year == teamYear select p.UID).FirstOrDefault();
            }
          

            return (from a in context.Projects
                    where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType && a.Program.Contains(program)
                            /* June Shin 10/25/2019 */
                            //&& (a.Team.Contains(team) || (from b in context.AdditionalTeams where b.TeamUID == team & b.IsUsed == "Yes" select b.ProjectID).Contains(a.ID))
                            && (a.Team.Contains(team) || (from b in context.AdditionalTeams where b.ProjectID == a.ID && b.TeamUID == team && b.IsUsed == "Yes" select b).Count() > 0)
                    select new CProject
                    {
                        ows_ID = a.ID,
                        ows_PlanType = a.PlanType,
                        ows_Project = a.ProjectTitle,
                        ows_LeadPersonID = a.LeadPersonID,
                        ows_LeadPerson =  "",                     
                        ows_IsCompleted = a.IsCompleted,
                        ows_ProjectType = a.ProjectType
                    }).ToList();
          
        }
       
        public List<CProject> getProjectsByProgram(string year, string type, string program)
        {
            using (var context = new Models.PowEntities2())
            {
                if (program != null && program != "" && program.ToString().Length == 2)
                {
                   // program = (program == null) ? "" : program;
                }
                else
                {
                    program = (program == null || program == "") ? "" 
                        : (from p in context.Programs where p.Title == program && p.Year == year select p.UID).FirstOrDefault();
                }

                var projects = (from a in context.Projects
                                where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType && a.Program.Contains(program)
                                select new CProject
                                {
                                    ows_ID = a.ID,
                                    ows_PlanType = a.PlanType,
                                    ows_Project = a.ProjectTitle,
                                    ows_LeadPersonID = a.LeadPersonID,
                                    ows_LeadPerson = "",
                                    ows_IsCompleted = a.IsCompleted,
                                    ows_ProjectType = a.ProjectType,
                                    ows_CreatorID = a.CreatorID,
                                    ows_Creator = a.Creator
                                }).ToList();


                foreach(var p in projects)
                {
                    if (p.ows_Creator.Contains('#'))
                        p.ows_CreatorName = p.ows_Creator.Split('#')[1];
                    else
                        p.ows_CreatorName = p.ows_Creator;

                    p.ows_ProjectType = p.ows_Project + " ------ by " + p.ows_CreatorName;
                }

                return projects.OrderBy(a => a.ows_Project.TrimStart()).ToList();
            }
        }

        public List<CProject> getMyProjects(string year, string userID, string type)
        {
           // int nYear = 2021; slm
            int nYear = 2022;
            if(!Int32.TryParse(year, out nYear))
            {
                return null;
            }

            if (nYear <= 2014)
            {
                return null;

            }
            else
            {
                var context = new Models.PowEntities2();
                userID = (!userID.Contains('@')) ? userID.ToLower() : userID.Substring(0, userID.IndexOf('@')).ToLower();

                if (type.ToLower() == "team")
                {
                    return (from a in context.Projects
                            where a.IsUsed.StartsWith("y") && year == a.Year && type == a.PlanType 
                                    && (a.CreatorID.ToLower().Contains(userID) || a.LeadPersonID.ToLower().Contains(userID))
                            orderby a.ID
                            select new CProject
                            {
                                ows_ID = a.ID,
                                ows_PlanType = a.PlanType,
                                ows_Project = a.ProjectTitle,
                                ows_IsCompleted = a.IsCompleted,
                                ows_Team = (from b in context.Teams where b.UID == a.Team & b.Year == year select b.Title).FirstOrDefault(),
                                ows_Program = (from b in context.Programs where b.UID == a.Program & b.Year == year select b.Title).FirstOrDefault(),
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
                                ows_Team = (from b in context.Teams where b.UID == a.Team & b.Year == year select b.Title).FirstOrDefault(),
                                ows_Program = (from b in context.Programs where b.UID == a.Program & b.Year == year select b.Title).FirstOrDefault(),
                                ows_Year = a.Year,
                                ows_UID = a.UID,
                                ows_LeadPersonID = a.LeadPersonID,
                                ows_LeadPerson = ""
                            }).ToList();
                }
            }

        }

        public List<CProject> getProjectbyID(string year, String ID)
        {
            if (year == "2014")
            {
                /*
                var context = new Models.PowEntities3();

                int nID = Convert.ToInt32(ID);

                return (from a in context.Plans
                        where a.ID == nID && a.Year == year
                        select new CProject
                        {
                            ows_ID = a.ID,
                            ows_PlanType = a.PlanType,
                            ows_Project = a.Project,
                            ows_IsCompleted = a.IsCompleted,
                            ows_Team = a.Team,
                            ows_Program = a.Program,
                            ows_Creator = a.Creator,
                            ows_CreatorName = a.Creator_orig,
                            ows_CreatorID = a.Email,
                            ows_Objectives = a.Objectives,
                            ows_Outputs = a.Outputs,
                            ows_Outcomes = a.Outcomes,
                            ows_When = a.When,
                            ows_Where = a.Where,
                            ows_Evaluation = a.Evaluation,
                            ows_UID = a.UID,
                            ows_IsUsed = a.IsUsed,
                            ows_Year = a.Year,
                            ows_ProjectType = a.ProjectType,
                            ows_LeadPerson = a.LeadPerson,
                            ows_LeadPersonID = a.LeadPersonID,
                            ows_County = a.County,
                            ows_Engagement = a.Engagement,
                            ows_Responsibility = a.Responsibility,
                            ows_TeamCodes = "",
                            ows_AdditionalTeamsString = "",
                            ows_InstructorsName = "",
                            ows_AdditionalTeams = new List<string> { a.AdditionalTeams },
                            ows_Modified = a.Modified,
                            ows_Editor = a.Modified_By

                        }).ToList();
                */
                return null;
            }
            else if (year == "2013")
            {
                /*
                var context = new Models.PowEntities2();

                int nID = Convert.ToInt32(ID);

                return (from a in context.ProjectsHistories
                        where a.ID == nID && a.Year == year
                        select new CProject
                        {
                            ows_ID = a.ID,
                            ows_PlanType = a.PlanType,
                            ows_Project = a.Project,
                            ows_IsCompleted = a.IsCompleted,
                            ows_Team = a.Team,
                            ows_Program = a.Program,
                            ows_Creator = a.Creator,
                            ows_CreatorName = a.Creator_orig,
                            ows_CreatorID = a.Email,
                            ows_Objectives = a.Objectives,
                            ows_Outputs = a.Outputs,
                            ows_Outcomes = a.Outcomes,
                            ows_When = a.When,
                            ows_Where = a.Where,
                            ows_Evaluation = a.Evaluation,
                            ows_UID = a.UID,
                            ows_IsUsed = a.IsUsed,
                            ows_Year = a.Year,
                            ows_ProjectType = a.ProjectType,
                            ows_LeadPerson = (a.LeadpersonID == null) ? "" : a.LeadPerson,
                            ows_LeadPersonID = a.LeadpersonID,
                            ows_County = a.County,
                            ows_Engagement = "",
                            ows_Responsibility = "",
                            ows_TeamCodes = "",
                            ows_AdditionalTeamsString = "",
                            ows_InstructorsName = "",
                            ows_AdditionalTeams = new List<string> { "" },
                            ows_Modified = a.Modified,
                            ows_Editor = a.Modified_By

                        }).ToList();
                */

                return null;
            }
            else
            {
                var context = new Models.PowEntities2();

                int nID = Convert.ToInt32(ID);

                return (from a in context.Projects
                        where a.ID == nID && a.Year == year
                        select new CProject
                        {
                            ows_ID = a.ID,
                            ows_PlanType = a.PlanType,
                            ows_Project = a.ProjectTitle,
                            ows_IsCompleted = a.IsCompleted,
                            ows_Team = (from b in context.Teams where b.UID == a.Team & b.Year == year select b.Title).FirstOrDefault(),
                            ows_Program = (from b in context.Programs where b.UID == a.Program & b.Year == year select b.Title).FirstOrDefault(),
                            ows_Creator = a.Creator,
                            ows_CreatorName = (from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                            ows_CreatorID = a.CreatorID,
                            ows_AdditionalTeams = (from c in context.AdditionalTeams join d in context.Teams on c.TeamUID equals d.UID where c.ProjectID == a.ID && c.IsUsed == "Yes" && d.Year == year
                                                   orderby d.Order select d.Title).ToList(),
                            ows_Objectives = a.Objectives,
                            ows_Outputs = a.Outputs,
                            ows_Outcomes = a.Outcomes,
                            ows_When = a.When,
                            ows_Where = a.Where,
                            ows_Evaluation = a.Evaluation,
                            ows_UID = a.UID,
                            ows_IsUsed = a.IsUsed,
                            ows_Year = a.Year,
                            ows_ProjectType = a.ProjectType,                            
                            ows_LeadPersonID = a.LeadPersonID,
                            ows_LeadPerson = "",
                            ows_County = a.County,
                            ows_Engagement = a.Engagement,
                            ows_Responsibility = a.Responsibility,
                            ows_TeamCodes = "",
                            ows_AdditionalTeamsString = "",
                            ows_Instructors = a.Instructors,
                            ows_InstructorsName = "",
                            ows_Modified = a.Modified,
                            ows_Editor = a.Modified_By

                        }).ToList();
            }   
        }     
  
        public List<CProject> getProjectsbyYear(string year)
        {
            int value;

            if( int.TryParse(year, out value) ) {
            }
            else
            {
                return null;
            }

            try
            {

                if (value >= 2015)
                {
                    var context = new Models.PowEntities2();

                    var data = (from a in context.Projects
                                where a.Year == year && a.IsUsed == "Yes" //&& a.UID != "AQ-NE-016474"
                                select a).ToList();
                    List<CProject> projects = new List<CProject>();

                    foreach (var a in data)
                    {
                        var t = a.ProjectTitle;

                        var p = new CProject
                        {
                            ows_ID = a.ID,
                            ows_PlanType = a.PlanType,
                            ows_Project = HttpUtility.HtmlEncode(a.ProjectTitle),
                            ows_IsCompleted = a.IsCompleted ,                            
                            ows_Team = (from b in context.Teams where b.UID == a.Team & b.Year == year select b.Title).FirstOrDefault(),
                            ows_Program = (from b in context.Programs where b.UID == a.Program & b.Year == year select b.Title).FirstOrDefault(),
                            ows_Creator = a.Creator,
                            ows_CreatorName = (from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                            ows_CreatorID = a.CreatorID,
                            ows_AdditionalTeams = (from c in context.AdditionalTeams
                                                   join d in context.Teams on c.TeamUID equals d.UID
                                                   where c.ProjectID == a.ID && c.IsUsed == "Yes" && d.Year == year
                                                   orderby d.Order
                                                   select d.Title).ToList() ,

                            ows_Objectives = a.Objectives,
                            ows_Outputs = a.Outputs,
                            ows_Outcomes = a.Outcomes,
                            ows_When = a.When,
                            ows_Where = a.Where,
                            ows_Evaluation = a.Evaluation,
                            ows_UID = a.UID,
                            ows_IsUsed = a.IsUsed,
                            ows_Year = a.Year,
                            ows_ProjectType = a.ProjectType,
                            ows_LeadPersonID = a.LeadPersonID,
                            ows_LeadPerson = "",
                            // ows_County = a.County,
                            ows_County = a.County == null ? "" : commonRepository.ConvertSetCounty(a.County),
                            ows_Engagement = a.Engagement,
                            ows_Responsibility = a.Responsibility,
                            ows_TeamCodes = "",
                            ows_AdditionalTeamsString = "",
                            ows_Instructors = a.Instructors,
                            ows_InstructorsName = "",
                            ows_Modified = a.Modified,
                            ows_Editor = a.Modified_By 
                        };

                        projects.Add(p);
                    }
                    return projects;
                }
                else
                    return null;
            }
            catch(Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }
    }
}