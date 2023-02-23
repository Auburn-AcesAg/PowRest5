using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CivilRight
    {  
        public string County { get; set; }
        public List<OtherAdvisor> OtherAdvisors { get; set; }
    }

    public class OtherAdvisor
    {
        public string otherAdvisoryGroup { get; set; }
        public string otherWhite { get; set; }
        public string otherBlack { get; set; }
        public string otherAsianPacific { get; set; }
        public string otherIndian { get; set; }
        public string otherOther { get; set; }
        public string otherNotDetermined { get; set; }
        public string otherHispanic { get; set; }
        public string otherFemales { get; set; }
        public string otherMales { get; set; }
        public string otherMeetings { get; set; }
        public string otherAttendance { get; set; }
        public Nullable<System.DateTime> otherBylaws { get; set; }
        public string otherCouncil { get; set; }
    }

    public class Audit
    {
        public string County { get; set; }
        public string Efforts { get; set; }
        public string Success { get; set; }
        public string REA { get; set; }
    }
    public class DeskAudit
    {
        public string County { get; set; }
        public string field365 { get; set; }
        public string field366 { get; set; }
        public string field367 { get; set; }
        public string field368 { get; set; }
        public string field369 { get; set; }
        public string field370 { get; set; }
        public string field371 { get; set; }
        public string field372 { get; set; }
        public string field373 { get; set; }
        public string field374 { get; set; }
        public string field375 { get; set; }
        public string field496 { get; set; }
        public string field497 { get; set; }
        public string field498 { get; set; }
    }



    public class AdvisorRepository
    {
        private Models.PowSumEntities e = new Models.PowSumEntities();

        public List<CivilRight> getOtherAdvisors(string county)
        {
            var tcivilrights = (from a in e.tblCivilRights where a.County == county select a ).ToList();

            List<CivilRight> civilRights = new List<CivilRight>();
            foreach(var tc in tcivilrights)
            {
                CivilRight c = new CivilRight();
                c.County = tc.County;

                c.OtherAdvisors = new List<OtherAdvisor>();
                var tadvisers = (from b in e.tblOtherAdvisers where b.PID == tc.ID select b).ToList();
                foreach ( var ta in tadvisers)
                {
                    OtherAdvisor o       = new OtherAdvisor();
                    o.otherAdvisoryGroup = ta.otherAdvisoryGroup ;
                    o.otherWhite         = ta.otherWhite         ;
                    o.otherBlack         = ta.otherBlack         ;
                    o.otherAsianPacific  = ta.otherAsianPacific  ;
                    o.otherIndian        = ta.otherIndian        ;
                    o.otherOther         = ta.otherOther         ;
                    o.otherNotDetermined = ta.otherNotDetermined ;
                    o.otherHispanic      = ta.otherHispanic      ;
                    o.otherFemales       = ta.otherFemales       ;
                    o.otherMales         = ta.otherMales         ;
                    o.otherMeetings      = ta.otherMeetings      ;
                    o.otherAttendance    = ta.otherAttendance    ;
                    o.otherBylaws        = ta.otherBylaws;
                    o.otherCouncil       = ta.otherCouncil;
                    c.OtherAdvisors.Add(o);
                }

                civilRights.Add(c);
            }



            return civilRights;
        }


        public List<Audit> GetAudits(string county, string year)
        {
            return (from c in e.tblDeskAudits 
                    where c.IsUsed == "Y" && c.County == county && c.IsSubmitted == true && c.Year == year
                    select new Audit
                    {
                        County = c.County,
                        Efforts = c.Efforts,
                        Success = c.Success,
                        REA = c.REA
                    }).ToList();
        }

        public List<DeskAudit> GetDeskAudits(string county, string isSubmitted = "none")
        {

            if (isSubmitted == "none")
            {
                return (from c in e.tblDeskAuditsNEWs
                        where c.IsUsed == true && c.County == county
                        select new DeskAudit
                        {
                            County = c.County,
                            field365 = c.field365,
                            field366 = c.field366,
                            field367 = c.field367,
                            field368 = c.field368,
                            field369 = c.field369,
                            field370 = c.field370,
                            field371 = c.field371,
                            field372 = c.field372,
                            field373 = c.field373,
                            field374 = c.field374,
                            field375 = c.field375,
                            field496 = c.field496,
                            field497 = c.field497,
                            field498 = c.field498
                        }).ToList();
            }
            else
            {
                bool bSubmitted = isSubmitted == "true" ? true : false;

                return (from c in e.tblDeskAuditsNEWs
                        where c.IsUsed == true && c.County == county && c.IsSubmitted == bSubmitted
                        select new DeskAudit
                        {
                            County = c.County,
                            field365 = c.field365,
                            field366 = c.field366,
                            field367 = c.field367,
                            field368 = c.field368,
                            field369 = c.field369,
                            field370 = c.field370,
                            field371 = c.field371,
                            field372 = c.field372,
                            field373 = c.field373,
                            field374 = c.field374,
                            field375 = c.field375,
                            field496 = c.field496,
                            field497 = c.field497,
                            field498 = c.field498
                        }).ToList();
            }

        }
    }

    
}