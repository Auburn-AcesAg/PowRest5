using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace POW_REST_2015.Services
{
    public class Contact
    {
        public Nullable<int> activities { get; set; }
      
        public Nullable<double> raian { get; set; }
        public Nullable<double> rapi { get; set; }
        public Nullable<double> rblack { get; set; }
        public Nullable<double> rfmale { get; set; }
        public Nullable<double> rhisp { get; set; }
        public Nullable<double> rmale { get; set; }
        public Nullable<double> rother { get; set; }
        public Nullable<double> rwhite { get; set; }
        public Nullable<double> ryouth { get; set; }
        public Nullable<double> uadult { get; set; }
        public Nullable<double> uaian { get; set; }
        public Nullable<double> uapi { get; set; }
        public Nullable<double> ublack { get; set; }
        public Nullable<double> ufmale { get; set; }
        public Nullable<double> uhisp { get; set; }
        public Nullable<double> umale { get; set; }
        public Nullable<double> uother { get; set; }
        public Nullable<double> uwhite { get; set; }
        public Nullable<double> uyouth { get; set; }
        public Nullable<double> radult { get; set; }
        public Nullable<double> rMore { get; set; }
        public Nullable<double> uMore { get; set; }
        public Nullable<double> demo_instate { get; set; }
        public Nullable<double> nondemo_instate { get; set; }
        public Nullable<double> demo_outofstate { get; set; }
        public Nullable<double> nondemo_outofstate { get; set; }
    }

    public class ContactRepository
    {      
        public List<CContact> getContacts(string year)
        {
            var context = new Models.PowEntities2();

            int nYear;
            if (int.TryParse(year, out nYear))
            {
                var q = (from c in context.Contacts where c.IsUsed == "Yes" && c.Year == year select c).ToList();

                List<CContact> contacts = new List<CContact>();
                foreach (var c in q)
                {
                    CContact contact = new CContact
                    {
                        ows_ID = c.ID,
                        //ows_Title = c.Title,
                        ows_Title = (c.ContactType == "Activity") ? (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault() : c.Title,
                        ows_StartDate = c.StartDate,
                        ows_EndDate = c.EndDate,
                        ows_ActivityID = c.ActivityID,
                        ows_Attendees = c.Attendees,
                        ows_ContactType = c.ContactType,
                        ows_Program = c.Program,
                        ows_Year = c.Year,
                        ows_Description = c.Description,
                        ows_CreatorID = c.CreatorID,
                        ows_Creator = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                        ows_IsUsed = c.IsUsed,
                        ows_Evaluation = c.Evaluation,
                        ows_ExternalFactor = c.ExternalFactor,
                        ows_Outcomes = c.Outcomes,
                        ows_FileLink = c.FileLink,
                        ows_County = ConvertSetCounty(c.County),
                        ows_IsPlan = c.IsPlan,
                        ows_raian = c.raian,
                        ows_rapi = c.rapi,
                        ows_rblack = c.rblack,
                        ows_rfmale = c.rfmale,
                        ows_rhisp = c.rhisp,
                        ows_rmale = c.rmale,
                        ows_rnftf = "",
                        ows_rother = c.rother,
                        ows_rwhite = c.rwhite,
                        ows_ryouth = c.ryouth,
                        ows_uadult = c.uadult,
                        ows_uaian = c.uaian,
                        ows_uapi = c.uapi,
                        ows_ublack = c.ublack,
                        ows_ufmale = c.ufmale,
                        ows_uhisp = c.uhisp,
                        ows_umale = c.umale,
                        //ows_unftf = c.unftf,
                        ows_unftf = "",
                        ows_uother = c.uother,
                        ows_uwhite = c.uwhite,
                        ows_uyouth = c.uyouth,
                        ows_radult = c.radult,
                        ows_rMore = c.rMore,
                        ows_uMore = c.uMore,
                        ows_Created = c.Created,
                        ows_Modified = c.Modified,
                        ows_MultiState = nYear >= 2017 ? c.rnftf : "",

                        /* 12/6/2018 */
                        ows_mraian = c.mraian,
                        ows_mrapi = c.mrapi,
                        ows_mrblack = c.mrblack,
                        ows_mrfmale = c.mrfmale,
                        ows_mrhisp = c.mrhisp,
                        ows_mrmale = c.mrmale,
                        ows_mrother = c.mrother,
                        ows_mrwhite = c.mrwhite,
                        ows_mryouth = c.mryouth,
                        ows_muadult = c.muadult,
                        ows_muaian = c.muaian,
                        ows_muapi = c.muapi,
                        ows_mublack = c.mublack,
                        ows_mufmale = c.mufmale,
                        ows_muhisp = c.muhisp,
                        ows_mumale = c.mumale,
                        ows_muother = c.muother,
                        ows_muwhite = c.muwhite,
                        ows_muyouth = c.muyouth,
                        ows_mradult = c.mradult,
                        ows_mrMore = c.mrMore,
                        ows_muMore = c.muMore,

                        /* 1/7/2020 */
                        ows_unonhisp = c.uNonHispanic,
                        ows_rnonhisp =   c.rNonHispanic ,
                        ows_munonhisp =  c.muNonHispanic,
                        ows_mrnonhisp = c.mrNonHispanic,

                        /* 8/24/2020 */
                        ows_unknown = c.unknown,

                        /* 12/3/2020 */
                        ows_munknown = c.munknown,

                        /* 12/6/2021 */
                        ows_unknownGender = c.unknownGender,
                        ows_unknownAge = c.unknownAge,
                        ows_unknownRace = c.unknownRace,
                        ows_unknownEth = c.unknownEth,
                        ows_munknownGender = c.munknownGender,
                        ows_munknownAge = c.munknownAge,
                        ows_munknownRace = c.munknownRace,
                        ows_munknownEth = c.munknownEth
                    };

                    contacts.Add(contact);
                }                     

                return contacts.ToList();
            }
            else
            {
                return null;
            }
        }
        
        public List<CContact> getContacts(string year, int limit, int page)
        {
            var context = new Models.PowEntities2();

             int nYear;
            if (int.TryParse(year, out nYear))
            {

                var q = (from c in context.Contacts
                         where c.IsUsed == "Yes" && c.Year == year
                         orderby c.ID select c).ToList();

                List<CContact> contacts = new List<CContact>();

                foreach(var c in q)
                {
                    CContact contact = new CContact
                    {
                        ows_ID = c.ID,
                        //ows_Title = c.Title,
                        //ows_Title = (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault(),
                        ows_Title = (c.ContactType == "Activity") ? (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault() : c.Title,
                        ows_StartDate = c.StartDate,
                        ows_EndDate = c.EndDate,
                        ows_ActivityID = c.ActivityID,
                        ows_Attendees = c.Attendees,
                        ows_ContactType = c.ContactType,
                        ows_Program = (c.Program == null) ? "" : c.Program,
                        ows_Year = c.Year,
                        ows_Description = c.Description,
                        ows_CreatorID = c.CreatorID,
                        ows_Creator = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                        ows_IsUsed = c.IsUsed,
                        ows_Evaluation = c.Evaluation,
                        ows_ExternalFactor = c.ExternalFactor,
                        ows_Outcomes = c.Outcomes,
                        ows_FileLink = c.FileLink,
                        ows_County = ConvertSetCounty(c.County),
                        ows_IsPlan = c.IsPlan,
                        ows_raian = c.raian,
                        ows_rapi = c.rapi,
                        ows_rblack = c.rblack,
                        ows_rfmale = c.rfmale,
                        ows_rhisp = c.rhisp,
                        ows_rmale = c.rmale,
                        ows_rnftf = "",
                        ows_rother = c.rother,
                        ows_rwhite = c.rwhite,
                        ows_ryouth = c.ryouth,
                        ows_uadult = c.uadult,
                        ows_uaian = c.uaian,
                        ows_uapi = c.uapi,
                        ows_ublack = c.ublack,
                        ows_ufmale = c.ufmale,
                        ows_uhisp = c.uhisp,
                        ows_umale = c.umale,
                        //ows_unftf = c.unftf,
                        ows_unftf = "",
                        ows_uother = c.uother,
                        ows_uwhite = c.uwhite,
                        ows_uyouth = c.uyouth,
                        ows_radult = c.radult,
                        ows_rMore = c.rMore,
                        ows_uMore = c.uMore,
                        ows_Created = c.Created,
                        ows_Modified = c.Modified,
                        ows_MultiState = nYear >= 2017 ? c.rnftf : "",

                        /* 12/6/2018 */
                        ows_mraian = c.mraian,
                        ows_mrapi = c.mrapi,
                        ows_mrblack = c.mrblack,
                        ows_mrfmale = c.mrfmale,
                        ows_mrhisp = c.mrhisp,
                        ows_mrmale = c.mrmale,
                        ows_mrother = c.mrother,
                        ows_mrwhite = c.mrwhite,
                        ows_mryouth = c.mryouth,
                        ows_muadult = c.muadult,
                        ows_muaian = c.muaian,
                        ows_muapi = c.muapi,
                        ows_mublack = c.mublack,
                        ows_mufmale = c.mufmale,
                        ows_muhisp = c.muhisp,
                        ows_mumale = c.mumale,
                        ows_muother = c.muother,
                        ows_muwhite = c.muwhite,
                        ows_muyouth = c.muyouth,
                        ows_mradult = c.mradult,
                        ows_mrMore = c.mrMore,
                        ows_muMore = c.muMore,
                        ows_IsMultiState = c.IsMultistate,

                         /* 1/7/2020 */
                        ows_unonhisp = c.uNonHispanic,
                        ows_rnonhisp = c.rNonHispanic,
                        ows_munonhisp = c.muNonHispanic,
                        ows_mrnonhisp = c.mrNonHispanic,

                        /* 8/24/2020 */
                        ows_unknown = c.unknown,

                        /* 12/3/2020 */
                        ows_munknown = c.munknown,

                        /* 12/6/2021 */
                        ows_unknownGender = c.unknownGender,
                        ows_unknownAge = c.unknownAge,
                        ows_unknownRace = c.unknownRace,
                        ows_unknownEth = c.unknownEth,
                        ows_munknownGender = c.munknownGender,
                        ows_munknownAge = c.munknownAge,
                        ows_munknownRace = c.munknownRace,
                        ows_munknownEth = c.munknownEth

                    };

                    contacts.Add(contact);
                }   

                return contacts.Skip(limit * (page - 1)).Take(limit).ToList();
            }
            else
            {
                return null;
            }
        }

        public string ConvertSetCounty(string setcounty)
        {
            if (setcounty == null || setcounty == "") return setcounty;

            string counties = "";

            string[] splits = setcounty.Split(';');
            foreach (var s in splits)
            {
                var temp = s;
                if (s.StartsWith("SET"))
                {
                    temp = ConvertSetToCounty(s.Replace("SET", ""));
                }
                counties = counties + temp + ";";
            }

            return string.Join(";", counties.Split(';').Distinct().ToList());
        }


        public string ConvertSetToCounty(string setNo)
        {
            string counties = "";
            int nSetNo;
            if (Int32.TryParse(setNo, out nSetNo))
            {
                var context = new Models.PowEntities2();
                var setcounties = (from c in context.vCountySets where c.Set == setNo select c.CountyName).ToList();
                counties = string.Join(";", setcounties);
            }

            return counties;
        }




        public List<CContact> getContacts(string year, string activityid, string type)
        {
            var context = new Models.PowEntities2();

            int nActivityid = Convert.ToInt32(activityid);

            int nYear;
            if (int.TryParse(year, out nYear))
            {
                var q = from c in context.Contacts
                    where c.IsUsed == "Yes" && c.Year == year && c.ContactType.ToLower() == type && c.ActivityID == nActivityid
                    select new CContact
                    {
                        ows_ID = c.ID,
                        //ows_Title = c.Title,
                        //ows_Title = (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault(),
                        ows_Title = (c.ContactType == "Activity") ? (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault() : c.Title,
                        ows_StartDate = c.StartDate,
                        ows_EndDate = c.EndDate,
                        ows_ActivityID = c.ActivityID,
                        ows_Attendees = c.Attendees,
                        ows_ContactType = c.ContactType,
                        ows_Program = (c.Program == null) ? "" : c.Program,
                        ows_Year = c.Year,
                        ows_Description = c.Description,
                        ows_CreatorID = c.CreatorID,
                        //ows_Creator = c.Creator,
                        ows_Creator = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                        ows_IsUsed = c.IsUsed,
                        ows_Evaluation = c.Evaluation,
                        ows_ExternalFactor = c.ExternalFactor,
                        ows_Outcomes = c.Outcomes,                 
                        ows_County = c.County,
                        ows_IsPlan = c.IsPlan,
                        ows_raian = c.raian,
                        ows_rapi = c.rapi,
                        ows_rblack = c.rblack,
                        ows_rfmale = c.rfmale,
                        ows_rhisp = c.rhisp,
                        ows_rmale = c.rmale,
                        //ows_rnftf = c.rnftf,
                        ows_rnftf = nYear >= 2017 ? c.rnftf : "",
                        ows_rother = c.rother,
                        ows_rwhite = c.rwhite,
                        ows_ryouth = c.ryouth,
                        ows_uadult = c.uadult,
                        ows_uaian = c.uaian,
                        ows_uapi = c.uapi,
                        ows_ublack = c.ublack,
                        ows_ufmale = c.ufmale,
                        ows_uhisp = c.uhisp,
                        ows_umale = c.umale,
                        //ows_unftf = c.unftf,
                        ows_unftf = "",
                        ows_uother = c.uother,
                        ows_uwhite = c.uwhite,
                        ows_uyouth = c.uyouth,                        
                        ows_radult = c.radult,
                        ows_rMore = c.rMore,
                        ows_uMore = c.uMore,
                        ows_Created = c.Created,
                        ows_Modified = c.Modified,
                        ows_MultiState = nYear >= 2017 ? c.rnftf : "",

                        /* 12/6/2018 */
                        ows_mraian   = c.mraian ,  
                        ows_mrapi    = c.mrapi  , 
                        ows_mrblack  = c.mrblack,  
                        ows_mrfmale  = c.mrfmale,  
                        ows_mrhisp   = c.mrhisp , 
                        ows_mrmale   = c.mrmale , 
                        ows_mrother  = c.mrother,  
                        ows_mrwhite  = c.mrwhite,  
                        ows_mryouth  = c.mryouth,  
                        ows_muadult  = c.muadult,  
                        ows_muaian   = c.muaian , 
                        ows_muapi    = c.muapi  , 
                        ows_mublack  = c.mublack,  
                        ows_mufmale  = c.mufmale,  
                        ows_muhisp   = c.muhisp , 
                        ows_mumale   = c.mumale , 
                        ows_muother  = c.muother,  
                        ows_muwhite  = c.muwhite,  
                        ows_muyouth  = c.muyouth,  
                        ows_mradult  = c.mradult,  
                        ows_mrMore   = c.mrMore , 
                        ows_muMore   = c.muMore,
                        ows_IsMultiState = c.IsMultistate,

                        /* 1/7/2020 */
                        ows_unonhisp = c.uNonHispanic,
                        ows_rnonhisp = c.rNonHispanic,
                        ows_munonhisp = c.muNonHispanic,
                        ows_mrnonhisp = c.mrNonHispanic,

                        /* 8/24/2020 */
                        ows_unknown = c.unknown,

                        /* 12/3/2020 */
                        ows_munknown = c.munknown,

                        /* 12/6/2021 */
                        ows_unknownGender = c.unknownGender,
                        ows_unknownAge = c.unknownAge,
                        ows_unknownRace = c.unknownRace,
                        ows_unknownEth = c.unknownEth,
                        ows_munknownGender = c.munknownGender,
                        ows_munknownAge = c.munknownAge,
                        ows_munknownRace = c.munknownRace,
                        ows_munknownEth = c.munknownEth
                    };

                return q.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<CContact> getContacts(string year, string activityid, string type, string userid)
        {            
            var context = new Models.PowEntities2();

            int nActivityid = Convert.ToInt32(activityid);
            userid = userid.ToLower();

            int nYear;
            if (int.TryParse(year, out nYear))
            {

            var q = from c in context.Contacts
                    where c.IsUsed == "Yes" && c.Year == year && c.ContactType.ToLower() == type && c.ActivityID == nActivityid && c.CreatorID.ToLower().Contains(userid)
                    select new CContact
                    {
                        ows_ID = c.ID,
                        //ows_Title = c.Title,
                        //ows_Title = (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault(),
                        ows_Title = (c.ContactType == "Activity" ) ? (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault() : c.Title,
                        ows_StartDate = c.StartDate,
                        ows_EndDate = c.EndDate,
                        ows_ActivityID = c.ActivityID,
                        ows_Attendees = c.Attendees,
                        ows_ContactType = c.ContactType,
                        ows_Program = c.Program,
                        ows_Year = c.Year,
                        ows_Description = c.Description,
                        ows_CreatorID = c.CreatorID,
                        ows_Creator = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                        ows_IsUsed = c.IsUsed,
                        ows_Evaluation = c.Evaluation,
                        ows_ExternalFactor = c.ExternalFactor,
                        ows_Outcomes = c.Outcomes,                    
                        ows_County = c.County,
                        ows_IsPlan = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                        ows_raian = c.raian,
                        ows_rapi = c.rapi,
                        ows_rblack = c.rblack,
                        ows_rfmale = c.rfmale,
                        ows_rhisp = c.rhisp,
                        ows_rmale = c.rmale,
                        //ows_rnftf = c.rnftf,
                        ows_rnftf = nYear >= 2017 ? c.rnftf : "",
                        ows_rother = c.rother,
                        ows_rwhite = c.rwhite,
                        ows_ryouth = c.ryouth,
                        ows_uadult = c.uadult,
                        ows_uaian = c.uaian,
                        ows_uapi = c.uapi,
                        ows_ublack = c.ublack,
                        ows_ufmale = c.ufmale,
                        ows_uhisp = c.uhisp,
                        ows_umale = c.umale,
                        //ows_unftf = c.unftf,
                        ows_unftf = "",
                        ows_uother = c.uother,
                        ows_uwhite = c.uwhite,
                        ows_uyouth = c.uyouth,
                        ows_radult = c.radult,
                        ows_rMore = c.rMore,
                        ows_uMore = c.uMore,
                        ows_Created = c.Created,
                        ows_Modified = c.Modified,
                        ows_MultiState = nYear >= 2017 ? c.rnftf : "",

                        /* 12/6/2018 */
                        ows_mraian = c.mraian,
                        ows_mrapi = c.mrapi,
                        ows_mrblack = c.mrblack,
                        ows_mrfmale = c.mrfmale,
                        ows_mrhisp = c.mrhisp,
                        ows_mrmale = c.mrmale,
                        ows_mrother = c.mrother,
                        ows_mrwhite = c.mrwhite,
                        ows_mryouth = c.mryouth,
                        ows_muadult = c.muadult,
                        ows_muaian = c.muaian,
                        ows_muapi = c.muapi,
                        ows_mublack = c.mublack,
                        ows_mufmale = c.mufmale,
                        ows_muhisp = c.muhisp,
                        ows_mumale = c.mumale,
                        ows_muother = c.muother,
                        ows_muwhite = c.muwhite,
                        ows_muyouth = c.muyouth,
                        ows_mradult = c.mradult,
                        ows_mrMore = c.mrMore,
                        ows_muMore = c.muMore,
                        ows_IsMultiState = c.IsMultistate,

                        /* 1/7/2020 */
                        ows_unonhisp = c.uNonHispanic,
                        ows_rnonhisp = c.rNonHispanic,
                        ows_munonhisp = c.muNonHispanic,
                        ows_mrnonhisp = c.mrNonHispanic,

                        /* 8/24/2020 */
                        ows_unknown = c.unknown,

                        /* 12/3/2020 */
                        ows_munknown = c.munknown,

                        /* 12/6/2021 */
                        ows_unknownGender = c.unknownGender,
                        ows_unknownAge = c.unknownAge,
                        ows_unknownRace = c.unknownRace,
                        ows_unknownEth = c.unknownEth,
                        ows_munknownGender = c.munknownGender,
                        ows_munknownAge = c.munknownAge,
                        ows_munknownRace = c.munknownRace,
                        ows_munknownEth = c.munknownEth

                    };

                return q.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<CContact> getContacts(string year, string activityid, string type, string userid, string format, string format1)
        {
           
            var context = new Models.PowEntities2();

            int nActivityid = Convert.ToInt32(activityid);
            userid = userid.ToLower();

            int nYear;
            if (int.TryParse(year, out nYear))
            {

                var q = from c in context.Contacts
                        where c.IsUsed == "Yes" && c.Year == year && c.ContactType.ToLower() == type && c.CreatorID.ToLower().Contains(userid)
                        select new CContact
                        {
                            ows_ID = c.ID,
                            //ows_Title = c.Title,
                            //ows_Title = (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault(),
                            ows_Title = (c.ContactType == "Activity") ? (from a in context.Activities where a.ID == c.ActivityID select a.Title).FirstOrDefault() : c.Title,
                            ows_StartDate = c.StartDate,
                            ows_EndDate = c.EndDate,
                            ows_ActivityID = c.ActivityID,
                            ows_Attendees = c.Attendees,
                            ows_ContactType = c.ContactType,
                            ows_Program = c.Program,
                            ows_Year = c.Year,
                            ows_Description = c.Description,
                            ows_CreatorID = c.CreatorID,
                            ows_Creator = (from e in context.PowUsers where e.Name.ToLower().Contains(c.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                            ows_IsUsed = c.IsUsed,
                            ows_Evaluation = c.Evaluation,
                            ows_ExternalFactor = c.ExternalFactor,
                            ows_Outcomes = c.Outcomes,
                            ows_County = c.County,
                            ows_IsPlan = c.IsPlan,
                            ows_raian = c.raian,
                            ows_rapi = c.rapi,
                            ows_rblack = c.rblack,
                            ows_rfmale = c.rfmale,
                            ows_rhisp = c.rhisp,
                            ows_rmale = c.rmale,
                            //ows_rnftf = c.rnftf,
                            ows_rnftf = "",
                            ows_rother = c.rother,
                            ows_rwhite = c.rwhite,
                            ows_ryouth = c.ryouth,
                            ows_uadult = c.uadult,
                            ows_uaian = c.uaian,
                            ows_uapi = c.uapi,
                            ows_ublack = c.ublack,
                            ows_ufmale = c.ufmale,
                            ows_uhisp = c.uhisp,
                            ows_umale = c.umale,
                            //ows_unftf = c.unftf,
                            ows_unftf = "",
                            ows_uother = c.uother,
                            ows_uwhite = c.uwhite,
                            ows_uyouth = c.uyouth,
                            ows_radult = c.radult,
                            ows_rMore = c.rMore,
                            ows_uMore = c.uMore,
                            ows_Created = c.Created,
                            ows_Modified = c.Modified,
                            ows_MultiState = nYear >= 2017 ? c.rnftf : "",

                            /* 12/6/2018 */
                            ows_mraian = c.mraian,
                            ows_mrapi = c.mrapi,
                            ows_mrblack = c.mrblack,
                            ows_mrfmale = c.mrfmale,
                            ows_mrhisp = c.mrhisp,
                            ows_mrmale = c.mrmale,
                            ows_mrother = c.mrother,
                            ows_mrwhite = c.mrwhite,
                            ows_mryouth = c.mryouth,
                            ows_muadult = c.muadult,
                            ows_muaian = c.muaian,
                            ows_muapi = c.muapi,
                            ows_mublack = c.mublack,
                            ows_mufmale = c.mufmale,
                            ows_muhisp = c.muhisp,
                            ows_mumale = c.mumale,
                            ows_muother = c.muother,
                            ows_muwhite = c.muwhite,
                            ows_muyouth = c.muyouth,
                            ows_mradult = c.mradult,
                            ows_mrMore = c.mrMore,
                            ows_muMore = c.muMore,
                            ows_IsMultiState = c.IsMultistate,

                            /* 1/7/2020 */
                            ows_unonhisp = c.uNonHispanic,
                            ows_rnonhisp = c.rNonHispanic,
                            ows_munonhisp = c.muNonHispanic,
                            ows_mrnonhisp = c.mrNonHispanic,

                            /* 8/24/2020 */
                            ows_unknown = c.unknown,

                            /* 12/3/2020 */
                            ows_munknown = c.munknown,

                            /* 12/6/2021 */
                            ows_unknownGender = c.unknownGender,
                            ows_unknownAge = c.unknownAge,
                            ows_unknownRace = c.unknownRace,
                            ows_unknownEth = c.unknownEth,
                            ows_munknownGender = c.munknownGender,
                            ows_munknownAge = c.munknownAge,
                            ows_munknownRace = c.munknownRace,
                            ows_munknownEth = c.munknownEth
                        };

                return q.ToList();
            }
            else
            {
                return null;
            }
        }


        public Contact getContactSummary(string county, string year)
        {
            var context = new Models.PowEntities2();

            var p = context.GetContactSummarybyCounty(county, year).FirstOrDefault();

            var c = new Contact();
            c.activities = p.activities;
            c.demo_instate = p.attendees;
            c.raian = p.raian;
            c.rapi = p.rapi;
            c.rblack = p.rblack;
            c.rfmale = p.rfmale;
            c.rhisp = p.rhisp;
            c.rmale = p.rmale;
            c.rother = p.rother;
            c.rwhite = p.rwhite;
            c.ryouth = p.ryouth;
            c.uadult = p.uadult;
            c.uaian = p.uaian;
            c.uapi = p.uapi;
            c.ublack = p.ublack;
            c.ufmale = p.ufmale;
            c.uhisp = p.uhisp;
            c.umale = p.umale;
            c.uother = p.uother;
            c.uwhite = p.uwhite;
            c.uyouth = p.uyouth;
            c.radult = p.radult;
            c.rMore = p.rMore;
            c.uMore = p.uMore;
            c.demo_outofstate = p.multistate;
            c.nondemo_instate = p.unknown;
            c.nondemo_outofstate = p.munknown;

            return c;
        }



    }
}