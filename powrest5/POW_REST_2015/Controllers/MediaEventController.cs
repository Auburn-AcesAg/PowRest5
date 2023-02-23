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
    public class MediaEventController : ApiController
    {
        private MediaRepository mediaRepository;

        public MediaEventController()
        {
            this.mediaRepository = new MediaRepository();
        }           
                
        public List<CMediaEvent> Get(string year)
        {
            return mediaRepository.getMediaEvents(year);
        }

        public List<CMediaEvent> Get(string year, string mediaID)
        {
            return mediaRepository.getMediaEvents(year, mediaID);
        }
    }
}
