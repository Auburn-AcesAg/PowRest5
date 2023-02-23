using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POW_REST_2015.Services;


namespace POW_REST_2015.Controllers
{
    public class AttendeesController : ApiController
    {
        private ContactRepository contactRepository;

        public AttendeesController()
        {
            this.contactRepository = new ContactRepository();
        }

        public Contact Get(string county, string year = "2018")
        {
            return contactRepository.getContactSummary(county, year);
        }
    }
}
