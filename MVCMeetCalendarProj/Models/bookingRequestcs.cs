using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMeetCalendarProj.Models
{
    // Booking Items Class
    public class bookingRequest
    {
        public DateTime requestTime { get; set; }
        public DateTime meetingTime { get; set; }
        public int meetingLength { get; set; }
        public String EmployeeID { get; set; }



        public string getFileName()
        {
            return HttpContext.Current.Server.MapPath("~/bookinginput.txt");
        }
    }
}