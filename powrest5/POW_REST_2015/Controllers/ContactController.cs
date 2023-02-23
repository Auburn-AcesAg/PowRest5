using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using POW_REST_2015.Services;


namespace POW_REST_2015.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }           
                
        public List<CContact> Get(string year)
        {
            return contactRepository.getContacts(year);
        }

        public List<CContact> Get(string year, int limit, int page)
        {
            return contactRepository.getContacts(year, limit, page);
        }

        public List<CContact> Get(string year, string activityid, string type)
        {
            return contactRepository.getContacts(year, activityid, type);
        }      

        public List<CContact> Get(string year, string activityid, string type, string userid)
        {
            return contactRepository.getContacts(year, activityid, type, userid);
        }
              
        public List<CContact> Get(string year, string activityid, string type, string userid, string format, string format1)
        {
            return contactRepository.getContacts(year, activityid, type, userid, format, format1);
        }

          
        public HttpResponseMessage Get(string domain, string year, string id, string filename, string option)
        {
            try
            {
                string filePath = @"C:\files\pow\" + "2015" + @"\" + id + @"\" + filename;               
                if (File.Exists(filePath))
                {
                    using (FileStream filestream = File.OpenRead(filePath))
                    {
                        MemoryStream file = new MemoryStream();
                        file.SetLength(filestream.Length);
                        filestream.Read(file.GetBuffer(), 0, (int)filestream.Length);
                        
                        if (file == null)
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound);
                        }
                        else
                        {
                            file.Position = 0;
                            HttpResponseMessage response = new HttpResponseMessage();
                            response.StatusCode = HttpStatusCode.OK;
                            response.Content = new StreamContent(file);
                            response.Headers.Add("content-disposition", "attachment; filename=" + filename);

                            return response;
                        }
                    }                  
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }            
               
            }
            catch (IOException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

 
    }
}
