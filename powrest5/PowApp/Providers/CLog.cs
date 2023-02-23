using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace PowApp.Providers
{
    public class CLog
    {
        static public void WriteToEventLog(string message)
        {
            String filename = "C:\\Log\\PowApp\\" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") +
                                                          DateTime.Now.Day.ToString("00") + ".txt";

            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter swr = new StreamWriter(fs);
            swr.WriteLine("[" + DateTime.Now + "]" + message);
            swr.Close();
        }
    }
}