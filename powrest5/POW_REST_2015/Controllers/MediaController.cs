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
    public class MediaController : ApiController
    {
        private MediaRepository mediaRepository;

        public MediaController()
        {
            this.mediaRepository = new MediaRepository();
        }           
                
        public List<CMedium> Get(string year)
        {
            return mediaRepository.getMedia(year);
        }

        public List<CMedium> Get(string year, string userid)
        {
            return mediaRepository.getMedia(year, userid);
        }

    }
}
