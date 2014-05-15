using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMeetCalendarProj.Models;
using System.Collections;
using System.Collections.Generic;

namespace MVCMeetCalendarProj.Tests.Models
{
    [TestClass]
    public class publishMeetingCalendarModel
    {
        [TestMethod]
        public void CreatePublishMeetingCalendarObj()
        {
            // Arrange
            publishMeetingCalendar myPublisher = new publishMeetingCalendar();

            // Assert
            Assert.IsNotNull(myPublisher, "Unable to create publishMeetingCalendar object");
        }
        [TestMethod]
        public void UpdateCalendarTest()
        {
            // Arrange  
            publishMeetingCalendar myPublisher = new publishMeetingCalendar();
            bookingRequest myBooking = new bookingRequest();
            List<bookingRequest> mydetailsList = new List<bookingRequest>();
            myBooking.EmployeeID = "EMP001";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 09:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-17 10:17:06");
            mydetailsList.Add(myBooking);

            myBooking = new bookingRequest();
            myBooking.EmployeeID = "EMP002";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 09:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-16 12:34:56");
            mydetailsList.Add(myBooking);

            myBooking = new bookingRequest();
            myBooking.EmployeeID = "EMP003";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-22 14:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-16 09:28:23");
            mydetailsList.Add(myBooking);

            myBooking = new bookingRequest();
            myBooking.EmployeeID = "EMP004";
            myBooking.meetingLength = 1;
            myBooking.meetingTime = DateTime.Parse("2011-03-22 16:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-17 11:23:45");
            mydetailsList.Add(myBooking);

            myBooking = new bookingRequest();
            myBooking.EmployeeID = "EMP005";
            myBooking.meetingLength = 3;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 16:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-15 17:29:12");
            mydetailsList.Add(myBooking);
            List<DateTime> openingTimes = new List<DateTime>();
            DateTime myTime = DateTime.Parse("2014 01 01 09:00");
            openingTimes.Add(myTime);
            myTime = DateTime.Parse("2014 01 01 17:30");
            openingTimes.Add(myTime);
            // Act
            List<bookingRequest> mydetails = myPublisher.UpdateCalendar(mydetailsList, openingTimes);

            // Assert
            Assert.IsNotNull(mydetails, "Unable to create publishMeetingCalendar object");
        }
        [TestMethod]
        public void OKtoAddBookingToCalendarTest()
        {
            // Arrange
            publishMeetingCalendar myPublisher = new publishMeetingCalendar();
            bookingRequest myRequest = new bookingRequest();
            myRequest.requestTime = DateTime.Parse("2013 12 31 22:10");
            myRequest.EmployeeID = "EMP001";
            myRequest.meetingTime = DateTime.Parse("2014 01 31 10:00");
            myRequest.meetingLength = 3;
            // Act
            List<bookingRequest> myCal = new List<bookingRequest>();
            myCal.Add(myRequest);
            bool myResult = myPublisher.OKtoAddBookingToCalendar(myCal, myRequest);

            // Assert   can't add booking when booking already in Calendar
            Assert.IsFalse(myResult, "Unable to execute OKtoAddBookingToCalendar method");
        }

        [TestMethod]
        public void FormatCalendarTest()
        {
            // Arrange  
            publishMeetingCalendar myPublisher = new publishMeetingCalendar();
            bookingRequest myBooking = new bookingRequest();
            List<bookingRequest> mydetailsList = new List<bookingRequest>();
            myBooking.EmployeeID = "EMP001";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 09:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-17 10:17:06");
            mydetailsList.Add(myBooking);

            myBooking.EmployeeID = "EMP002";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 09:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-16 12:34:56");
            mydetailsList.Add(myBooking);

            myBooking.EmployeeID = "EMP003";
            myBooking.meetingLength = 2;
            myBooking.meetingTime = DateTime.Parse("2011-03-22 14:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-16 09:28:23");
            mydetailsList.Add(myBooking);

            myBooking.EmployeeID = "EMP004";
            myBooking.meetingLength = 1;
            myBooking.meetingTime = DateTime.Parse("2011-03-22 16:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-17 11:23:45");
            mydetailsList.Add(myBooking);

            myBooking.EmployeeID = "EMP005";
            myBooking.meetingLength = 3;
            myBooking.meetingTime = DateTime.Parse("2011-03-21 16:00:00");
            myBooking.requestTime = DateTime.Parse("2011-03-15 17:29:12");
            mydetailsList.Add(myBooking);

          /*
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
           * */
            // Act
            List<bookingRequest> mydetails = mydetailsList;
            List<string> mydetails2 = myPublisher.FormatCalendar(mydetails);

            // Assert
            Assert.IsNotNull(mydetails2, "Unable to create publishMeetingCalendar object");
        }

    }
}


