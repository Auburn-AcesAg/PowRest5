using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CMedium
    {
        static Models.PowEntities2 context = new Models.PowEntities2();

        private string _CreatorID;
        private string _Creator;

        public int ID { get; set; }
        public string Title { get; set; }      
        public string Creator 
        {
            get { return _Creator != "" ? _Creator : (from e in context.PowUsers where e.Name.ToLower().Contains(CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(); }
            set { _Creator = value; }
        }

        public string CreatorID
        {
            get { return (_CreatorID.Contains("@")) ? _CreatorID.Split('@')[0] : _CreatorID; }
            set { _CreatorID = value; }
        }

        public string Program { get; set; }
        public string Month { get; set; }
        public string County { get; set; }
        public string Impact { get; set; }
        public string Feedback { get; set; }    
        public string Year { get; set; }        
        public string FileLink { get; set; }     
        public Nullable<System.DateTime> Modified { get; set; }
        public string Project { get; set; }
        public string ProjectID { get; set; }

        public List<string> Members { get; set; }
        public List<CFileLink> FileLinks
        {
            get
            {
                try
                {
                    if (Year == "2014")
                    {

                    }
                    else
                    {
                        string pathString = "C:\\files\\Media\\2015\\" + this.ID.ToString() + "\\";
                        if (System.IO.Directory.Exists(pathString))
                        {
                            string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                            List<CFileLink> fileList = new List<CFileLink>();
                            foreach (string s in strFiles)
                            {
                                CFileLink f = new CFileLink();
                                f.name = s;
                                //f.link = System.Web.HttpUtility.UrlPathEncode("https://msapps.acesag.auburn.edu/Files/Media/2015/" + this.ID.ToString() + "/" + s);
                                f.link = "https://msapps.acesag.auburn.edu/Files/Media/2015/" + this.ID.ToString() + "/" + s;

                                fileList.Add(f);
                                
                            }
                            return fileList;
                        }
                    }

                    return null;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set
            {

            }

        }
    }
}