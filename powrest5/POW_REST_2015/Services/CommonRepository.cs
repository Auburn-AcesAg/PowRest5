using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POW_REST_2015.Models;


using System.Data.Entity;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;


namespace POW_REST_2015.Services
{
    public class CMonth
    {
        public int ID { get; set; }
        public string Title { get; set; }        
    }

    public class CommonRepository
    {
        private static Models.PowEntities2 context = new Models.PowEntities2();

        public List<CTeam> getTeams(string type, string year)
        {
            //var context = new Models.PowEntities2();
            year = (Convert.ToInt32(year) > 2017) ? year : "2017";

            if (type.ToLower().Equals("plan") || type.ToLower().Equals("team"))
            {
                return (from a in context.Teams
                        where a.IsUsed == "Y" && a.Type.Contains("P") && a.Year == year
                        orderby a.Order
                        select new CTeam
                            {
                                ows_UID = a.UID,
                                ows_Title = a.Title
                            }).ToList();
            }
            else if (type.ToLower().Equals("unplan") || type.ToLower().Equals("individual"))
            {
                return (from a in context.Teams
                        where a.IsUsed == "Y" && a.Type.Contains("U") && a.Year == year
                        orderby a.Order
                        select new CTeam
                        {
                            ows_UID = a.UID,
                            ows_Title = a.Title
                        }).ToList();
            }
            else if (type.ToLower().Equals("all"))
            {
               List<CTeam> teams = (from a in context.Teams
                                    where a.IsUsed == "Y" && a.Type.Contains("U") && a.Year == year
                             orderby a.Order
                             select new CTeam
                             {
                                 ows_UID = a.UID,
                                 ows_Title = a.Title
                             }).ToList();
               teams.Insert(0, new CTeam { ows_Title = "All Teams", ows_UID = "" });
               return teams;
            }

            return null;
        }

        public string getYearFromTeam(string team)
        {
            return (from c in context.Teams where c.IsUsed == "Y" && (c.UID == team || c.Title.ToLower() == team.ToLower()) select c.Year).FirstOrDefault();
        }
        
        public List<CTeam> getTeamsForAdditionalTeam(string type, string LeadTeam, string year)
        {
            //var context = new Models.PowEntities2();

            //LeadTeam = (LeadTeam.Length == 2) ? LeadTeam : (from t in context.Teams where t.Title.Contains(LeadTeam) select t.UID).FirstOrDefault();

            year = (Convert.ToInt32(year) > 2017) ? year : "2017";

            //year = getYearFromTeam(LeadTeam);

            if(type.ToLower().Equals("plan"))
            {
                return (from a in context.Teams
                        where a.IsUsed == "Y" && a.Type.Contains("P") && a.Title.ToLower() != LeadTeam.ToLower() && a.Year == year
                        orderby a.Order
                        select new CTeam
                            {
                                ows_UID = a.UID,
                                ows_Title = a.Title
                            }).ToList();
            }


            return null;
        }

        public List<CProgram> getPrograms(string type, string year)
        {
            //var context = new Models.PowEntities2();

            year = (Convert.ToInt32(year) > 2017) ? year : "2017";

            if (type.ToLower().Equals("plan") || type.ToLower().Equals("team"))
            {
                return (from a in context.Programs
                        where a.IsUsed == "Y" && a.Type.Contains("P") && a.Year.Contains(year)
                        orderby a.Order
                        select new CProgram
                        {
                            ows_UID = a.UID,
                            ows_Title = a.Title
                        }).ToList();
            }
            else if (type.ToLower().Equals("unplan") || type.ToLower().Equals("individual"))
            {
                return (from a in context.Programs
                        where a.IsUsed == "Y" && a.Type.Contains("U") && a.Year.Contains(year)
                        orderby a.Order
                        select new CProgram
                        {
                            ows_UID = a.UID,
                            ows_Title = a.Title
                        }).ToList();

            }
            else if (type.ToLower().Equals("all"))
            {
                List<CProgram> programs = (from a in context.Programs
                                           where a.IsUsed == "Y" && a.Type.Contains("U") && a.Year.Contains(year)
                                     orderby a.Order
                                     select new CProgram
                                     {
                                         ows_UID = a.UID,
                                         ows_Title = a.Title
                                     }).ToList();
                programs.Insert(0, new CProgram { ows_Title = "All Programs", ows_UID = "" });
                return programs;
            }

            return null;
        }

        public List<CCounty> getCounty()
        {
            //var context = new Models.PowEntities2();

            var counties = (from c in context.counties
                        select new CCounty
                        {
                            ows_ID = c.UID,
                            ows_County = c.County1
                        }).ToList();


            var CountySets = context.Database.SqlQuery<getCountySets_Result>("exec getCountySets").AsQueryable();
            int idx = 0;
            foreach (var set in CountySets)
            {
                counties.Insert(idx++, new CCounty { ows_ID = Convert.ToInt32(set.ID), ows_County = set.Set });
            }

            return counties;
        }


