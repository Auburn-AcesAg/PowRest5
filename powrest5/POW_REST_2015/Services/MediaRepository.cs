using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class MediaRepository
    {
        private CommonRepository commonRepository = new CommonRepository();
        public List<CMedium> getMedia(string year)
         {
            int nYear;
            if(Int32.TryParse(year, out nYear)){

            }
            else{
                return null;
            }

             if (nYear <= 2014)
             {
                return null;
             }
             else
             {   
                 var context = new Models2.PowEntities4();
                 var p = (from a in context.Media
                        where a.IsUsed == "Yes" && year == a.Year
                        select a).ToList();

                List<CMedium> media = new List<CMedium>();
                foreach(var a in p)
                {
                    CMedium m = new CMedium();

                    m.ID = a.ID;
                    m.Title = a.Title;
                    m.CreatorID = a.CreatorID;
                    m.Creator = ""; //(from e in context.PowUsers where e.Name.ToLower().Contains(a.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                    m.Program = a.Program;
                    m.Month = a.Month;
                    //County = a.County,
                    m.County = a.County == null ? "" : commonRepository.ConvertSetCounty(a.County);
                    m.Impact = a.Impact;
                    m.Feedback = a.Feedback;
                    m.Year = a.Year;
                    //FileLink = "",
                    m.Modified = a.Modified;
                    m.Project = a.Project;
                    m.Members = (from c in context.MediaMembers
                                 where c.MediaID == a.ID && c.IsUsed == true
                                 select c.MemberID).ToList();
                    media.Add(m);
                }

                return media;


                
                         
             }
         }

         public List<CMedium> getMedia(string year, string userid)
         {
             if (year == "2014")
             {
                /*
                 var context = new Models.PowEntities3();

                 return (from a in context.Media
                         where a.IsUsed.StartsWith("y") && year == a.Year && a.CreatorID.ToLower().Contains(userid.ToLower())
                         orderby a.ID
                         select new CMedium
                         {
                             ID = a.ID,
                             Title = a.Title,
                             CreatorID = a.CreatorID,
                             Creator = a.Creator,
                             Program = a.Program,
                             Month = a.Month,
                             County = a.County,
                             Impact = a.Impact,
                             Feedback = a.Feelback,
                             Year = a.Year,
                             FileLink = a.FileLink,
                             Modified = a.Modified
                         }).ToList();
                */
                return null;
             }
             else
             {
                 var context = new Models2.PowEntities4();
                 var context2 = new Models.PowEntities2();

                 var media = (from a in context.Media
                         where a.IsUsed == "Yes" && year == a.Year && a.CreatorID.ToLower().Contains(userid.ToLower())
                         orderby a.ID
                         select new CMedium
                         {
                             ID = a.ID,
                             Title = a.Title,
                             CreatorID = a.CreatorID,
                             Creator = "", //(from e in context.PowUsers where e.Name.ToLower().Contains(a.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                             Program = a.Program,
                             Month = a.Month,
                             County = a.County,
                             Impact = a.Impact,
                             Feedback = a.Feedback,
                             Year = a.Year,
                             Modified = a.Modified,
                             ProjectID = a.Project
                         }).ToList();

                foreach(var m in media)
                {
                    m.Project = (from e in context2.Projects where e.ID.ToString() == m.ProjectID select e.ProjectTitle).FirstOrDefault();
                    m.Project = m.Project == null ? "" : m.Project;
                }

                return media;
             }
         }


         public List<CMediaEvent> getMediaEvents(string year)
         {
            int nYear;
            if (Int32.TryParse(year, out nYear))
            {
                if (nYear == 2014)
                {
                    /*
                    var context = new Models.PowEntities3();

                    return (from a in context.MediaEvents
                            orderby a.ID
                            select new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },
                                CreatorID = "",
                                Creator = a.Created_By,
                                Modified = a.Modified
                            }).ToList();
                    */
                    return null;
                }
                /*
                else if (nYear >= 2020)
                {
                    var context = new Models2.PowEntities4();

                    return (from a in context.MediaEvents
                            where a.Year == year && a.IsUsed == "Yes"
                            orderby a.ID
                            select new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                CreatorID = a.CreatorID,
                                Creator = "",
                                Modified = a.Modified,
                                EventDates = (from d in context.MediaEventDates
                                              where d.EventID == a.ID & d.IsUsed == true
                                              select new CMediaEventDate
                                              {
                                                  ID = d.ID,
                                                  EventID = a.ID,
                                                  EventDate = d.EventDate
                                              }).ToList()
                            }).ToList();
                }
                */
                else if (nYear == 2020)
                {
                    var context = new Models2.PowEntities4();
                    var p = (from a in context.MediaEvents
                             where a.Year == year && a.IsUsed == "Yes" //&& a.CreatorID == "burgeap"
                             select a).ToList();
                    List<CMediaEvent> events = new List<CMediaEvent>();
                   
                    foreach (var a in p)
                    {
                        if (a.EventTypeID == null)
                        {
                            CMediaEvent e = new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                CreatorID = a.CreatorID,
                                Creator = "",
                                Modified = a.Modified,
                                EventDates = (from d in context.MediaEventDates
                                              where d.EventID == a.ID & d.IsUsed == true
                                              select new CMediaEventDate
                                              {
                                                  ID = d.ID,
                                                  EventID = a.ID,
                                                  EventDate = d.EventDate
                                              }).ToList()
                            };
                            events.Add(e);
                        }
                        else
                        {
                            if (a.Year == "2020" && (a.MediaType == "Newspaper" || a.MediaType == "Radio"
                                || a.MediaType == "TV"))
                            {
                                CMediaEvent e = new CMediaEvent
                                {
                                    ID = a.ID,
                                    MediaID = a.MediaID,
                                    MediaType = a.MediaType,
                                    EventTitle = a.EventTitle,
                                    EventDate = a.EventDate,
                                    MediaName = new CMediaName { value = a.Option2, name = a.MediaType },

                                    MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                    MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                    MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                    MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                    CreatorID = a.CreatorID,
                                    Creator = "",
                                    Modified = a.Modified,
                                    EventDates = (from d in context.MediaEventDates
                                                  where d.EventID == a.ID & d.IsUsed == true
                                                  select new CMediaEventDate
                                                  {
                                                      ID = d.ID,
                                                      EventID = a.ID,
                                                      EventDate = d.EventDate
                                                  }).ToList()
                                };
                                events.Add(e);
                            }
                            else
                            {   
                                if (a.Year == "2020" && a.EventTypeID != null && a.EventTypeID == 17)
                                {
                                    CMediaEvent e = new CMediaEvent
                                    {
                                        ID = a.ID,
                                        MediaID = a.MediaID,
                                        MediaType = (from c in context.MediaEventTypes
                                                                        where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                                        select c.Name).FirstOrDefault(),
                                        EventTitle = a.EventTitle,
                                        EventDate = a.EventDate,

                                        MediaName = new CMediaName { value = a.Option2, name = a.MediaType },

                                        MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                        MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                        MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                        MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                        CreatorID = a.CreatorID,
                                        Creator = "",
                                        Modified = a.Modified,
                                        EventDates = (from d in context.MediaEventDates
                                                      where d.EventID == a.ID & d.IsUsed == true
                                                      select new CMediaEventDate
                                                      {
                                                          ID = d.ID,
                                                          EventID = a.ID,
                                                          EventDate = d.EventDate
                                                      }).ToList()
                                    };
                                    events.Add(e);
                                }
                                else if((a.EventTypeID != null && a.EventTypeID == 19)
                                        || (a.EventTypeID != null && a.EventTypeID == 20))
                                {
                                    if (a.EventTypeID == 19)
                                    {

                                    }
                                    else if (a.EventTypeID == 20)
                                    {

                                    }

                                    string eventType = (from c in context.MediaEventTypes
                                                        where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                        select c.Name).FirstOrDefault();
                                  
                                    string eventSubType = (from c in context.MediaEventSubTypes
                                                           where c.MediaTypeID == (int)a.EventTypeID && c.IsUsed == true && c.Year == year
                                                           select c.Name).FirstOrDefault();

                                    var l = (from c in context.MediaEventMetrics
                                             where c.EventID == a.ID && c.IsUsed == true
                                             select c.Value).FirstOrDefault();

                                    CMediaEvent e = new CMediaEvent
                                    {
                                        ID = a.ID,
                                        MediaID = a.MediaID,
                                        MediaType = (from c in context.MediaEventTypes
                                                     where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                     select c.Name).FirstOrDefault(),
                                        EventTitle = a.EventTitle,
                                        EventDate = a.EventDate,

                                        MediaName = new CMediaName { value = a.Option2, name = a.MediaType },

                                        MediaCount = new CMediaCount { value = l, name = a.MediaType },
                                        MediaDescription = new CMediaDescription { value = eventSubType, name = a.MediaType },


                                        CreatorID = a.CreatorID,
                                        Creator = "",
                                        Modified = a.Modified,
                                        EventDates = (from d in context.MediaEventDates
                                                      where d.EventID == a.ID & d.IsUsed == true
                                                      select new CMediaEventDate
                                                      {
                                                          ID = d.ID,
                                                          EventID = a.ID,
                                                          EventDate = d.EventDate
                                                      }).ToList()
                                    };
                                    events.Add(e);
                                }
                                else if ((a.EventTypeID != null && a.EventSubTypeID != null) )
                                {
                                    string eventType = (from c in context.MediaEventTypes
                                                        where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                        select c.Name).FirstOrDefault();

                                    string eventSubType = (from c in context.MediaEventSubTypes
                                                           where c.ID == (int)a.EventSubTypeID && c.IsUsed == true && c.Year == year
                                                           select c.Name).FirstOrDefault();
                                   

                                    var l = (from c in context.MediaEventMetrics
                                             where c.EventID == a.ID && c.IsUsed == true
                                             select c).ToList();

                                    string metricType1 = "", metricType2 = "";
                                    string metric1 = "", metric2 = "";

                                    int cnt = 1;
                                    foreach (var i in l)
                                    {
                                        if (cnt == 1)
                                        {
                                            metricType1 = (from c in context.MediaEventMetricTypes
                                                           where c.ID == i.MetricTypeID && c.Year == year && c.IsUsed == true
                                                           select c.Name).FirstOrDefault();
                                            metric1 = i.Value;
                                        }
                                        else if (cnt == 2)
                                        {
                                            metricType2 = (from c in context.MediaEventMetricTypes
                                                           where c.ID == i.MetricTypeID && c.Year == year && c.IsUsed == true
                                                           select c.Name).FirstOrDefault();
                                            metric2 = i.Value;
                                            break;
                                        }
                                        cnt++;
                                    }

                                    CMediaEvent e = new CMediaEvent
                                    {
                                        ID = a.ID,
                                        MediaID = a.MediaID,
                                        MediaType = eventType,
                                        EventTitle = a.EventTitle,
                                        EventDate = a.EventDate,
                                        MediaName = new CMediaName { value = eventSubType, name = eventType },

                                        MediaCount = new CMediaCount { value = metric1, name = eventType },
                                        MediaDescription = new CMediaDescription { value = metricType1, name = eventType },

                                        MediaCount2 = new CMediaCount2 { value = metric2, name = a.MediaType },
                                        MediaDescription2 = new CMediaDescription2 { value = metricType2, name = eventType },

                                        CreatorID = a.CreatorID,
                                        Creator = "",
                                        Modified = a.Modified,
                                        EventDates = (from d in context.MediaEventDates
                                                      where d.EventID == a.ID & d.IsUsed == true
                                                      select new CMediaEventDate
                                                      {
                                                          ID = d.ID,
                                                          EventID = a.ID,
                                                          EventDate = d.EventDate
                                                      }).ToList()
                                    };
                                    events.Add(e);
                                }
                            }
                        }
                    }
                   return events;
                }
                else if (nYear >= 2021)
                {
                    var context = new Models2.PowEntities4();
                    var p = (from a in context.MediaEvents join m in context.Media on a.MediaID equals m.ID
                             where m.Year == year && m.IsUsed == "Yes" && a.Year == year && a.IsUsed == "Yes" //&& m.CreatorID == "jdd0042"
                             select a).ToList();
                    List<CMediaEvent> events = new List<CMediaEvent>();

                    foreach (var a in p)
                    {
                        if (a.EventTypeID != null && a.EventSubTypeID != null)
                            {
                                string eventType = (from c in context.MediaEventTypes
                                                    where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                    select c.Name).FirstOrDefault();

                                string eventSubType = (from c in context.MediaEventSubTypes
                                                       where c.ID == (int)a.EventSubTypeID && c.IsUsed == true && c.Year == year
                                                       select c.Name).FirstOrDefault();


                                var l = (from c in context.MediaEventMetrics
                                         where c.EventID == a.ID && c.IsUsed == true
                                         select c).ToList();
                               
                                List<CMediaCount> mcs = new List<CMediaCount>();
                             
                                foreach (var i in l)
                                {
                                    CMediaCount mc = new CMediaCount();
                                    mc.name = (from c in context.MediaEventMetricTypes
                                                    where c.ID == i.MetricTypeID && c.Year == year && c.IsUsed == true
                                                    select c.Name).FirstOrDefault();
                                    mc.value = i.Value;
                                    mcs.Add(mc);
                                }

                            CMediaEvent e = new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = eventType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = eventSubType, name = eventType },

                                /*
                                MediaCount = new CMediaCount { value = metric1, name = eventType },
                                MediaDescription = new CMediaDescription { value = metricType1, name = eventType },

                                MediaCount2 = new CMediaCount2 { value = metric2, name = a.MediaType },
                                MediaDescription2 = new CMediaDescription2 { value = metricType2, name = eventType },
                                */

                                MediaCounts = mcs,

                                CreatorID = a.CreatorID,
                                Creator = "",
                                Modified = a.Modified,
                                EventDates = (from d in context.MediaEventDates
                                                where d.EventID == a.ID & d.IsUsed == true
                                                select new CMediaEventDate
                                                {
                                                    ID = d.ID,
                                                    EventID = a.ID,
                                                    EventDate = d.EventDate
                                                }).ToList()
                                };
                                events.Add(e);
                            }
                    }

                    return events;
                }
                else
                {
                    var context = new Models2.PowEntities4();

                    return (from a in context.MediaEvents
                            where a.Year == year
                            orderby a.ID
                            select new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },
                                CreatorID = a.CreatorID,
                                Creator = "", //(from e in context.PowUsers where e.Name.ToLower().Contains(a.CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(),
                                Modified = a.Modified
                            }).ToList();
                }

            }
            else
            {
                return null;
            }

             
         }

         public List<CMediaEvent> getMediaEvents(string year, string mediaID)
         {
            int nMediaID = Convert.ToInt32(mediaID);
            int nYear;
            if (Int32.TryParse(year, out nYear))
            {               
                if (nYear == 2014)
                {
                    /*
                    var context = new Models.PowEntities3();

                    return (from a in context.MediaEvents
                            where a.MediaID == nMediaID 
                            orderby a.ID
                            select new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },
                                CreatorID = "",
                                Creator = a.Created_By,
                                Modified = a.Modified
                            }).ToList();
                   */
                    return null;
                }
                else if( nYear >= 2020)
                {
                    var context = new Models2.PowEntities4();
                    var p = (from a in context.MediaEvents
                             where a.MediaID == nMediaID && a.Year == year && a.IsUsed == "Yes" select a).ToList();
                    List<CMediaEvent> events = new List<CMediaEvent>(); 
                    foreach (var a in p)
                    {
                        if(a.EventTypeID == null)
                        {
                            CMediaEvent e = new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                CreatorID = a.CreatorID,
                                Creator = "",
                                Modified = a.Modified,
                                EventDates = (from d in context.MediaEventDates
                                              where d.EventID == a.ID & d.IsUsed == true
                                              select new CMediaEventDate
                                              {
                                                  ID = d.ID,
                                                  EventID = a.ID,
                                                  EventDate = d.EventDate
                                              }).ToList()
                            };
                            events.Add(e);
                        }
                        else
                        {
                            if (a.Year == "2020" && (a.MediaType == "Newspaper" || a.MediaType == "Radio"
                                || a.MediaType == "TV"))
                            {
                                CMediaEvent e = new CMediaEvent
                                {
                                    ID = a.ID,
                                    MediaID = a.MediaID,
                                    MediaType = a.MediaType,
                                    EventTitle = a.EventTitle,
                                    EventDate = a.EventDate,
                                    MediaName = new CMediaName { value = a.Option2, name = a.MediaType },

                                    MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                    MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },

                                    MediaCount2 = new CMediaCount2 { value = a.Count2, name = a.MediaType },
                                    MediaDescription2 = new CMediaDescription2 { value = a.Description2, name = a.MediaType },

                                    CreatorID = a.CreatorID,
                                    Creator = "",
                                    Modified = a.Modified,
                                    EventDates = (from d in context.MediaEventDates
                                                  where d.EventID == a.ID & d.IsUsed == true
                                                  select new CMediaEventDate
                                                  {
                                                      ID = d.ID,
                                                      EventID = a.ID,
                                                      EventDate = d.EventDate
                                                  }).ToList()
                                };
                                events.Add(e);
                            }
                            else
                            {
                                if(a.EventTypeID != null && a.EventSubTypeID != null)
                                {
                                    string eventType = (from c in context.MediaEventTypes
                                                        where c.ID == (int)a.EventTypeID && c.IsUsed == "Y" && c.Year == year
                                                        select c.Name).FirstOrDefault();
                                    string eventSubType = (from c in context.MediaEventSubTypes
                                                           where c.ID == (int)a.EventSubTypeID && c.IsUsed == true && c.Year == year
                                                           select c.Name).FirstOrDefault();
                                    var l = (from c in context.MediaEventMetrics
                                             where c.EventID == a.ID
                                             select c).ToList();

                                    string metricType1 = "", metricType2 = "";
                                    string metric1 = "", metric2 = "";

                                    int cnt = 1;
                                    foreach(var i in l)
                                    {
                                        if (cnt == 1)
                                        {
                                            metricType1 = (from c in context.MediaEventMetricTypes
                                                              where c.ID == i.MetricTypeID && c.Year == year && c.IsUsed == true
                                                              select c.Name).FirstOrDefault();
                                            metric1 = i.Value;
                                        }
                                        else if(cnt == 2)
                                        {
                                            metricType2 = (from c in context.MediaEventMetricTypes
                                                           where c.ID == i.MetricTypeID && c.Year == year && c.IsUsed == true
                                                           select c.Name).FirstOrDefault();
                                            metric2 = i.Value;
                                            break;
                                        }
                                        cnt++;
                                    }

                                    CMediaEvent e = new CMediaEvent
                                    {
                                        ID = a.ID,
                                        MediaID = a.MediaID,
                                        MediaType = eventType,
                                        EventTitle = a.EventTitle,
                                        EventDate = a.EventDate,
                                        MediaName = new CMediaName { value = eventSubType, name = eventType },

                                        MediaCount = new CMediaCount { value = metric1, name = eventType },
                                        MediaDescription = new CMediaDescription { value = metricType1, name = eventType },

                                        MediaCount2 = new CMediaCount2 { value = metric2, name = a.MediaType },
                                        MediaDescription2 = new CMediaDescription2 { value = metricType2, name = eventType },

                                        CreatorID = a.CreatorID,
                                        Creator = "",
                                        Modified = a.Modified,
                                        EventDates = (from d in context.MediaEventDates
                                                      where d.EventID == a.ID & d.IsUsed == true
                                                      select new CMediaEventDate
                                                      {
                                                          ID = d.ID,
                                                          EventID = a.ID,
                                                          EventDate = d.EventDate
                                                      }).ToList()
                                    };
                                    events.Add(e);
                                }
                                

                            }

                        }
                    }
                    
                    return events;
                }
                else 
                {
                    var context = new Models2.PowEntities4();
                    return (from a in context.MediaEvents
                            where a.MediaID == nMediaID && a.Year == year && a.IsUsed == "Yes"
                            orderby a.ID
                            select new CMediaEvent
                            {
                                ID = a.ID,
                                MediaID = a.MediaID,
                                MediaType = a.MediaType,
                                EventTitle = a.EventTitle,
                                EventDate = a.EventDate,
                                MediaName = new CMediaName { value = a.Option2, name = a.MediaType },
                                MediaCount = new CMediaCount { value = a.Option1, name = a.MediaType },
                                MediaDescription = new CMediaDescription { value = a.Option3, name = a.MediaType },
                                CreatorID = a.CreatorID,
                                Creator = "",
                                Modified = a.Modified
                            }).ToList();
                }
            }
            else
            {
                return null;
            }
         }
    }
}