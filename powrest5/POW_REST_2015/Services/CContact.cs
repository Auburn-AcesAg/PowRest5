using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CFileLink
    {
        public string link { get; set; }
        public string name { get; set; }
    }

    public class CContact
    {
        public int ows_ID { get; set; }
        public string ows_Title { get; set; }
        public Nullable<System.DateTime> ows_StartDate { get; set; }
        public Nullable<System.DateTime> ows_EndDate { get; set; }
        public Nullable<int> ows_ActivityID { get; set; }

        private Nullable<int> ows_Attendees_temp;

        public Nullable<int> ows_Attendees
        {
            get
            {
                int y;
                if (int.TryParse(this.ows_Year.Trim(), out y) && y >= 2017 && y <= 2018)
                {
                    /*
                    int m;                        
                    int unftf = int.TryParse(this.ows_unftf.Trim(), out m) ? m : 0;

                    return (this.ows_Attendees_temp - unftf);
                    */


                    int rm, um, rf, uf, ms;
                    int rmale = int.TryParse(this.ows_rmale.Trim(), out rm) ? rm : 0;
                    int umale = int.TryParse(this.ows_umale.Trim(), out um) ? um : 0;
                    int rfemale = int.TryParse(this.ows_rfmale.Trim(), out rf) ? rf : 0;
                    int ufemale = int.TryParse(this.ows_ufmale.Trim(), out uf) ? uf : 0;
                    int multi = int.TryParse(this.ows_MultiState.Trim(), out ms) ? ms : 0;

                    return (rmale + umale + rfemale + ufemale + multi);

                }
                else if (int.TryParse(this.ows_Year.Trim(), out y) && y >= 2019)
                {
                    int rm, um, rf, uf;
                    int rmale = this.ows_rmale == null ? 0 : int.TryParse(this.ows_rmale.Trim(), out rm) ? rm : 0;
                    int umale = this.ows_umale == null ? 0 : int.TryParse(this.ows_umale.Trim(), out um) ? um : 0;
                    int rfemale = this.ows_rfmale == null ? 0 : int.TryParse(this.ows_rfmale.Trim(), out rf) ? rf : 0;
                    int ufemale = this.ows_ufmale == null ? 0 : int.TryParse(this.ows_ufmale.Trim(), out uf) ? uf : 0;
                    // int multi = int.TryParse(this.ows_MultiState.Trim(), out ms) ? ms : 0;

                    return (rmale + umale + rfemale + ufemale);
                }
                else {
                    /*
                     int n; int m;
                     int rnftf = int.TryParse(this.ows_rnftf.Trim(), out n) ? n : 0;
                     int unftf = int.TryParse(this.ows_unftf.Trim(), out m) ? m : 0;

                     return (this.ows_Attendees_temp - (rnftf + unftf));
                    */
                    int rm, um, rf, uf;
                    int rmale = int.TryParse(this.ows_rmale.Trim(), out rm) ? rm : 0;
                    int umale = int.TryParse(this.ows_umale.Trim(), out um) ? um : 0;
                    int rfemale = int.TryParse(this.ows_rfmale.Trim(), out rf) ? rf : 0;
                    int ufemale = int.TryParse(this.ows_ufmale.Trim(), out uf) ? uf : 0;

                    return (rmale + umale + rfemale + ufemale);
                }
            }

            set
            {
                this.ows_Attendees_temp = value;
            }
        }

        public string ows_ContactType { get; set; }
        public string ows_Program { get; set; }
        public string ows_Year { get; set; }
        public string ows_Description { get; set; }
        public string ows_CreatorID { get; set; }
        public string ows_Creator { get; set; }
        public string ows_IsUsed { get; set; }
        public string ows_Evaluation { get; set; }
        public string ows_ExternalFactor { get; set; }
        public string ows_Outcomes { get; set; }
        public string ows_County { get; set; }
        public string ows_IsPlan { get; set; }

        public string ows_raian { get; set; }
        public string ows_rapi { get; set; }
        public string ows_rblack { get; set; }
        public string ows_rfmale { get; set; }
        public string ows_rhisp { get; set; }
        public string ows_rmale { get; set; }
        public string ows_rnftf { get; set; }
        public string ows_rother { get; set; }
        public string ows_rwhite { get; set; }
        public string ows_ryouth { get; set; }
        public string ows_uadult { get; set; }
        public string ows_uaian { get; set; }
        public string ows_uapi { get; set; }
        public string ows_ublack { get; set; }
        public string ows_ufmale { get; set; }
        public string ows_uhisp { get; set; }
        public string ows_umale { get; set; }
        public string ows_unftf { get; set; }
        public string ows_uother { get; set; }
        public string ows_uwhite { get; set; }
        public string ows_uyouth { get; set; }
        public string ows_radult { get; set; }
        public string ows_rMore { get; set; }
        public string ows_uMore { get; set; }

        public string ows_MultiState { get; set; }

        // 12/6/2018 June Shin
        public string ows_mraian { get; set; }
        public string ows_mrapi { get; set; }
        public string ows_mrblack { get; set; }
        public string ows_mrfmale { get; set; }
        public string ows_mrhisp { get; set; }
        public string ows_mrmale { get; set; }
        public string ows_mrother { get; set; }
        public string ows_mrwhite { get; set; }
        public string ows_mryouth { get; set; }
        public string ows_muadult { get; set; }
        public string ows_muaian { get; set; }
        public string ows_muapi { get; set; }
        public string ows_mublack { get; set; }
        public string ows_mufmale { get; set; }
        public string ows_muhisp { get; set; }
        public string ows_mumale { get; set; }
        public string ows_muother { get; set; }
        public string ows_muwhite { get; set; }
        public string ows_muyouth { get; set; }
        public string ows_mradult { get; set; }
        public string ows_mrMore { get; set; }
        public string ows_muMore { get; set; }
        public bool? ows_IsMultiState { get; set; }

        public string ows_unknown { get; set; }
        public string ows_munknown { get; set; }

        // 1/7/2020
        public string ows_unonhisp { get; set; }
        public string ows_rnonhisp { get; set; }
        public string ows_munonhisp { get; set; }
        public string ows_mrnonhisp { get; set; }


        public string ows_unknownGender { get; set; }
        public string ows_unknownAge { get; set; }
        public string ows_unknownRace { get; set; }
        public string ows_unknownEth { get; set; }
        public string ows_munknownGender { get; set; }
        public string ows_munknownAge { get; set; }
        public string ows_munknownRace { get; set; }
        public string ows_munknownEth { get; set; }


        public Nullable<System.DateTime> ows_Created { get; set; }
        public Nullable<System.DateTime> ows_Modified { get; set; }
        
        public string ows_FileLink { get; set; }

        public List<CFileLink> ows_FileLinks
        {            
            get{
                try
                {
                    string pathString = "C:\\files\\Pow\\2015\\" + this.ows_ID.ToString() + "\\";                    
                    if(System.IO.Directory.Exists(pathString) )
                    {
                        string[] strFiles = System.IO.Directory.GetFiles(pathString).Select(path => System.IO.Path.GetFileName(path)).ToArray();

                        List<CFileLink> fileList = new List<CFileLink>();
                        foreach (string s in strFiles)
                        {
                            CFileLink f = new CFileLink();
                            f.name = s;
                            f.link = "https://msapps.acesag.auburn.edu/Files/Pow/2015/" + this.ows_ID.ToString() + "/" + s;

                            fileList.Add(f);
                            //fileList.Add("https://msapps.acesag.auburn.edu/Files/Pow/2015/" + this.ows_ID.ToString() + "/" + s);
                        }
                        return fileList;
                    }

                    return null;

                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set { 
            
            }        
          
        }
    }
}