       // public List<CCounty2> getCounty(string type, string year = "2021")
        public List<CCounty2> getCounty(string type, string year = "2022") // *slm changed year from 2021 to 2022
        {
            //var context = new Models.PowEntities2();

            List<CCounty2> counties = (from c in context.counties
                    select new CCounty2
                    {
                        ID = c.UID,
                        Name = c.County1,
                        Name2 = c.County1,
                        Value = c.County1
                    }).ToList();

            if (type.ToLower().Trim().Equals("regular"))
            {
                return counties;
            }
            else if (type.ToLower().Trim().Equals("all"))
            {
                counties.RemoveAt(0); // remove Statewide
                counties.Insert(0, new CCounty2 { ID = -1, Name = "All Counties", Name2 = "<Select County>", Value = "" });
                counties.Insert(1, new CCounty2 { ID = 0, Name = "Online",
                    Name2 = "Online", Value = "Online"
                });
                counties.Add(new CCounty2 { ID = 69, Name = "Out-of-State", Name2 = "Out-of-State", Value = "Out-of-State" });

                return counties;
            } 
            else if (type.ToLower().Trim().Equals("all2"))
            {
                counties.RemoveAt(0); // remove Statewide
                counties.Insert(0, new CCounty2 { ID = 0, Name = "Online", 
                    Name2 = "Online", Value = "Online"
                });
                counties.Add(new CCounty2 { ID = 1, Name = "Statewide", Name2 = "Statewide", Value = "Statewide" });
                counties.Add(new CCounty2 { ID = 69, Name = "Out-of-State", Name2 = "Out-of-State", Value = "Out-of-State" });
                
                return counties;
            }
            else if (type.ToLower().Trim().Equals("event"))
            {
                counties.RemoveAt(0); // remove Statewide
                counties.Insert(0, new CCounty2 { ID = 0, Name = "Online", 
                            Name2 = "Online", Value = "Online"
                });                
                counties.Add(new CCounty2 { ID = 69, Name = "Out-of-State", Name2 = "Out-of-State", Value = "Out-of-State" });

                return counties;
            }
            else if (type.ToLower().Trim().Equals("announcement"))
            {
                counties.RemoveAt(0); // remove Statewide                
                counties.Add(new CCounty2 { ID = 1, Name = "Statewide", Name2 = "Statewide", Value = "Statewide" });

                var CountySets = context.Database.SqlQuery<getCountySets_Result>("exec getCountySets @year", new SqlParameter("@year", year)).AsQueryable();
                int idx = 0;
                foreach (var set in CountySets)
                {
                    counties.Insert(idx++, new CCounty2 { ID = Convert.ToInt32(set.ID), Name = set.Set, Name2 = set.Set, Value = set.Set });

                }

                return counties;
            }
            else if (type.ToLower().Trim().Equals("contact"))
            {
                counties.RemoveAt(0); // remove Statewide                
                counties.Add(new CCounty2 { ID = 1, Name = "Statewide", Name2 = "Statewide", Value = "Statewide" });
                //counties.Add(new CCounty2 { ID = 69, Name = "Out-of-State", Name2 = "Out-of-State", Value = "Out-of-State" });

                var CountySets = context.Database.SqlQuery<getCountySets_Result>("exec getCountySets @year", new SqlParameter("@year", year)).AsQueryable();
                int idx = 0;
                foreach (var set in CountySets)
                {
                    counties.Insert(idx++, new CCounty2 { ID = Convert.ToInt32(set.ID), Name = set.Set, Name2 = set.Set, Value = set.Set });

                }

                return counties;
            }

            else
            {
                return counties;
            }
        }

        
        public List<CCreator> getCreators(string year, string type, string orderby)
        {
            List<CCreator> creators = null;
            if (year.Equals("2014"))
            {
                /*
                var context2014 = new Models.PowEntities3();

                if (type.ToLower().Trim() == "activity")
                {
                    var q = (from a in context2014.Activities where a.IsUsed == "Yes" && a.ProjectID != null && a.ProjectID != "" && a.CreatorID != null && a.CreatorID != "" select a).GroupBy(a => a.CreatorID, a => a.Creator);

                    creators = (from b in q
                                select new CCreator
                                {
                                    CreatorID = b.Key,
                                    Creator = b.FirstOrDefault(),
                                    CreatorName = "",
                                    CreatorAccount = (from c in context2014.PowUsers where c.Email.Contains(b.Key) select c.Name).FirstOrDefault()
                                }).ToList();
                }
                */
                return null;
            }
           // if (year.Equals("2015"))
            else
            {
                //var context = new Models.PowEntities2();

                if (type.ToLower().Trim() == "project")
                {
                    
                    var q = (from a in context.Projects where a.IsUsed.StartsWith("y") && year == a.Year select a).GroupBy(a => a.CreatorID, a => a.Creator);

                    creators = (from b in q
                                select new CCreator
                                    {
                                        CreatorID = b.Key,
                                        Creator = b.FirstOrDefault(),
                                        CreatorName = "",
                                        CreatorAccount = (from c in context.PowUsers where c.Name.Contains(b.Key) select c.Name).FirstOrDefault()
                                    }).ToList();
                }
                else if (type.ToLower().Trim() == "all")
                {
                    creators = (from a in context.PowUsers
                                where a.Email != ""
                                select new CCreator
                                {
                                    CreatorID = a.Name.Replace("i:0#.w|auburn\\", ""), 
                                    Creator = a.ID + ";#" + a.Title,
                                    CreatorName = a.Title,
                                    CreatorAccount = a.Name
                                }).ToList();
                }
                else if (type.ToLower().Trim() == "all2")
                {
                    creators = (from a in context.PowUsers
                                where a.Email != ""
                                select new CCreator
                                {
                                    CreatorID = a.Name.Replace("i:0#.w|auburn\\", ""), 
                                    Creator = a.ID + ";#" + a.Title,
                                    CreatorName = a.Title,
                                    CreatorAccount = a.Name
                                }).ToList();

                    creators.Insert(0, new CCreator { CreatorID = "Creators", CreatorName = "**All" });
                }

            }           

            if (creators != null)
            {
                if (orderby.ToLower().Trim() == "creator") return creators.OrderBy(a => a.Creator).ToList();
                else if (orderby.ToLower().Trim() == "creatorid") return creators.OrderBy(a => a.CreatorID).ToList();
                else if (orderby.ToLower().Trim() == "creatorname") return creators.OrderBy(a => a.CreatorName).ToList();
                else
                    return null;
            }
            else
                return null;
        }

