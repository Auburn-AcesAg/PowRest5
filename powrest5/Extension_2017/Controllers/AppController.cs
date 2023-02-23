using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Extension_2017.Providers;
using System.Web.Script.Serialization;
using System.Web;
using System.Text;
using System.IO;

using System.Web.Http.Filters;
using System.Web.Http.Controllers;


namespace Extension_2017.Controllers
{

    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required"
                };
            }
            else
            {
                System.Web.HttpContext.Current.Items["token"] = actionContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

                base.OnAuthorization(actionContext);
            }
        }
    }


    [RequireHttps]
    [Authorize]
    [RoutePrefix("api/App")]
    public class AppController : ApiController
    {
        private CDb db = new CDb();

        [Route("GetYears")]
        [HttpGet]
        public HttpResponseMessage GetYears()
        {
            try
            {
                // CLog.WriteToEventLog("GetDailyActivities : " + System.Web.HttpContext.Current.Items["token"].ToString());

                var a = db.GetYears();

                string json;
                JavaScriptSerializer s = new JavaScriptSerializer();
                json = s.Serialize(a);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        /* Activity */
        [Route("GetMyActivities")]
        [HttpGet]
        public HttpResponseMessage GetMyActivities(string userId, string year)
        {
            CLog.WriteToEventLog("GetMyActivities " + userId + " " + year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();

            var a = db.GetMyActivities(userId, year);
        
            json = s.Serialize(a);
            CLog.WriteToEventLog(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetActivity")]
        [HttpGet]
        public HttpResponseMessage GetActivity(int id)
        {
          //  CLog.WriteToEventLog("GetMyActivities " + userId + " " + year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();

            var a = db.GetActivity(id);

            json = s.Serialize(a);
            CLog.WriteToEventLog(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("SubmitActivity")]
        [HttpPost]
        public HttpResponseMessage SubmitActivity(CActivity a)
        {
            CLog.WriteToEventLog("SubmitActivity ");

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
          
            CLog.WriteToEventLog(json);

            DateTime startdate;
            DateTime enddate;

            try
            {
                if (a.eventtype.ToLower() == "arbitrary")
                {
                    startdate = DateTime.Now;
                    enddate = DateTime.Now;
                }
                else
                {
                    startdate = Convert.ToDateTime(a.strStartdate);
                    enddate = Convert.ToDateTime(a.strEnddate);

                    if (a.eventtype.ToLower() == "oneday" && enddate != startdate)
                    {
                        enddate = startdate;
                    }
                }

                string ActivityID = db.SetActivity(a.id, a.title, a.projectID, startdate, enddate, a.year, a.isUsed, a.eventtype, a.recurrence, a.updateMode, a.creatorID, a.participants,
                                        a.team, a.program, a.starttime, a.duration, a.isPublic, a.county, a.isOutlook, a.address, a.fee, a.phone, a.url, a.description,
                                        a.contactname, a.contactemail, a.announcecounty,
                                        a.Address2, a.State, a.City, a.ZipCode, a.IsRegistration, a.IsFee, a.Foap, a.IsAcknowledged, a.AttendeeLimit, a.TaxableMaterials
                                        );
                json = s.Serialize(ActivityID);                          

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                /*
                CLog.WriteToEventLog(e.ToString() + DateTime.Now + " ID:" + a.id + " Title:" + a.title + " ProjectID:" + a.projectID + " StartDate: " + a.strStartdate
                                + " EndDate:" + a.strEnddate + " Year:" + a.year
                                + " IsUsed:" + a.isUsed + " EventType:" + a.eventtype + " Recurrence:" + a.recurrence + " UpdateMode:" + a.updateMode
                                + " CreatorID:" + a.creatorID + " Participants:" + a.participants
                                + " Team:" + a.team + " Program:" + a.program + " StartTime:" + a.starttime + " Duration:" + a.duration
                                + " IsPublic:" + a.isPublic + " County:" + a.county);
                */
                CLog.WriteToEventLog(e.ToString());

                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                json = s.Serialize(e.ToString());
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [Route("SubmitActivityProject")]
        [HttpPost]
        public HttpResponseMessage SubmitActivityProject(string id, string activityid, string projectid, string isUsed, string projecttitle, string year)
        {

            CLog.WriteToEventLog("submitActivityProject : " + id + " " + activityid + " " + projectid + " " + isUsed + " " + projecttitle + " " + year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();            

            try
            {
                var a = db.setAcitivityProject(id, activityid, projectid, isUsed, projecttitle, year);
                json = s.Serialize(a);
             
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {   
                json = s.Serialize(e.ToString());
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [Route("SubmitActivityProjects")]
        [HttpPost]
        public HttpResponseMessage SubmitActivityProjects(ProjectActivity[] projectactivities)
        {
            CLog.WriteToEventLog("SubmitActivityProjects ");
            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(projectactivities);
            CLog.WriteToEventLog(projectactivities);

            db.setAcitivityProjects(projectactivities);

       //     json = s.Serialize(projectactivities);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
       

        [Route("GetDailyActivities")]
        [HttpGet]
        public HttpResponseMessage GetDailyActivities(string year, int month, int day)
        {
            try
            {
               // CLog.WriteToEventLog("GetDailyActivities : " + System.Web.HttpContext.Current.Items["token"].ToString());

                var a = db.GetActivities(year, month, day);

                string json;
                JavaScriptSerializer s = new JavaScriptSerializer();
                json = s.Serialize(a);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);               
                return response;
            }
        }

        [Route("GetDailyActivities2")]
        [HttpGet]
        public HttpResponseMessage GetDailyActivities2(string year, int month, int day)
        {
            try
            {
                // CLog.WriteToEventLog("GetDailyActivities : " + System.Web.HttpContext.Current.Items["token"].ToString());

                var a = db.GetActivities2(year, month, day);

                string json;
                JavaScriptSerializer s = new JavaScriptSerializer();
                json = s.Serialize(a);

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [Route("GetMonthlyActivities")]
        [HttpGet]
        public HttpResponseMessage GetMonthlyActivities(string year, int month)
        {
            var a = db.GetActivities(year, month);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);


         //   CLog.WriteToEventLog("GetDailyActivities : " + System.Web.HttpContext.Current.Items["token"].ToString());

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetReports")]
        [HttpGet]
        public HttpResponseMessage GetReports(int activityId, string contactType)
        {
            CLog.WriteToEventLog("GetReports : Activity ID : " + activityId + " Type : " + contactType);

            var a = db.GetReports(activityId, contactType);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetReports2")]
        [HttpGet]
        public HttpResponseMessage GetReports2(int activityId, string contactType)
        {
            CLog.WriteToEventLog("GetReports : Activity ID : " + activityId + " Type : " + contactType);

            var a = db.GetReports2(activityId, contactType);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetMyReports")]
        [HttpGet]
        public HttpResponseMessage GetMyReports(string userId, string contactType, string year)
        {
            CLog.WriteToEventLog("GetMyReports : " + userId + " " + contactType + " " + year);

            var a = db.GetReports(userId, contactType, year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            CLog.WriteToEventLog(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetMyReports2")]
        [HttpGet]
        public HttpResponseMessage GetMyReports2(string userId, string contactType, string year)
        {
            CLog.WriteToEventLog("GetMyReports : " + userId + " " + contactType + " " + year);

            var a = db.GetReports2(userId, contactType, year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            CLog.WriteToEventLog(a);

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

        [Route("GetSignRequest")]
        [HttpGet]
        public HttpResponseMessage GetSignRequest(string userId)
        {
            string ikey = "DIE62Y4L5PJHMCHFRGAG";
            string skey = "uO7D9pNnTfAk5QIkWK14PeQWcXc1cR05EDx0foVK";
            string akey = "vKaNvggpaGKNaTRDWpUbAeeLxPCrCVJvyAqtFUnyF";
            var signRequest = Duo.Web.SignRequest(ikey, skey, akey, userId);

            JavaScriptSerializer s = new JavaScriptSerializer();
            string json = s.Serialize(signRequest);
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
            CLog.WriteToEventLog("SubmitAttendees " + json);

            int id = 0;
            try
            {
                if (report.version == 2)
                {
                    id = db.SaveReport(report);
                    CReport ret = db.GetReport2(id);
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    json = s.Serialize(ret);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    return response;
                }
                else
                {
                    var ret = "Update your POW App to submit Attendance report."; 
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    //id = db.SaveReport(report);
                    //CReport ret = db.GetReport(id);
                    json = s.Serialize(ret);
                    response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    return response;
                }
            }
            catch (Exception e)
            {
                CLog.WriteToEventLog(e.ToString());
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                json = s.Serialize(e.ToString());
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [Route("DeleteReport")]
        [HttpGet]
        public HttpResponseMessage DeleteReport(int id, string type)
        {
            CLog.WriteToEventLog("DeleteReport " + id + " " + type);

            var a = db.DeleteReport(id, type);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);

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

            //CLog.WriteToEventLog("1");

            try
            {
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

                    string pathString = "C:\\files\\Pow\\2015\\" + imageid.ToString() + "\\";
                    System.IO.Directory.CreateDirectory(pathString);
                    string filePath = Path.Combine(pathString, fname);

                    postedFile.SaveAs(filePath);

                    retURL = "https://msapps.acesag.auburn.edu/files/pow/2015/" + imageid.ToString() + "/" + fname;

                }
            }
            catch (Exception e)
            {
                //sending error to an email id
                CLog.WriteToEventLog(e.ToString());
                return Ok(new { status = "Error" });
            }

            return Ok(new { status = "OK", newfilepath = retURL });
        }                      

       
        [Route("GetMyProjects")]
        [HttpGet]
        public HttpResponseMessage GetMyProjects(string userId, string type, string year)
        {
            CLog.WriteToEventLog("GetMyProjects " + userId + " " + type + " " + year);

            var a = db.GetMyProjects(userId, type, year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
       //     CLog.WriteToEventLog(json);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetProjects")]
        [HttpGet]
        public HttpResponseMessage GetProjects(string type, string team, string program, string year)
        {
            var a = db.GetProjects(year, type, team, program);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
         //   CLog.WriteToEventLog(json);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("GetActivityProjects")]
        [HttpGet]
        public HttpResponseMessage GetActivityProjects(string year, int id)
        {
            var a = db.getActivityProjects(id, year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            //   CLog.WriteToEventLog(json);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        
        [Route("GetMediaTypes")]
        [HttpGet]
        public HttpResponseMessage GetMediaTypes(string year)
        {
            var a = db.getMediaTypes(year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            //   CLog.WriteToEventLog(json);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        
        [Route("GetEventTypes")]
        [HttpGet]
        public HttpResponseMessage GetEventTypes(string mediaTypeId)
        {
            var a = db.getEventTypes(mediaTypeId);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            //   CLog.WriteToEventLog(json);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [Route("SubmitMedia")]
        [HttpPost]
        public HttpResponseMessage SubmitMedia(CMedia m)
        {
            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(m);
            CLog.WriteToEventLog("SubmitMedia " + json);
            
            try
            {
                int id = db.createMedia(m);
                json = s.Serialize(id);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                json = s.Serialize(e.ToString());
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }

        [Route("SubmitMediaEvents")]
        [HttpPost]
        public HttpResponseMessage SubmitMediaEvents(CMediaEvent[] events)
        {
            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(events);
            CLog.WriteToEventLog("SubmitMediaEvents " + json);

            try
            {
                db.createMediaEvents(events);
                json = s.Serialize("Ok");
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception e)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                json = s.Serialize(e.ToString());
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }
        
        [Route("SubmitMediaImage")]
        [HttpPost]
        public IHttpActionResult SubmitMediaImage(int id)
        {
            string retURL = "";

            var httpRequest = HttpContext.Current.Request;

            // string siteid = httpRequest.QueryString["siteId"].ToString();
            // string username = User.Identity.Name;
            
            CLog.WriteToEventLog("SubmitMediaImage " + id);

            try
            {
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

                    string pathString = "C:\\files\\Media\\2015\\" + imageid.ToString() + "\\";
                    System.IO.Directory.CreateDirectory(pathString);
                    string filePath = Path.Combine(pathString, fname);

                    postedFile.SaveAs(filePath);

                    retURL = "https://msapps.acesag.auburn.edu/files/media/2015/" + imageid.ToString() + "/" + fname;

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


        [Route("DeleteImage")]
        [HttpGet]
        public HttpResponseMessage DeleteImage(string fileLink)
        {
              CLog.WriteToEventLog("DeleteImage " + fileLink);

              var a = db.deleteFile(fileLink);

              string json;
              JavaScriptSerializer s = new JavaScriptSerializer();
              json = s.Serialize(a);        

              var response = this.Request.CreateResponse(HttpStatusCode.OK);
              response.Content = new StringContent(json, Encoding.UTF8, "application/json");
              return response;
        }


        [Route("GetMyMediaReports")]
        [HttpGet]
        public HttpResponseMessage GetMyMediaReports(string userId, string year)
        {
            CLog.WriteToEventLog("GetMyMediaReports " + userId + " " + year );

            var a = db.getMediaReports(userId, year);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            
            CLog.WriteToEventLog(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }


        [Route("GetMediaEvents")]
        [HttpGet]
        public HttpResponseMessage GetMediaEvents(int mediaId)
        {
            CLog.WriteToEventLog("GetMediaEvents " + mediaId.ToString());

            var a = db.getMediaEvents(mediaId);

            string json;
            JavaScriptSerializer s = new JavaScriptSerializer();
            json = s.Serialize(a);
            CLog.WriteToEventLog(a);

            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

    }
}