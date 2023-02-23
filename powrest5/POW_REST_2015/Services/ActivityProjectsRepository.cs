using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class ActivityProjectsRepository
    {
        public List<CActivityProject> getActivityProjects(string year)
        {
            var context = new Models.PowEntities2();
            var q = from ap in context.ActivityProjects.Where(ap => ap.IsUsed == "Yes" && ap.Year == year)
                    join a in context.Activities on ap.ActivityID equals a.ID
                    join p in context.Projects on ap.PlanID equals p.ID 
                    into apo from x in apo.DefaultIfEmpty()
                    select new CActivityProject
                    {
                        ows_Project = (x.ProjectTitle == null) ? ap.ProjectTitle : x.ProjectTitle,
                        ows_Program = (x.Program == null) ? ap.ProjectTitle : x.Program,
                        ows_ID = ap.ID,
                        ows_ActivityID = ap.ActivityID,
                        ows_PlanID = ap.PlanID,
                        ows_IsUsed = ap.IsUsed,
                        ows_PlanType = x.PlanType,
                        ows_Year = a.Year,
                        ows_Team = x.Team,
                        ows_AdditionalTeams = (from c in context.AdditionalTeams
                                               join d in context.Teams on c.TeamUID equals d.UID
                                               where c.ProjectID == x.ID && c.IsUsed == "Yes" && d.Year == year
                                               orderby d.Order
                                               select d.Title).ToList(),               
                        ows_UID = x.UID,
                        ows_LeadPersonID = x.LeadPersonID,
                        ows_LeadPerson = "",                      
                        ows_County = x.County,    
                        ows_Modified = (ap.Modified == null) ? a.Modified : ap.Modified,
                        ows_Creator = a.Creator,
                        ows_CreatorName = "" ,//(from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                        ows_CreatorID = a.CreatorID,
                    };

            return q.ToList();
        }

        public List<CActivityProject> getActivityProjects(string year, int limit, int page)
        {
            var context = new Models.PowEntities2();
            var q = from ap in context.ActivityProjects.Where(ap => ap.IsUsed == "Yes" && ap.Year == year)
                    join a in context.Activities on ap.ActivityID equals a.ID
                    join p in context.Projects on ap.PlanID equals p.ID
                    into apo
                    from x in apo.DefaultIfEmpty()
                    select new CActivityProject
                    {
                        ows_Project = (x.ProjectTitle == null) ? ap.ProjectTitle : x.ProjectTitle,
                        ows_Program = (x.Program == null) ? ap.ProjectTitle : x.Program,
                        ows_ID = ap.ID,
                        ows_ActivityID = ap.ActivityID,
                        ows_PlanID = ap.PlanID,
                        ows_IsUsed = ap.IsUsed,
                        ows_PlanType = x.PlanType,
                        ows_Year = a.Year,
                        ows_Team = x.Team,
                        ows_AdditionalTeams = (from c in context.AdditionalTeams
                                               join d in context.Teams on c.TeamUID equals d.UID
                                               where c.ProjectID == x.ID && c.IsUsed == "Yes" && d.Year == year
                                               orderby d.Order
                                               select d.Title).ToList(),
                        ows_UID = x.UID,
                        ows_LeadPersonID = x.LeadPersonID,
                        ows_LeadPerson = "",
                        ows_County = x.County,
                        ows_Modified = (ap.Modified == null) ? a.Modified : ap.Modified,
                        ows_Creator = a.Creator,
                        ows_CreatorName = "",//(from b in context.PowUsers where b.Name.Contains(a.CreatorID) select b.Title).FirstOrDefault(),
                        ows_CreatorID = a.CreatorID,
                    };

            var v = q.OrderBy(a => a.ows_ID);

            return v.Skip(limit * (page - 1)).Take(limit).ToList();   

            //return q.ToList();
        }

        public List<CActivityProject> getActivityProjects(int activityid, string year)
        {
            var context = new Models.PowEntities2();
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
                                               where c.ProjectID == x.ID && c.IsUsed == "Yes" && d.Year == year
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
}