        public CCreator getCreator(string userid)
        {
            //var context = new Models.PowEntities2();

            CCreator c = (from a in context.PowUsers
                    where a.Email != "" && a.Name.Contains(userid)
                    select new CCreator
                    {
                        //CreatorID = a.Email,
                        CreatorID = a.Name.Replace("i:0#.w|auburn\\",""), 
                        Creator = a.ID + ";#" + a.Title,
                        CreatorName = a.Title,
                        CreatorAccount = a.Name
                    }).FirstOrDefault();


            if (c == null)
            {
                c = (from a in context.StaffDirectories
                     where a.UserID.Contains(userid)
                     select new CCreator
                     {
                         CreatorID = a.UserID,
                         Creator = "00;#" + a.FirstName + " " + a.LastName,
                         CreatorName = a.FirstName + " " + a.LastName,
                         CreatorAccount = "i:0#.w|auburn\\" + a.UserID
                     }).FirstOrDefault();
            }

            return c;
        }

        public List<CLeadPerson> getLeadPersons(string year)
        {
            return (from a in context.LeadPersons where a.Year == year
                    select new CLeadPerson
                    {
                        Id = a.Id,
                        Teamcode = a.Teamcode,
                        Username = a.Username,
                        Responsibility = a.Responsibility,
                        JobTitle = a.JobTitle,
                        Year = a.Year,
                        LastName = a.LastName,
                        FirstName = a.FirstName,
                        Timestamp = a.Timestamp
                    }).ToList();
        }

        public List<CMonth> getMonths()
        {
            List<CMonth> months = new List<CMonth>();

            months.Add(new CMonth() { ID = 1,  Title = "January" });
            months.Add(new CMonth() { ID = 2, Title = "February" });
            months.Add(new CMonth() { ID = 3, Title = "March" }); 
            months.Add(new CMonth() { ID = 4, Title = "April" }) ;
            months.Add(new CMonth() { ID = 5, Title = "May" }) ;
            months.Add(new CMonth() { ID = 6, Title = "June" });
            months.Add(new CMonth() { ID = 7, Title = "July" });
            months.Add(new CMonth() { ID = 8, Title = "August" });
            months.Add(new CMonth() { ID = 9, Title = "September" });
            months.Add(new CMonth() { ID = 10, Title = "October" });
            months.Add(new CMonth() { ID = 11, Title = "November" });
            months.Add(new CMonth() { ID = 12, Title = "December" });

            return months;
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
                else if(s.EndsWith(" SET"))
                {
                    temp = ConvertSetToCounty(s.Replace(" SET", ""));
                }

                counties = counties + temp + ";";
            }

            return string.Join(";", counties.Split(';').Distinct().ToList());
        }


        public string ConvertSetToCounty(string setNo)
        {
            string counties = "";
            //int nSetNo;
            //if (Int32.TryParse(setNo, out nSetNo))
            //{
                var context = new Models.PowEntities2();
                var setcounties = (from c in context.vCountySets where c.Set == setNo || c.SetName == setNo select c.CountyName).ToList();
                counties = string.Join(";", setcounties);
            //}

            return counties;
        }

    }
}