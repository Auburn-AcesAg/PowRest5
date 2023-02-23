using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class ActivityController : ApiController
    {
        private ActivityRepository activityRepository;

        public ActivityController()
        {
            this.activityRepository = new ActivityRepository();
        }

        public List<CActivity> Get(int id)
        {
            return activityRepository.getActivity(id);
        }

        public List<CActivity> Get()
        {
            return activityRepository.getActivities();
        }

        public List<CActivity> Get(string year)
        {
            return activityRepository.getActivities(year);
        }

        public List<CActivity> Get(string year, int limit, int page)
        {
            return activityRepository.getActivities(year, limit, page);
        }

        public CActivity2 Get(string year, string userid)
        {
            return activityRepository.getRecentActivity(year, userid);
        }
    }
}
