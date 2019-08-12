using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections;
using MVCMeetCalendarProj.Models;

namespace MVCMeetCalendarProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book()
        {
            return View();
        }

        public ActionResult Bookings()
        {
            List<string> myDates = new List<string>();
            List<string> myDays = new List<string>();
            myDates.Add( DateTime.Today.ToShortDateString());
            int i = 1;
            while (i <= 13)
            {
                myDates.Add(DateTime.Today.AddDays(i).ToShortDateString());
                i++;

            }
            ViewBag.BookingDates = myDates;

            myDays.Add("Today");
            i = 1;
            while (i <= 13)
            {
                myDays.Add(DateTime.Today.AddDays(i).DayOfWeek.ToString());
                i++;

            }
            ViewBag.BookingDays = myDays;
            return View();
        }
        public ActionResult Spec()
        {
            return View();
        }
        public ActionResult Publish()
        {
            List<string> bookingRequests = new List<string>();
            publishMeetingCalendar myCal = new publishMeetingCalendar();
            bookingRequests = myCal.GetBookingInput();
            ViewBag.stringlist2 = bookingRequests;
            return View();
        }

        public ActionResult Create()
        {
            InputData myInput = new InputData();
            string testDataName = myInput.ServeupData();
            List<string> list = System.IO.File.ReadAllLines(Server.MapPath(testDataName)).ToList();
            ViewBag.stringlist = list;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult UpdateCalendar()
        {
            // Initial page display (equivalent of != IsPostback)
            BookingViewModel myViewModel = new BookingViewModel();
            List<string> bookingRequests = new List<string>();
            publishMeetingCalendar myCal = new publishMeetingCalendar();
            myViewModel.CurrentCalendar = myCal.GetCal();
            myViewModel.ddlEmp = new List<SelectListItem>();
            myViewModel.InitialiseEmp();
            myViewModel.ddlMeetingStart = new List<SelectListItem>();
            myViewModel.InitialiseMeetingTime();
            myViewModel.ddlMeetingLength = new List<SelectListItem>();
            myViewModel.InitialiseMeetingLength();
            myViewModel.ddlMeetingDay = new List<SelectListItem>();
            myViewModel.InitialiseMeetingDay();
            return View(myViewModel);
        }
        [HttpPost]
        public ActionResult UpdateCalendar(FormCollection collection)
        {
            // Initial page display (equivalent of != IsPostback)
            BookingViewModel myViewModel = new BookingViewModel();
            List<string> bookingRequests = new List<string>();
            publishMeetingCalendar myCal = new publishMeetingCalendar();
            myViewModel.CurrentCalendar = myCal.GetCal();
            myViewModel.ddlEmp = new List<SelectListItem>();
            myViewModel.InitialiseEmp();
            myViewModel.ddlMeetingStart = new List<SelectListItem>();
            myViewModel.InitialiseMeetingTime();
            myViewModel.ddlMeetingLength = new List<SelectListItem>();
            myViewModel.InitialiseMeetingLength();
            myViewModel.ddlMeetingDay = new List<SelectListItem>();
            myViewModel.InitialiseMeetingDay();
            myViewModel.selecteditemDdlEmp = collection["selecteditemDdlEmp"];
            myViewModel.selecteditemDdlMeetingStart = collection["selecteditemDdlMeetingStart"];
            myViewModel.selecteditemDdlMeetingLength = collection["selecteditemDdlMeetingLength"];
            myViewModel.selecteditemDdlMeetingDay = collection["selecteditemDdlMeetingday"];
            // Add booking to calendar on page
            bookingRequest myBook = new bookingRequest();
            myBook.requestTime = DateTime.Now;
            myBook.meetingLength = int.Parse(collection["selecteditemDdlMeetingLength"]);
            myBook.EmployeeID = collection["selecteditemDdlEmp"];
            string chkTime = collection["selecteditemDdlMeetingStart"];
            string currentDate = DateTime.Now.Date.ToString();
            if (collection["selecteditemDdlMeetingDay"] == "2")
                currentDate = DateTime.Now.Date.AddDays(1).ToString();
            DateTime dt = Convert.ToDateTime(currentDate.Substring(0,11) + " " + chkTime);
            myBook.meetingTime = dt;
            myViewModel.CurrentCalendar.Add(myBook);
            return View(myViewModel);
        }  
          
    }
}


