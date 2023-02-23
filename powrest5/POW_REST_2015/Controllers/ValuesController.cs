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
    public class CommonController : ApiController
    {
        private CommonRepository commonRepository;

        public CommonController()
        {
            this.commonRepository = new CommonRepository();
        }      

        public List<CMonth> Get(string type)
        {
            return commonRepository.getMonths();
        }
    }
}