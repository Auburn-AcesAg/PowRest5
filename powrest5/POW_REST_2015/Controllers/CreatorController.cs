using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;


namespace POW_REST_2015.Controllers
{
    public class CreatorController : ApiController
    {
        private CommonRepository commonRepository;

        public CreatorController()
        {
            this.commonRepository = new CommonRepository();
        }      

        public List<CCreator> Get(string year, string type, string orderby)
        { 
            return commonRepository.getCreators(year, type, orderby);           
        }

        public List<CCreator> Get(string year, string type)
        {
            return commonRepository.getCreators(year, type, "CreatorName");
        }

        public List<CCreator> Get(string year)
        {
            return commonRepository.getCreators(year, "All", "CreatorName");
        }      

        public CCreator GetUserID(string UserID)
        {
            return commonRepository.getCreator(UserID);
        }
    }
}
