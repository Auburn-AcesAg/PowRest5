using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Models;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class TeamController : ApiController
    {
        private CommonRepository commonRepository;

        public TeamController()
        {
            this.commonRepository = new CommonRepository();
        }

        public List<CTeam> Get(string type, string year = "2017")
        {
           return commonRepository.getTeams(type, year);     
        }

        public List<CTeam> Get(string type, string LeadTeam, string year = "2017")
        {
            return commonRepository.getTeamsForAdditionalTeam(type, LeadTeam, year);
        }

    }
}
