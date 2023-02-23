using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace POW_REST_2015.Services
{  
    public class CMediaEventDate
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }           
    }

    public class CMediaEvent
    {
        static Models.PowEntities2 context = new Models.PowEntities2();
        private string _Creator;
        private string _CreatorID;

        public int ID { get; set; }
        public Nullable<int> MediaID { get; set; }
        public string MediaType { get; set; }
        public string EventTitle { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }

        public CMediaName MediaName { get; set; }   

        public CMediaCount MediaCount { get; set; }

        public CMediaDescription MediaDescription { get; set; }

        public CMediaCount2 MediaCount2 { get; set; }
        public CMediaDescription2 MediaDescription2 { get; set; }

        public Nullable<System.DateTime> Modified { get; set; }

        public string CreatorID
        {
            get { return _CreatorID == "" ? "" : (_CreatorID.Contains("@")) ? _CreatorID.Split('@')[0] : _CreatorID; }
            set { _CreatorID = value; }
        }

        public string Creator
        {
            get { return _Creator != "" ? _Creator : (from e in context.PowUsers where e.Name.ToLower().Contains(CreatorID.ToLower()) select e.ID.ToString() + ";#" + e.Title).FirstOrDefault(); }
            set { _Creator = value; }
        }

        public List<CMediaEventDate> EventDates { get; set; }
        public List<CMediaCount> MediaCounts { get; set; }
    }
       
 
    public class CMediaName
    {
        private string _name;

        [XmlAttribute]
        public string value { get; set; }   

        [XmlAttribute]
        public string name {             
            get {
                    if (_name != null && _name != "")
                    {
                        switch (_name)
                        {
                            case "Newspaper": return "Newspaper Name";
                            case "Radio": return "Station Name";
                            case "TV": return "Station Name";
                            case "E-Correspondence": return "E-Correspondence Type";
                            case "Printed Material": return "Printed Material Type";
                            default: return _name;
                        }
                    }
                    else
                    {
                        return "";
                    }
            } 
            
            set {
                _name = value;
            } 
        }
    }

    public class CMediaCount
    {
        private string _name;

        [XmlAttribute]
        public string value { get; set; }

        [XmlAttribute]
        public string name
        {
            get
            {
                if (_name != null && _name != "")
                {
                    switch (_name)
                    {                      
                        case "TV": return "Air Time";
                        case "Radio": return "Air Time";
                        case "E-Correspondence": return "Recipients";                 
                        default: return _name;
                    }
                }
                else
                {
                    return _name;
                }
            }

            set
            {
                _name = value;
            }
        }
    }

    public class CMediaDescription
    {
        private string _name;

        [XmlAttribute]
        public string value { get; set; }

        [XmlAttribute]
        public string name
        {
            get
            {
                if (_name != null && _name != "")
                {
                    switch (_name)
                    {
                        case "Printed Material": return "County";
                        case "E-Correspondence": return "Alias";
                        default: return "";
                    }
                }
                else
                {
                    return "";
                }
            }

            set
            {
                _name = value;
            }
        }
    }


    public class CMediaCount2
    {
        private string _name;

        [XmlAttribute]
        public string value { get; set; }

        [XmlAttribute]
        public string name
        {
            get
            {
                if (_name != null && _name != "")
                {
                    switch (_name)
                    {
                        case "E-Correspondence": return "Recipients";                        
                        default: return "";
                    }
                }
                else
                {
                    return "";
                }
            }

            set
            {
                _name = value;
            }
        }
    }


    public class CMediaDescription2
    {
        private string _name;

        [XmlAttribute]
        public string value { get; set; }

        [XmlAttribute]
        public string name
        {
            get
            {
                if (_name != null && _name != "")
                {
                    switch (_name)
                    {
                        case "E-Correspondence": return "Alias";
                        default: return "";
                    }
                }
                else
                {
                    return "";
                }
            }

            set
            {
                _name = value;
            }
        }
    }

}