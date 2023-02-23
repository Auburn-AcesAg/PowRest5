using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POW_REST_2015.Models;
using POW_REST_2015.Models2;

namespace POW_REST_2015.Services
{
    public class WorkSheet
    {
        public int ID { get; set; }
        public string Team { get; set; }
        public string UserName { get; set; }
        public List<Section> SectionList { get; set; }
    }

    public class Section
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Audience { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string LeadPerson { get; set; }
        public string Instructors { get; set; }
        public string ActualDate { get; set; }
        public string ActualLocation { get; set; }
        public string Host { get; set; }
        public Boolean bCheck { get; set; }
    }

    public class SummaryRepository
    {   
        private PowSumEntities e = new PowSumEntities();
        private PowEntities2 pow = new PowEntities2();

        public enum FormType { State = 1, REA, CEC };

        public SummaryRepository()
        {

        }

        public tblSummary GetPowSummary(int id, FormType type)
        {
            {
                var t = (from c in e.tblSummaries where c.SPID == id && c.TypeID == (int)type && c.IsUsed == "Y" select c).FirstOrDefault();

                if (t != null)
                {
                    t.tblSections = null;
                    t.tblSections = (from c in e.tblSections where c.SummaryID == t.ID && c.IsUsed == "Y" select c).OrderBy(c => c.Type).ToList();

                    foreach (var s in t.tblSections)
                    {
                        s.tblRows = null;
                        s.tblRows = (from c in e.tblRows where c.SectionID == s.ID && c.IsUsed == "Y" select c).ToList();
                    }
                }
                return t;
            }
        }

        public List<tblRow> GetTblRows(int sectionid)
        {
            {
                var rows = (from c in e.tblRows where c.SectionID == sectionid && c.IsUsed == "Y" select c).ToList();
                return rows;
            }
        }

        public int AddPowSummary(tblSummary t)
        {
            using (PowSumEntities e = new PowSumEntities())
            {
                e.tblSummaries.Add(t);
                e.SaveChanges();
                return t.ID;
            }
        }

        public int UpdatePowSummary(tblSummary t, FormType type)
        {
            using (PowSumEntities e = new PowSumEntities())
            {
                var s = (from c in e.tblSummaries where c.SPID == t.SPID && c.TypeID == (int)type select c).FirstOrDefault();
                var k = e.Entry(s);
                k.CurrentValues.SetValues(t);
                k.State = System.Data.Entity.EntityState.Modified;
                e.SaveChanges();

                var s1 = (from c in e.tblSections where c.SummaryID == t.ID select c).ToList();
                s1.ForEach(c => c.IsUsed = "N");
                e.SaveChanges();

                foreach (var i in t.tblSections)
                {
                    if (i.ID != 0)
                    {
                        var a = (from c in e.tblSections where c.ID == i.ID select c).FirstOrDefault();
                        if (a != null)
                        {
                            var b = e.Entry(a);
                            b.CurrentValues.SetValues(i);
                            b.State = System.Data.Entity.EntityState.Modified;
                            e.SaveChanges();

                            var s2 = (from c in e.tblRows where c.SectionID == a.ID select c).ToList();
                            s2.ForEach(c => c.IsUsed = "N");
                            e.SaveChanges();

                            foreach (var j in i.tblRows)
                            {
                                if (j.ID != 0)
                                {
                                    var f = (from c in e.tblRows where c.ID == j.ID select c).FirstOrDefault();
                                    if (f != null)
                                    {
                                        var g = e.Entry(f);
                                        g.CurrentValues.SetValues(j);
                                        g.State = System.Data.Entity.EntityState.Modified;
                                        e.SaveChanges();
                                    }
                                }
                                else
                                {
                                    tblRow row1 = new tblRow();

                                    row1.SectionID = i.ID;
                                    row1.ActualDate = j.ActualDate;
                                    row1.ActualLoc = j.ActualLoc;
                                    row1.County = j.County;
                                    row1.IsUsed = "Y";
                                    row1.Timestamp = DateTime.Now;

                                    e.tblRows.Add(row1);
                                    e.SaveChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        tblSection a = new tblSection();

                        a.SummaryID = i.SummaryID;
                        a.Type = i.Type;
                        a.Timestamp = DateTime.Now;
                        a.IsUsed = "Y";
                        a.Title = i.Title;
                        a.Description = i.Description;
                        a.Audience = i.Audience;
                        a.LeadPerson = i.LeadPerson;
                        a.Instructors = i.Instructors;
                        a.ProposedDate = i.ProposedDate;
                        a.ProposedLoc = i.ProposedLoc;

                        e.tblSections.Add(a);
                        e.SaveChanges();
                    }
                }
                e.SaveChanges();

                return t.ID;
            }
        }


        public List<Section> GetTblSummaryList(string team, string level, string year)
        {
            string type = "";
            if (level.ToLower() == "state") type = "A";
            else if (level.ToLower() == "multicounty") type = "B";
            else type = "C";


            team = (from c in pow.Teams where c.Year == year && c.IsUsed == "Y" && c.UID == team select c.Title).FirstOrDefault();

            var summaries = (from c in e.tblSummaries where c.Team == team && c.IsUsed == "Y" && c.IsFinalized == "true" && c.Year == year && c.TypeID == 1 select c).ToList();

            List<Section> sections = new List<Section>();
            foreach (var s in summaries)
            {
                var slist = (from c in e.tblSections
                             where c.SummaryID == s.ID && c.IsUsed == "Y" && c.Type == type
                             select new Section
                             {
                                 Title = c.Title,
                                 Description = c.Description,
                                 Audience = c.Audience,
                                 Date = c.ProposedDate,
                                 Location = c.ProposedLoc,
                                 bCheck = false,
                                 ActualDate = "",
                                 ActualLocation = "",
                                 Host = "",
                                 Instructors = "",
                                 LeadPerson = ""                                      
                             }).ToList();

                foreach (var k in slist)
                {
                    sections.Add(k);
                }
            }

            return sections;

        }
    }
    
}