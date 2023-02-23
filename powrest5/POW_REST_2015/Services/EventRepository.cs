using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class EventRepository
    {
        public List<CEventDate> getEventDates(int activityid)
        {
            var context = new Models.PowEntities2();

            var q = from a in context.Events.Where(a => a.ActivityID == activityid)
                    select new CEventDate
                    {
                        ows_ID = a.ActivityID,
                        ows_Date = a.Date,
                        ows_Hour = a.Hour,
                        ows_Minute = a.Minute,
                        ows_AM = a.AM
                    };

            return q.ToList();
        }

        public List<CEvent> getEvents()
        {
            var context = new Models.PowEntities2();

            var query = from b in context.Events.Where(b => b.ProjectID != "" & b.ProjectID != null).OrderBy(b => b.ID)
                        select new CEvent
                        {
                            ows_ID = b.ID,
                            ows_Title = b.Title,
                            ows_ActivityID = b.ActivityID,
                            ows_Year = b.Year,
                            ows_Month = b.Month,
                            ows_Day = b.Day,
                            ows_CreatorID = b.CreatorID,
                            ows_Creator = b.Creator,
                            ows_Hour = b.Hour,
                            ows_Minute = b.Minute,
                            ows_AM = b.AM,
                            ows_Time = b.Time,
                            ows_Duration = b.Duration,
                            ows_County = b.County,
                            ows_Participants = b.Participants.ToLower(),
                            ows_ProjectID = b.ProjectID
                        };

            var events = query.ToList();

            return events;
        }

        public List<CEvent> getEvents(string year)
        {
            var context = new Models.PowEntities2();
            
            //var query = from b in context.Events.Where(b => b.ProjectID != "" & b.ProjectID != null && b.Year == year).OrderBy(b => b.ID)
            var query = from b in context.Events join a in context.Activities on b.ActivityID equals a.ID where b.ProjectID != "" & b.ProjectID != null && a.Year == year && a.IsUsed == "Yes" orderby b.ID
                        select new CEvent
                        {
                            ows_ID = b.ID,
                            ows_Title = b.Title,
                            ows_ActivityID = b.ActivityID,
                            ows_Year = b.Year,
                            ows_Month = b.Month,
                            ows_Day = b.Day,
                            ows_CreatorID = b.CreatorID,
                            ows_Creator = b.Creator,
                            ows_Hour = b.Hour,
                            ows_Minute = b.Minute,
                            ows_AM = b.AM,
                            ows_Time = b.Time,
                            ows_Duration = b.Duration,
                            ows_County = b.County,
                            ows_Participants = b.Participants.ToLower(),
                            ows_ProjectID = b.ProjectID
                        };

            var events = query.ToList();

            return events;
        }

        public List<CEvent> getEvents(string year, int limit, int page)
        {
            var context = new Models.PowEntities2();

            //var query = from b in context.Events.Where(b => b.ProjectID != "" & b.ProjectID != null && b.Year == year).OrderBy(b => b.ID)
            var query = from b in context.Events
                        join a in context.Activities on b.ActivityID equals a.ID
                        where b.ProjectID != "" & b.ProjectID != null && a.Year == year && a.IsUsed == "Yes"
                        orderby b.ID
                        select new CEvent
                        {
                            ows_ID = b.ID,
                            ows_Title = b.Title,
                            ows_ActivityID = b.ActivityID,
                            ows_Year = b.Year,
                            ows_Month = b.Month,
                            ows_Day = b.Day,
                            ows_CreatorID = b.CreatorID,
                            ows_Creator = b.Creator,
                            ows_Hour = b.Hour,
                            ows_Minute = b.Minute,
                            ows_AM = b.AM,
                            ows_Time = b.Time,
                            ows_Duration = b.Duration,
                            ows_County = b.County,
                            ows_Participants = b.Participants.ToLower(),
                            ows_ProjectID = b.ProjectID
                        };

            return query.Skip(limit * (page - 1)).Take(limit).ToList();
        }

        public List<CEvent> getEvents(string year, int month, string creator, string county, string team, string program,
                                                        bool isCreated, bool isParticipated, bool isProjects)
        {
            var context = new Models.PowEntities2();
            List<CEvent> events;
            IQueryable<Models.Event> q;

            string _creatorid = creator.Contains("Creator") ? "" : creator.ToLower().Trim();
            _creatorid = _creatorid.Contains("@") ? _creatorid.Substring(0, _creatorid.IndexOf('@')) : _creatorid;
            string _county = county.Trim().Equals("@") ? "" : county.Trim();
            string _team = team.Trim().Equals("@") ? "" : team.Trim();
            string _program = program.Trim().Equals("@") ? "" : program.Trim();

            if (creator.ToLower().Contains("creator"))
            {
                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != ""
                     && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program))
                    select c;
            }
            else if (isCreated == true && isParticipated == true && isProjects == true)
            {
                List<string> Plans = (from b in context.Projects.Where(b => b.CreatorID.ToLower().Contains(_creatorid.ToLower())
                                        && b.PlanType == "Individual" && b.IsUsed == "Yes" && b.Year == year)
                                      select b.UID + ";").ToList();

                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                               && (c.CreatorID.ToLower().Contains(_creatorid) ||
                                   c.Participants.Contains(_creatorid) ||
                                   Plans.Contains(c.ProjectID)
                                  ))
                    select c;
            }
            else if (isCreated == true && isParticipated == true)
            {
                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != ""
                     && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                             && (c.CreatorID.ToLower().Contains(_creatorid) ||
                                 c.Participants.Contains(_creatorid)
                                ))
                    select c;
            }
            else if (isCreated == true && isProjects == true)
            {
                List<string> Plans = (from b in context.Projects.Where(b => b.CreatorID.ToLower().Contains(_creatorid.ToLower())
                                       && b.PlanType == "Individual" && b.IsUsed == "Yes" && b.Year == year)
                                      select b.UID + ";").ToList();

                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                               && (c.CreatorID.ToLower().Contains(_creatorid) ||
                                   Plans.Contains(c.ProjectID)
                                  ))
                    select c;
            }
            else if (isParticipated == true && isProjects == true)
            {
                List<string> Plans = (from b in context.Projects.Where(b => b.CreatorID.ToLower().Contains(_creatorid.ToLower())
                                       && b.PlanType == "Individual" && b.IsUsed == "Yes" && b.Year == year)
                                      select b.UID + ";").ToList();

                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                               && (
                                   c.Participants.Contains(_creatorid) ||
                                   Plans.Contains(c.ProjectID)
                                  ))
                    select c;
            }
            else if (isCreated == true)
            {
                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                               && (c.CreatorID.ToLower().Contains(_creatorid)
                             ))
                    select c;
            }
            else if (isParticipated == true)
            {
                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                             && (c.Participants.Contains(_creatorid)
                                ))
                    select c;
            }
            else if (isProjects == true)
            {
                List<string> Plans = (from b in context.Projects.Where(b => b.CreatorID.ToLower().Contains(_creatorid.ToLower())
                                     && b.PlanType == "Individual" && b.IsUsed == "Yes" && b.Year == year)
                                      select b.UID + ";").ToList();

                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != "" && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program)
                               && (
                                   Plans.Contains(c.ProjectID)
                                  ))
                    select c;
            }
            else
            {
                q = from c in context.Events.Where(c => c.Year == year && c.Month == month && c.ProjectID != ""
                        && c.CreatorID.ToLower().Contains(_creatorid) && c.County.Contains(_county) && c.Team.Contains(_team) && c.Program.Contains(_program))
                    select c;
            }


            var query = from b in q.OrderBy(b => b.Time)
                        select new CEvent
                        {
                            ows_ID = b.ID,
                            ows_Title = b.Title,
                            ows_ActivityID = b.ActivityID,
                            ows_Year = b.Year,
                            ows_Month = b.Month,
                            ows_Day = b.Day,
                            ows_CreatorID = b.CreatorID,
                            ows_Creator = b.Creator,
                            ows_Hour = b.Hour,
                            ows_Minute = b.Minute,
                            ows_AM = b.AM,
                            ows_Time = b.Time,
                            ows_Duration = b.Duration,
                            ows_County = b.County,
                            ows_Participants = b.Participants.ToLower(),
                            ows_ProjectID = b.ProjectID
                        };

            events = query.ToList();

            return events;
        }
    }
}