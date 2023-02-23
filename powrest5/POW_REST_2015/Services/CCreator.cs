using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POW_REST_2015.Services
{
    public class CLeadPerson
    {
        public int Id { get; set; }
        public string Teamcode { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Responsibility { get; set; }
        public string JobTitle { get; set; }
        public string Year { get; set; }      
        public Nullable<System.DateTime> Timestamp { get; set; }
    }


    public class CCreator
    {
        private string _CreatorID;
        private string _CreatorName;
        private string _Creator;
        private string _CreatorAccount;

        public string CreatorID
        {
            get { return (_CreatorID.Contains("@")) ? _CreatorID.Split('@')[0].ToLower() : _CreatorID.ToLower() ; }
            set { _CreatorID = value; }
        }

        public string Creator 
        { 
            get { return _Creator; } 
            set { _Creator = value; } 
        }
        
        public string CreatorName
        {
            get
            {
                if (_Creator != null && _Creator != "" && _CreatorName == "")
                {
                    return _Creator.Split('#')[1].ToString();
                }
                else
                    return _CreatorName;
            }

            set { _CreatorName = value;  }
        }

        public string CreatorAccount
        {
            get
            {
                return _CreatorAccount;
            }

            set { _CreatorAccount = value; }

        }
    }
}