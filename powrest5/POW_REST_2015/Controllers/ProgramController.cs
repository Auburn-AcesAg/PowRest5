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
    public class ProgramController : ApiController
    {
        private CommonRepository commonRepository;

        public ProgramController()
        {
            this.commonRepository = new CommonRepository();
        }      

        public List<CProgram> Get(string type, string year = "2017")
        { 
            return commonRepository.getPrograms(type, year);   
        }
    }
}
