using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace MVCMeetCalendarProj.Models
{
    public class InputData
    {
        public string ServeupData()
        {
                    // Create test data
            string fileName = "~/bookinginput.txt";

            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(fileName)))
            {
                System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));
            }
            FileInfo fi = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(fileName));
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath(fileName), true))
            {
                writer.WriteLine("0900 1730");
                writer.WriteLine("2011-03-17 10:17:06 EMP001");
                writer.WriteLine("2011-03-21 09:00 2");
                writer.WriteLine("2011-03-16 12:34:56 EMP002");
                writer.WriteLine("2011-03-21 09:00 2");
                writer.WriteLine("2011-03-16 09:28:23 EMP003");
                writer.WriteLine("2011-03-22 14:00 2");
                writer.WriteLine("2011-03-17 11:23:45 EMP004");
                writer.WriteLine("2011-03-22 16:00 1");
                writer.WriteLine("2011-03-15 17:29:12 EMP005");
                writer.WriteLine("2011-03-21 16:00 3");
            }
            return fileName;
    }
    }
}