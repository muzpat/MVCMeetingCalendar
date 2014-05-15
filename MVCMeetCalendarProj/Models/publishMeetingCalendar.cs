using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections;

namespace MVCMeetCalendarProj.Models
{
    public class publishMeetingCalendar
    {
        public publishMeetingCalendar()
        {
        }
        public List<bookingRequest> GetCal()
        {
            List<bookingRequest> bookingRequests = FormatInputToList();
            //sort booking requests by time requested ascending
            List<bookingRequest> sortedBookingRequests = bookingRequests.OrderBy(o => o.requestTime).ToList();
            // Office opening time
            List<DateTime> openingTimes = GetOfficeHours();
            // accept booking for calendar?
            List<bookingRequest> bookingCalendar = UpdateCalendar(sortedBookingRequests, openingTimes);   // Booking Calendar repository              
            //sort booking Calendar by meeting time ascending
            List<bookingRequest> sortedbookingCalendar = bookingCalendar.OrderBy(o => o.meetingTime).ToList();
            return sortedbookingCalendar;
        }
        public List<string> GetBookingInput()
        {
            // Output
            List<string> outputLines = new List<string>();
            try
            {
                List<bookingRequest> bookingRequests = FormatInputToList();
                //sort booking requests by time requested ascending
                List<bookingRequest> sortedBookingRequests = bookingRequests.OrderBy(o => o.requestTime).ToList();
                // Office opening time
                List<DateTime> openingTimes = GetOfficeHours();
                // accept booking for calendar?
                List<bookingRequest> bookingCalendar = UpdateCalendar(sortedBookingRequests, openingTimes);   // Booking Calendar repository              
                //sort booking Calendar by meeting time ascending
                List<bookingRequest> sortedbookingCalendar = bookingCalendar.OrderBy(o => o.meetingTime).ToList();
                //  Output format List
                outputLines = FormatCalendar(sortedbookingCalendar);
                //// Format Meeting calendar in output format
                return outputLines;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ");
                Console.WriteLine(ex.Message);
                return outputLines;
            }
        }
        public List<string> FormatCalendar(List<bookingRequest> sortedbookingCalendar)
        {
            List<string> outputLines = new List<string>();
            // Format Meeting calendar in output format
            DateTime currentDate = DateTime.ParseExact("01/01/1901", "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);   // initial low date
            foreach (bookingRequest calendarBooking in sortedbookingCalendar)
            {
                // Date heading required?
                if (calendarBooking.meetingTime.Date != currentDate.Date)
                {
                    string outDate = String.Format("{0:yyyy-MM-dd}", calendarBooking.meetingTime.Date);
                    outputLines.Add(outDate);
                    currentDate = calendarBooking.meetingTime;
                }
                // calendar booking detail
                string myLine = String.Format("{0:HH:mm}", calendarBooking.meetingTime);  // meeting start time
                DateTime endtime = calendarBooking.meetingTime.AddHours(calendarBooking.meetingLength);
                myLine = myLine + " " + String.Format("{0:HH:mm}", endtime);  // meeting end time
                myLine = myLine + " " + calendarBooking.EmployeeID;            // Employee ID
                outputLines.Add(myLine);
            }
            return outputLines;
        }
        public List<bookingRequest> UpdateCalendar(List<bookingRequest> sortedBookingRequests, List<DateTime> openingTimes)
        {
            DateTime OpenTime = DateTime.Now;
            DateTime CloseTime = DateTime.Now;
            OpenTime = openingTimes[0];
            CloseTime = openingTimes[1];
              List<bookingRequest> bookingCalendar = new List<bookingRequest>(); 
                foreach (bookingRequest candidateBooking in sortedBookingRequests)   // Process each candidate booking
                {
                    // Does candidate booking  end after office closing time
                    if (candidateBooking.meetingTime.AddHours(candidateBooking.meetingLength).TimeOfDay > CloseTime.TimeOfDay)
                    {
                        continue; // outside office hours - don't add to Calendar bookings!
                    }
                    else if (candidateBooking.meetingTime.TimeOfDay < OpenTime.TimeOfDay)
                    {
                        continue; // before office hours start time -  don't add to Calendar bookings!
                    }
                    else if (bookingCalendar == null)   // no bookings in calendar
                    {
                        bookingCalendar.Add(candidateBooking);   // add candidate to Meeting Calendar
                    }
                    else if (!bookingCalendar.Any(c => c.meetingTime == candidateBooking.meetingTime))   // no calendar bookings for candidate booking on that day
                    {
                        bookingCalendar.Add(candidateBooking);    // add candidate to Meeting Calendar
                    }
                    else   // check for time clash
                    {
                        if (OKtoAddBookingToCalendar(bookingCalendar, candidateBooking))
                        {
                            bookingCalendar.Add(candidateBooking);  // add candidate to Meeting Calendar
                        }
                    }
                }
            return bookingCalendar;
        }
        public List<DateTime> GetOfficeHours()
        {
            int i = 0;                              // counter
            DateTime OpenTime = DateTime.Now;       // Office opening time
            DateTime CloseTime = DateTime.Now;
            List<DateTime> Times = new List<DateTime>();
            String line = "";
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/bookinginput.txt")))    // Test data file
            {
                while (line != null)
                {
                    line = sr.ReadLine();          // Read test data
                    if (line == null)
                    {
                        break;                     // EoF
                    }
                    i++;
                    if (i == 1)                    // First test data record containing office opening hours
                    {
                        string[] times = line.Split(' ');
                        string time = times[0];
                        OpenTime = DateTime.ParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                        time = times[1];
                        CloseTime = DateTime.ParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture);

                        Times.Add(OpenTime);
                        Times.Add(CloseTime);
                        return Times;
                    }
                    break;
                }
            }
            return Times;
        }
        public List<bookingRequest> FormatInputToList()
        {
            List<bookingRequest> bookingRequests = new List<bookingRequest>();     // list for booking requests
            int i = 0;                              // counter
            DateTime OpenTime = DateTime.Now;       // Office opening time
            DateTime CloseTime = DateTime.Now;
            String line = "";
            bookingRequest myRequest = null;
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/bookinginput.txt")))    // Test data file
            {
                while (line != null)
                {
                    line = sr.ReadLine();          // Read test data
                    if (line == null)
                    {
                        break;                     // EoF
                    }
                    i++;
                    if (i == 1)                    // First test data record containing office opening hours
                    {
                        string[] times = line.Split(' ');
                        string time = times[0];
                        OpenTime = DateTime.ParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                        time = times[1];
                        CloseTime = DateTime.ParseExact(time, "HHmm", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        if (i % 2 == 0)   // even lines, submission time and Employee ID
                        {
                            myRequest = new bookingRequest();
                            string InputRequestTime = line.Substring(0, 19);
                            myRequest.requestTime = DateTime.Parse(InputRequestTime);
                            myRequest.EmployeeID = line.Substring(20, 6);
                        }
                        else              // odd lines, meeting start time and duration
                        {
                            string InputMeetingTime = line.Substring(0, 16);
                            string InputMeetingLength = line.Substring(17, 1);
                            myRequest.meetingTime = DateTime.Parse(InputMeetingTime);
                            myRequest.meetingLength = int.Parse(InputMeetingLength);
                            bookingRequests.Add(myRequest);                   // Create a booking request item  
                        }
                    }
                }
            }
            return bookingRequests;
        }
        public bool OKtoAddBookingToCalendar(List<bookingRequest> bookCal, bookingRequest candidatebooking)
        {
            DateTime candidateStartTime = candidatebooking.meetingTime;
            DateTime candidateEndTime = candidatebooking.meetingTime.AddHours(candidatebooking.meetingLength);

            foreach (bookingRequest booking in bookCal)
            {
                DateTime start = booking.meetingTime;                                 // current calendar booking start time
                DateTime end = booking.meetingTime.AddHours(booking.meetingLength);   // current calendar booking end time
                // if candidate end before book start or candidate start after book end, then OK        
                if ((candidateEndTime < booking.meetingTime) || (candidateStartTime > end))   // time clash
                {
                    // ok
                }
                else
                {
                    return false;   // time clash! don't allow this candidate to be added to the meeting calendar
                }
            }
            return true;   // ok, allow this candidate to be added to the meeting calendar
        }
    }
}