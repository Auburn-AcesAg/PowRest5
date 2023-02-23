using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;

namespace POW_REST_2015.Controllers
{
    public class AuditController : ApiController
    {
        private AdvisorRepository AdvisorRepository;

        public AuditController()
        {
            this.AdvisorRepository = new AdvisorRepository();
        }
        public List<DeskAudit> get(string county, string isSubmitted = "none", string type = "deskaudit")
        {
            if (type.ToLower() == "deskaudit")
                return AdvisorRepository.GetDeskAudits(county, isSubmitted);
            else
                return null;
        }
    }
}
