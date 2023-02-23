using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class SummaryController : ApiController
    {
        private SummaryRepository SummaryRepository;

        public SummaryController()
        {
            this.SummaryRepository = new SummaryRepository();
        }

        public List<Section> Get(string team, string level = "state", string year = "2019")
        {
            return SummaryRepository.GetTblSummaryList(team, level, year);
        }
    }
}
