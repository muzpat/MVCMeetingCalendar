using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCMeetCalendarProj;
using MVCMeetCalendarProj.Controllers;
using MVCMeetCalendarProj.Models;

namespace MVCMeetCalendarProj.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BookingRequest()
        {
            // Arrange
            List<string> bookingRequests = new List<string>();
            publishMeetingCalendar myCal = new publishMeetingCalendar();
            // Act
            bookingRequests = myCal.GetBookingInput();
            // Assert
            Assert.IsNotNull(bookingRequests);

        }


    }
}
