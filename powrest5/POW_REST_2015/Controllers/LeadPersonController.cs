using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class LeadPersonController : ApiController
    {
        private CommonRepository commonRepository;

        public LeadPersonController()
        {
            this.commonRepository = new CommonRepository();
        }      

        public List<CLeadPerson> Get(string year)
        { 
            return commonRepository.getLeadPersons(year);           
        }

    }
}
