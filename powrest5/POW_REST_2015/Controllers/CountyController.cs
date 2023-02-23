using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class CountyController : ApiController
    {
        private CommonRepository commonRepository;
        private AdvisorRepository AdvisorRepository;

        public CountyController()
        {
            this.commonRepository = new CommonRepository();
            this.AdvisorRepository = new AdvisorRepository();
        }      

        public List<CCounty> Get()
        { 
            return commonRepository.getCounty();   
        }

        // public List<CCounty2> Get(string type, string year = "2021") slm
        public List<CCounty2> Get(string type, string year = "2022")   /*slm: changed to 2022 from 2021*/
        {
            return commonRepository.getCounty(type, year);   
        }

        public List<CivilRight> get(string type, string county)
        {
            if (type.ToLower() == "civilright")
                return AdvisorRepository.getOtherAdvisors(county);           
            else
                return null;
        }

        public List<Audit> get(string type, string county, string job, string year = "2018")
        {

            if (type.ToLower() == "audit" && job.ToLower() == "rea")
                return AdvisorRepository.GetAudits(county, year);
            else
                return null;
        }
    }
}
