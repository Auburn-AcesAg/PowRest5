using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class EventController : ApiController
    {
        private EventRepository Repository;
        //private PowConnectionString pow;

        public EventController()
        {
            this.Repository = new EventRepository();
        }
        
        public List<CEvent> Get(string year, int month, string creator, string county, string team, string program, 
                                bool isCreated, bool isParticipated, bool isProjects)
        {
            return Repository.getEvents(year, month, creator, county, team, program, isCreated, isParticipated, isProjects);        
        }

        public List<CEventDate> Get(int activityid)
        {
            return Repository.getEventDates(activityid);
        }

        public List<CEvent> Get(string year, int limit, int page)
        {
            return Repository.getEvents(year, limit, page);
        }

        public List<CEvent> Get(string year)
        {
            return Repository.getEvents(year);
        }

        public List<CEvent> Get()
        {
            return Repository.getEvents();
        }
    }
}
