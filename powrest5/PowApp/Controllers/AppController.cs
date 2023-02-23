   using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PowApp.Providers;
using System.Web.Script.Serialization;
using System.Web;
using System.Text;
using System.IO;

namespace PowApp.Controllers
{
    [RoutePrefix("api/App")]
    public class AppController : ApiController
    {
        private CDb db = new CDb();

        [Route("GetDailyActivities")]
        [HttpGet]
        public HttpResponseMessage GetDailyActivities(string year, int month, int day)
        {
            var a = db.GetActivities(year, month, day);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
            
        }

        [Route("GetReports")]
        [HttpGet]
        public HttpResponseMessage GetReports(int activityId, string contactType)
        {
            var a = db.GetReports(activityId, contactType);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;

        }

        [Route("GetUserInfo1")]
        [HttpGet]
        public HttpResponseMessage GetUserInfo1(string userid)
        {
            var a = db.GetUserInfo1(userid);

            //      CLog.WriteToEventLog(userid);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;

        }


        [Route("GetUserInfo")]
        [HttpGet]
        public HttpResponseMessage GetUserInfo(string userid)
        {
            var a = db.GetUserInfo(userid);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;

        }

        [Route("SubmitAttendees")]
        [HttpPost]
        public HttpResponseMessage SubmitAttendees(CReport report)
        {
            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(report);
            CLog.WriteToEventLog(json);

            try
            {
                db.SaveReport(report);
            }
            catch(Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
            }


            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }


        [Route("IsAlive")]
        [HttpGet]
        public HttpResponseMessage IsAlive()
        {

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(new { status = "OK" });
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;

        }

        [Route("SubmitImage")]
        [HttpPost]
        public IHttpActionResult SubmitImage(int id)
        {
            string retURL = "";

            var httpRequest = HttpContext.Current.Request;

           // string siteid = httpRequest.QueryString["siteId"].ToString();
           // string username = User.Identity.Name;

            CLog.WriteToEventLog("1");

            try{
                if (httpRequest.Files.Count < 1)
                {
                    return Ok(new { status = "no file" });
                }

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    //var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    //postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream

               
                        // setting the file location to be saved in the server. 
                        // reading from the web.config file 
                        string fname = postedFile.FileName;

                        int imageid = id;

                        string pathString = "C:\\files\\PowApp\\" + imageid.ToString() + "\\";
                        System.IO.Directory.CreateDirectory(pathString);
                        string filePath = Path.Combine(pathString, fname);

                        postedFile.SaveAs(filePath);

                        retURL = "https://msapps.acesag.auburn.edu/files/powapp/" + imageid.ToString() + "/" + fname;
               
                }
            }
            catch (Exception e)
            {
                //sending error to an email id
                CLog.WriteToEventLog(e.ToString() + DateTime.Now.ToString());
                return Ok(new { status = "Error" });
            }

            return Ok(new { status = "OK", newfilepath = retURL });
        }
    }
}
