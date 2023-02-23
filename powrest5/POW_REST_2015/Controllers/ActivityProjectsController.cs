using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class ActivityProjectsController : ApiController
    {
        private ActivityProjectsRepository apRepository;

        public ActivityProjectsController()
        {
            this.apRepository = new ActivityProjectsRepository();
        }

        public List<CActivityProject> Get(int activityid, string year)
        {
            return apRepository.getActivityProjects(activityid, year);
        }

        public List<CActivityProject> Get(string year)
        {
            return apRepository.getActivityProjects(year);
        }

        public List<CActivityProject> Get(string year, int limit, int page)
        {
            return apRepository.getActivityProjects(year, limit, page);
        }
    }
}
