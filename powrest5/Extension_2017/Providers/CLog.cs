using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace Extension_2017.Providers
{
    public class CLog
    {
        static public void WriteToEventLog(object message)
        {
            String filename = "C:\\Log\\PowApp\\" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") +
                                                          DateTime.Now.Day.ToString("00") + ".txt";

            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter swr = new StreamWriter(fs);
                        
            JavaScriptSerializer s = new JavaScriptSerializer();

            swr.WriteLine(s.Serialize("[" + DateTime.Now + "]"));
            swr.WriteLine(s.Serialize(message));

            //  json = JsonConvert.SerializeObject(new { Date = DateTime.Now.ToString(), Event = message }, Formatting.Indented);               
            swr.Close();
           
        }

    }    
}